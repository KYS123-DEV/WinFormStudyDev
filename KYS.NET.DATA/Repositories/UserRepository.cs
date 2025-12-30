using KYS.NET.DATA.Common;
using KYS.NET.DATA.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.DATA.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly string? _connstr;
    public UserRepository() {
      _connstr = DBConnectionObject.GetConnstr();
    }

    /// <summary>
    /// 로그인 체크
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public (bool isValid, string? userid, string? usernm) Login(string userId, string pwd)
    {
      using (SqlConnection conn = new(_connstr))
      {
        conn.Open();
        using (SqlCommand cmd = new("dbo.usp_login", conn))
        {
          //1. 프로시저로 설정
          cmd.CommandType = CommandType.StoredProcedure;

          //2. 파라미터 설정
          cmd.Parameters.AddWithValue("@p_id", userId);
          cmd.Parameters.AddWithValue("@p_pwd", pwd);

          //3. 실행 - 에러 처리 필요
          var sdr = cmd.ExecuteReader();

          int result = 0;
          string? userid = string.Empty;
          string? usernm = string.Empty;

          if (sdr.Read())
          {
            result = Convert.ToInt16(sdr["result"]);
            userid = sdr["userid"].ToString();
            usernm = sdr["usernm"].ToString();
          }

          // true : 로그인 성공
          // false : 로그인 실패
          return (result > 0, userid, usernm);
        }
      }
    }
  }
}
