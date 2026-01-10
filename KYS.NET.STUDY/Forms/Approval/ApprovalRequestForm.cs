using KYS.NET.BL.Common;
using KYS.NET.BL.Interfaces;
using KYS.NET.BL.Services;
using KYS.NET.DATA.Common;
using KYS.NET.MODELS;
using KYS.NET.STUDY.Utils;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;

namespace KYS.NET.STUDY.Forms.Approval
{
  public partial class ApprovalRequestForm : Form
  {
    private readonly IDocumentService _doc;

    public ApprovalRequestForm()
    {
      InitializeComponent();
      _doc = new DocumentService();
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
      //제목 AND 내용 작성되어 있지 않으면 return.
      if (string.IsNullOrEmpty(txtb_doctitle.Text) && string.IsNullOrEmpty(txtb_doccontent.Text))
      {
        MsgHelper.ShowWarning("제목 및 내용을 작성하세요.");
        return;
      }

      //저장하시겠습니까? 메시지 알림.
      if (MsgHelper.ShowQuestion("저장하시겠습니까?") == DialogResult.No)
        return;
      
      try
      {
        DocumentModelForCRUD documentModel = new DocumentModelForCRUD
        {
          DocNo = string.Empty,
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
        result.SelectList.ToList().Where(item => item.GetType().Name.Equals(dgv_approval.Name));
        dgv_approval.DataSource = result.SelectList;
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
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocNo","DocNo","문서번호",120,true,true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocTitle","DocTitle","문서제목",200,true,true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("EntryDt","EntryDt","신청일자/접수일자",200,true,true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("EndDt", "EndDt", "완료일자", 200, true, true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("UpdateDt","UpdateDt","수정일자",0,true,false));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("EntryId","EntryId","작성자",100,true,true));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocContent","DocContent","문서내용",0,true,false));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocComment", "DocComment", "관리자 답변",0,true,false));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocFilenm","DocFilenm","첨부파일",0,true,false));
      dgv_approval.Columns.Add(Dgv_approval_AddColumns("DocDiv","DocDiv","문서구분",0,true,false));
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
  }
}