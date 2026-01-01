using KYS.NET.DATA.Common;
using KYS.NET.DATA.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace KYS.NET.DATA.Repositories
{
  public class DocumentRepository : IDocumentRepository
  {
    private readonly string? _connStr = DBConnectionObject.DBConnStr;

    /// <summary>
    /// 문서 번호 채번 Proc 호출
    /// 예시 : DC-20251229-00001
    /// </summary>
    /// <returns></returns>
    public string GenerateDocumentNumber()
    {
      using (SqlConnection conn = new(_connStr))
      {
        conn.Open();
        using (SqlCommand cmd = new("dbo.usp_get_docno_i", conn))
        {
          //1. 프로시저로 설정 및 실행
          cmd.CommandType = CommandType.StoredProcedure;
          var docNo = cmd.ExecuteScalar();

          //2. 결과 값 반환
          return docNo?.ToString() ?? string.Empty;
        }
      }
    }

    /// <summary>
    /// 신규 문서 저장 Proc 호출
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public bool InsertDocument<T>(T ModelObject) where T : class
    {
      using (SqlConnection conn = new(_connStr))
      {
        conn.Open();
        using (SqlCommand cmd = new("dbo.usp_new_doc_iu", conn))
        {
          //플래그 값 설정 : 'i' - Insert
          cmd.Parameters.AddWithValue("@p_flag", "i");

          //ModelObject 의 속성들을 파라미터로 추가 (Reflection 활용) 
          foreach (var prop in ModelObject.GetType().GetProperties())
          {
            var value = prop.GetValue(ModelObject) ?? DBNull.Value;
            cmd.Parameters.AddWithValue($"@p_{prop.Name.ToLower()}", value);
          }

          //프로시저 실행
          cmd.CommandType = CommandType.StoredProcedure;
          var result = cmd.ExecuteScalar();

          return Convert.ToByte(result) > 0;
        }
      }
    }

    /// <summary>
    /// 기존 문서 Update Proc 호출
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public int UpdateDocument<T>(T ModelObject) where T : class
    {
      throw new NotImplementedException();
    }
  }
}