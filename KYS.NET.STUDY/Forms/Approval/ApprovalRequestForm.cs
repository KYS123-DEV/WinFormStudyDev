using KYS.NET.BL.Common;
using KYS.NET.BL.Interfaces;
using KYS.NET.BL.Services;
using KYS.NET.DATA.Common;
using KYS.NET.MODELS;
using KYS.NET.STUDY.Utils;
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
      //폼 제목
      //Text += DBConnectionObject.CurrentSpid;

      // 화면 상단 라벨에 사용자 정보 표시
      lbl_welcome.Text = $"Logged in as: {SessionManager.CurrentSession?.UserId} ";
      lbl_welcome.Text += $"({SessionManager.CurrentSession?.UserName})";

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
    private void btn_save_Click(object sender, EventArgs e)
    {
      try
      {
        DocumentModel documentModel = new DocumentModel
        {
          DocNo = string.Empty,
          EntryId = SessionManager.CurrentSession?.UserId,
          DocTitle = txtb_doctitle.Text,
          DocContent = txtb_doccontent.Text,
          DocFilenm = txtb_docfilenm.Text,
          DocDiv = cb_docdiv.SelectedValue?.ToString() ?? string.Empty,
        };

        // 결과 처리 작성하기.
        var result = _doc.InsertDocument(documentModel);

        if (result.IsSuccess)
        {
          MsgHelper.ShowInfo(result.Message);
        }
        else
        {
          MsgHelper.ShowWarning(result.Message);
        }

      } catch (Exception ex)
      {
        MsgHelper.ShowError("[Save error] : " + ex.Message);
      }
    }
  }
}
