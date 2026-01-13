using KYS.NET.BL.Common;
using KYS.NET.BL.Interfaces;
using KYS.NET.BL.Services;
using KYS.NET.MODELS;
using KYS.NET.STUDY.Utils;
using File = System.IO.File;

namespace KYS.NET.STUDY.Forms.Approval
{
  public partial class ApprovalRequestForm : Form
  {
    private readonly IDocumentService _doc;

    private bool _isDirty = false;    //상태 플래그 변수
    private bool _isBinding = false;  //데이터 바인딩 중인지 확인하는 변수

    public ApprovalRequestForm()
    {
      InitializeComponent();
      _doc = new DocumentService();
      AttachDirtyCheckEvents();
    }

    /// <summary>
    /// 컨트롤의 TextChanged 이벤트에 MarkAsDirty 핸들러 등록
    /// </summary>
    private void AttachDirtyCheckEvents()
    {
      txtb_doctitle.TextChanged += MarkAsDirty;
      txtb_doccontent.TextChanged += MarkAsDirty;
      cb_docdiv.SelectedIndexChanged += MarkAsDirty;
    }

    /// <summary>
    /// 컨트롤의 입력 값 변화가 있는지 Check하는 이벤트 핸들러
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MarkAsDirty(object? sender, EventArgs e)
    {
      if (!_isBinding)
      {
        _isDirty = true;
      }
    }

    /// <summary>
    /// 문서 작성 Form Load 이벤트
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ApprovalRequestForm_Load(object sender, EventArgs e)
    {
      //현재 달의 첫째 날 ~ 현재 달의 마지막 날로 설정
      dt_picker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      dt_picker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

      //폼 제목
      //Text += DBConnectionObject.CurrentSpid;

      // 화면 상단 라벨에 사용자 정보 표시
      lbl_welcome.Text = $"Logged in as: {SessionManager.CurrentSession?.UserId} ";
      lbl_welcome.Text += $"({SessionManager.CurrentSession?.UserName})";

      //dgv_approval DataGridView에 컬럼 추가.
      Dgv_approval_InitGrid();

      //조회 combobox 컨트롤 setting
      try
      {
        CodeBind(cb_dt, "101", "1");
        CodeBind(cb_search, "101", "2");
        CodeBind(cb_docdiv, "110", "");
      }
      catch (Exception ex)
      {
        MsgHelper.ShowError("[Combobox error] : " + ex.Message);
      }
    }

    public void CodeBind(ComboBox comboBox, string codekind, string kind)
    {
      comboBox.DataSource = new CodeService().GetItems(codekind, kind);
      comboBox.DisplayMember = "CodeNm";
      comboBox.ValueMember = "Code";
    }

    /// <summary>
    /// 앱 종료
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btn_logout_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    /// <summary>
    /// 문서 저장 (Create 혹은 Update)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btn_save_Click(object sender, EventArgs e)
    {
      if (!_isDirty)
      {
        MsgHelper.ShowWarning("변경 사항이 없습니다.");
        return;
      }

      //제목 AND 내용 작성되어 있지 않으면 return.
      if (string.IsNullOrEmpty(txtb_doctitle.Text) && string.IsNullOrEmpty(txtb_doccontent.Text))
      {
        MsgHelper.ShowWarning("제목 및 내용을 작성하세요.");
        return;
      }

      //수정된 사항이 없으면 '변경 사항이 없습니다.' 사용자 알림.
      

      //저장하시겠습니까? 메시지 알림.
      if (MsgHelper.ShowQuestion("저장하시겠습니까?") == DialogResult.No)
        return;

      try
      {
        DocumentModelForCRUD documentModel = new DocumentModelForCRUD
        {
          DocNo = txtb_docno.Text.Trim(),
          EntryId = SessionManager.CurrentSession?.UserId,
          DocTitle = txtb_doctitle.Text,
          DocContent = txtb_doccontent.Text,
          DocFilenm = txtb_docfilenm.Text,
          DocDiv = cb_docdiv.SelectedValue?.ToString() ?? string.Empty,
        };

        // 결과 처리 작성하기.
        var result = await _doc.SaveDocumentAsync(documentModel);

        if (result.IsSuccess)
        {
          _isDirty = false;
          await RetrieveData();
          MsgHelper.ShowInfo(result.Message);
        }
        else
        {
          MsgHelper.ShowWarning(result.Message);
        }
      }
      catch (Exception ex)
      {
        MsgHelper.ShowError("[Save error] : " + ex.Message);
      }
    }

    /// <summary>
    /// 문서 조회 기능
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async Task RetrieveData()
    {
      dgv_approval.DataSource = null;

      //날짜 구분 값 획득
      string? cb_dt_div = cb_dt.SelectedValue?.ToString();

      //날짜 값 획득
      string dt_start = dt_picker1.Value.ToString("yyyy-MM-dd");
      string dt_end = dt_picker2.Value.ToString("yyyy-MM-dd");

      //검색 구분 값 획득
      string? cb_search_div = cb_search.SelectedValue?.ToString();

      //검색어 획득
      string cb_search_txt = txtb_search.Text.Trim();

      try
      {
        DocumentModelForSearch documentModel = new DocumentModelForSearch
        {
          DocDtDiv = cb_dt_div,
          Dt1 = dt_start,
          Dt2 = dt_end,
          DocContentDiv = cb_search_div,
          DocSearchText = cb_search_txt
        };

        //Service 호출 및 결과 자료 받음.
        (bool IsSuccess, string Message, List<DocumentModelForCRUD> SelectList) result =
          await _doc.SelectDocumentAsync<DocumentModelForCRUD, DocumentModelForSearch>(documentModel);

        //결과 처리 필요
        if (!result.IsSuccess)
        {
          MsgHelper.ShowWarning(result.Message);
          return;
        }

        //DataGridView에 결과 바인딩
        Dgv_approval_InitGrid();
        result.SelectList.ToList().Where(item => item.GetType().Name.Equals(dgv_approval.Name));
        dgv_approval.DataSource = result.SelectList;

        //조회 후 첫번째 행 선택되도록.
        dgv_approval_InputSetting(0);
      }
      catch (Exception ex)
      {
        MsgHelper.ShowError("[Retrieve error] : " + ex.Message);
      }
    }

    private async void btn_retrieve_Click(object sender, EventArgs e)
    {
      await RetrieveData();
    }

    /// <summary>
    /// Dgv_approval 데이터그리드뷰에 기본 컬럼 생성하기.
    /// </summary>
    private void Dgv_approval_InitGrid()
    {
      dgv_approval.Columns.Clear();

      dgv_approval.AllowUserToAddRows = false;
      dgv_approval.RowHeadersVisible = false;
      dgv_approval.AllowUserToResizeRows = false;

      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocNo", "DocNo", "문서번호", 120, true, true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocTitle", "DocTitle", "문서제목", 200, true, true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("EntryDt", "EntryDt", "신청일자/접수일자", 200, true, true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("EndDt", "EndDt", "완료일자", 200, true, true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("UpdateDt", "UpdateDt", "수정일자", 0, true, false));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("EntryId", "EntryId", "작성자", 100, true, true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocContent", "DocContent", "문서내용", 0, true, false));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocComment", "DocComment", "관리자 답변", 0, true, false));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocFilenm", "DocFilenm", "첨부파일", 0, true, false));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocDiv", "DocDiv", "문서구분", 0, true, false));
    }

    //결재서 DataGridView에 기초 컬럼 setting.
    private DataGridViewTextBoxColumn Dgv_approval_AddColumns(
      string columnName, string dataPropertyName, string headerText
      , int width, bool readOnly, bool visiblity)
    {
      return new DataGridViewTextBoxColumn
      {
        Name = columnName,
        DataPropertyName = dataPropertyName, // 모델(DocumentModelForCRUD)의 프로퍼티명
        HeaderText = headerText,
        Width = width,
        ReadOnly = readOnly,
        Visible = visiblity
      };
    }

    /// <summary>
    /// 왼쪽 조회 그리드의 행 클릭 할 때마다, 우측의 input란에 정보 setting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dgv_approval_InputSetting(int row)
    {
      _isBinding = true;

      DataGridViewRow dgvRow = dgv_approval.Rows[row];
      txtb_docno.Text = dgvRow.Cells["DocNo"].Value.ToString();
      txtb_enrolldt.Text = dgvRow.Cells["EntryDt"].Value.ToString();
      cb_docdiv.SelectedValue = dgvRow.Cells["DocDiv"].Value.ToString();
      txtb_doctitle.Text = dgvRow.Cells["DocTitle"].Value.ToString();
      txtb_doccontent.Text = dgvRow.Cells["DocContent"].Value.ToString();
      txtb_docfilenm.Text = dgvRow.Cells["DocFilenm"].Value.ToString();
      txtb_updatedt.Text = dgvRow.Cells["UpdateDt"].Value.ToString();
      txtb_comment.Text = dgvRow.Cells["DocComment"].Value.ToString();

      _isDirty = false;
      _isBinding = false;
    }

    private void dgv_approval_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0) return;

      int row = dgv_approval.Rows[e.RowIndex].Index;
      dgv_approval_InputSetting(row);
    }

    /// <summary>
    /// 자료 삭제
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btn_delete_Click(object sender, EventArgs e)
    {
      string DocNo = txtb_docno.Text.Trim();
      if (DocNo.Equals(""))
      {
        MsgHelper.ShowWarning("삭제할 문서를 선택해주세요.");
        return;
      }

      //삭제 하시겠습니까?
      if (!(MsgHelper.ShowQuestion($"문서번호 : {DocNo} \n삭제하시겠습니까?") == DialogResult.No))
      {
        try
        {
          // 결과 처리 작성하기.
          (bool IsSuccess, string Message) result = await _doc.DeleteDocumentAsync(DocNo);

          if (result.IsSuccess)
          {
            await RetrieveData();
            MsgHelper.ShowInfo(result.Message);
          }
          else
          {
            MsgHelper.ShowWarning(result.Message);
          }
        }
        catch (Exception ex)
        {
          MsgHelper.ShowError("[삭제 에러] : " + ex.Message);
        }
      }
    }

    /// <summary>
    /// 첨부 파일 업로드를 하기 위한 처리
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btn_fileupload_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txtb_docno.Text))
      {
        MsgHelper.ShowWarning("문서를 먼저 생성 후 파일을 올리세요.");
        return;
      }

      using (OpenFileDialog ofd = new())
      {
        ofd.InitialDirectory = "c:\\";
        ofd.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt|pdf files (*.pdf)|*.pdf";

        if (ofd.ShowDialog() == DialogResult.OK)
        {
          string filePath = ofd.FileName;

          try
          {
            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);

            //파일정보 가져오기
            FileInfo fileInfo = new FileInfo(filePath);

            FileModel fm = new FileModel(
              txtb_docno.Text,
              fileInfo.Name,
              fileBytes,
              fileInfo.Length,
              SessionManager.CurrentSession.UserId
              );

            txtb_docfilenm.Text = fileInfo.Name;
            var result = await _doc.FileSaveAsync<FileModel>(fm);

            if (result.IsValid)
            {
              await RetrieveData();
              MsgHelper.ShowInfo(result.Message);
            } else
            {
              MsgHelper.ShowWarning(result.Message);
            }
          }
          catch (Exception ex)
          {
            MsgHelper.ShowError("[File Error] : " + ex.Message);
          }
        }
      }
    }
  }
}