using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.DATA.Entities
{
  public class UserRepository
  {
    private readonly string? _connstr;
    public UserRepository() {
      //설정 빌더 구성
      var config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .Build();
      _connstr = config.GetConnectionString("DBConnection_1");
    }

    /// <summary>
    /// 로그인 체크
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public bool CheckLogin(string userId, string pwd)
    {
      using (SqlConnection conn = new (_connstr))
      {
        conn.Open();
        using (SqlCommand cmd = new("dbo.usp_login", conn))
        {
          //1. 프로시저로 설정
          cmd.CommandType = CommandType.StoredProcedure;

          //2. 파라미터 설정
          cmd.Parameters.AddWithValue("@p_id", userId);
          cmd.Parameters.AddWithValue("@p_pwd", pwd);

          var returnParam = new SqlParameter
          {
            ParameterName = "@return_value",
            SqlDbType = SqlDbType.SmallInt, // 프로시저의 @result 타입과 맞춤
            Direction = ParameterDirection.ReturnValue
          };
          cmd.Parameters.Add(returnParam);

          //3. 실행 - 에러 처리 필요
          cmd.ExecuteNonQuery();

          //4. 결과 확인
          int result = Convert.ToInt32(returnParam.Value);

          // true : 로그인 성공
          // false : 로그인 실패
          return result > 0 ? true : false;
        }
      }
    }
  }
}
