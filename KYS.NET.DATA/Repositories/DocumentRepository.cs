using KYS.NET.DATA.Common;
using KYS.NET.DATA.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;

namespace KYS.NET.DATA.Repositories
{

  public class DocumentRepository : IDocumentRepository
  {
    private readonly string? _connStr = DBConnectionObject.DBConnStr;

    /// <summary>
    /// 문서 번호 채번 Proc 호출
    /// </summary>
    /// <returns></returns>
    public string GenerateDocumentNumber()
    {
      using (SqlConnection conn = new(_connStr))
      {
        conn.Open();
        using (SqlCommand cmd = new("dbo.usp_new_docno_i", conn))
        {
          //1. 프로시저로 설정
          cmd.CommandType = CommandType.StoredProcedure;

          //2. 파라미터 설정

          //3. 실행 - 에러 처리 필요

        }
      }

      //임시
      return "";
    }

    /// <summary>
    /// 문서 저장 Proc 호출
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public bool InsertDocument<T>(T ModelObject) where T : class
    {
      throw new NotImplementedException();
    }
  }
}
