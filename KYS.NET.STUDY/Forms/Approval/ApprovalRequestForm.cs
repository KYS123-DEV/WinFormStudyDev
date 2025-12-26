using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYS.NET.STUDY.Forms.Approval
{
  public partial class ApprovalRequestForm : Form
  {
    private readonly string _loginId;
    private readonly string _loginName;
    public ApprovalRequestForm()
    {
      InitializeComponent();
      //_loginId = userId;
      // 화면 상단 라벨에 사용자 정보 표시
      //lbl_welcome.Text = $"Logged in as: {_loginId}";
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
  }
}
