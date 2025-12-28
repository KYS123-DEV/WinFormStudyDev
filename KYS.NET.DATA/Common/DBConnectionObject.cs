using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.DATA.Common
{
  /// <summary>
  /// DB 연결 문자열 관리 객체
  /// </summary>
  public class DBConnectionObject
  {
    public static string? DBconnStr;
    /// <summary>
    /// DB 접속 문자열 반환
    /// </summary>
    /// <returns></returns>
    public static string? GetConnstr()
    {
      //설정 빌더 구성
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
      DBconnStr = config.GetConnectionString("DBConnection_1");
      return config.GetConnectionString("DBConnection_1");
    }
  }
}
