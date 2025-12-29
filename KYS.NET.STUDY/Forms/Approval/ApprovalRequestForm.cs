using KYS.NET.BL.Common;
using KYS.NET.DATA.Common;
using KYS.NET.STUDY.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYS.NET.STUDY.Forms.Approval
{
  public partial class ApprovalRequestForm : Form
  {
    public ApprovalRequestForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Form Load 이벤트
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
        CodeService cs = new();

        cb_dt.DataSource = cs.GetItems("101", "1");
        cb_dt.DisplayMember = "CodeNm";
        cb_dt.ValueMember = "Code";

        cb_search.DataSource = cs.GetItems("101", "2");
        cb_search.DisplayMember = "CodeNm";
        cb_search.ValueMember = "Code";

        cb_docdiv.DataSource = cs.GetItems("110", "");
        cb_docdiv.DisplayMember = "CodeNm";
        cb_docdiv.ValueMember = "Code";
      }
      catch (Exception ex)
      {
        MsgHelper.ShowError("[Combobox error] : " + ex.Message);
      }
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
