using KYS.NET.STUDY.Forms.Approval;

namespace KYS.NET.STUDY
{
  internal static class Program
  {
    [STAThread]
    static void Main()
    {
      ApplicationConfiguration.Initialize();

      using (LoginForm login = new LoginForm())
      {
        switch (login.ShowDialog())
        {
          case DialogResult.OK:
            Application.Run(new ApprovalRequestForm());
            break;
          default:
            Application.Exit();
            break;
        }
      }
    }
  }
}