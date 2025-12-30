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
    private static string? _dbConnStr;

    /// <summary>
    /// DB 접속 문자열 반환
    /// </summary>
    /// <returns></returns>
    public static string? GetConnstr()
    {
      //이미 있으면 바로 반환
      if (!string.IsNullOrEmpty(_dbConnStr)) return _dbConnStr;

      //설정 빌더 구성
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
      _dbConnStr = config.GetConnectionString("DBConnection_1");
      return _dbConnStr;
    }
  }
}
