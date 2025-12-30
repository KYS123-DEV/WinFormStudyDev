using KYS.NET.BL.Common;
using KYS.NET.STUDY.Utils;

namespace KYS.NET.STUDY.Forms.Approval
{
  public partial class ApprovalRequestForm : Form
  {
    public ApprovalRequestForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// 문서 작성 Form Load 이벤트
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ApprovalRequestForm_Load(object sender, EventArgs e)
    {
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
    /// 문서 저장 (CRUD - Create)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btn_save_Click(object sender, EventArgs e)
    {

    }
  }
}
