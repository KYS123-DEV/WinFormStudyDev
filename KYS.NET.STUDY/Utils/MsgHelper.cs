using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.STUDY.Utils
{
  public class MsgHelper
  {
    public static void ShowInfo(string message)
    {
      MessageBox.Show(message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void ShowWarning(string message)
    {
      MessageBox.Show(message, "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void ShowError(string message)
    {
      MessageBox.Show(message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
