using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.BL.Common
{
  /// <summary>
  /// 사용자 정보 세션 읽기 전용
  /// </summary>
  public record SessionInfo
  {
    public string UserId { get; init; } = string.Empty;
    public string UserName { get; init; } = string.Empty;
  }

  /// <summary>
  /// 사용자 세션 전역 관리자
  /// </summary>
  public static class SessionManager {
    public static SessionInfo? CurrentSession { get; private set; }

    public static void Login(SessionInfo sessionInfo)
    {
      CurrentSession = sessionInfo;
    }

    public static void LogOut(SessionInfo sessionInfo)
    {
      CurrentSession = null;
    }
  }
}
