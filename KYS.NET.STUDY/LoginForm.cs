using KYS.NET.BL.Services;
using KYS.NET.STUDY.Forms.Approval;
using KYS.NET.STUDY.Utils;

namespace KYS.NET.STUDY
{
  public partial class LoginForm : Form
  {
    public LoginForm()
    {
      InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 로그인
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Btn_login_Click(object sender, EventArgs e)
    {
      try
      {
        AuthService auth = new();
        var result = auth.Login(txtb_id.Text, txtb_pw.Text);

        if (result.IsSuccess)
        {
          //로그인 성공
          //MsgHelper.ShowInfo(result.Message);
          DialogResult = DialogResult.OK;

          // 현재 사용자 정보를 어딘가 저장하고 싶다면 (선택사항)
          // SessionInfo.UserId = txtb_id.Text;

          Close();
          //this.Hide();
        }
        else
        {
          MsgHelper.ShowWarning(result.Message);
        }
      }
      catch (Exception ex)
      {
        MsgHelper.ShowError(ex.Message);
      }
    }

    private void txtb_pw_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Btn_login_Click(sender, e);
      }
    }
  }
}
