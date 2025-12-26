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
        if (login.ShowDialog() == DialogResult.OK)
        {
          Application.Run(new ApprovalRequestForm());
        } else
        {
          Application.Exit();
        }
      }
    }
  }
}