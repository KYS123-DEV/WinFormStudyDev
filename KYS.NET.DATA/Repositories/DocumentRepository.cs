using KYS.NET.DATA.Common;
using KYS.NET.DATA.Interfaces;
using KYS.NET.MODELS;
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
    /// 조회 로직
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public List<TResult> SelectDocument<TResult, TSearch>(TSearch ModelObject)
      where TResult : class
      where TSearch : class
    {
      List<TResult> resultList = new List<TResult>();
      var searchModel = ModelObject as DocumentModelForSearch;

      using (SqlConnection conn = new(_connStr))
      {
        conn.Open();
        using (SqlCommand cmd = new("dbo.usp_get_doc_s", conn))
        {
          cmd.Parameters.AddWithValue("@p_docdtdiv", searchModel?.DocDtDiv);
          cmd.Parameters.AddWithValue("@p_dt1", searchModel?.Dt1);
          cmd.Parameters.AddWithValue("@p_dt2", searchModel?.Dt2);
          cmd.Parameters.AddWithValue("@p_doccontentdiv", searchModel?.DocContentDiv);
          cmd.Parameters.AddWithValue("@p_docsearchtext", searchModel?.DocSearchText);

          cmd.CommandType = CommandType.StoredProcedure;

          using (SqlDataReader sdr = cmd.ExecuteReader())
          {
            while (sdr.Read())
            {
              // 데이터 매핑 (DocumentModel 객체 생성)
              var item = new DocumentModelForCRUD
              {
                DocNo = sdr["doc_no"]?.ToString(),
                DocTitle = sdr["doc_title"]?.ToString(),
                EntryId = sdr["entryid"]?.ToString(),
                Entrydt = sdr["entrydt"]?.ToString(),
                Enddt = sdr["enddt"]?.ToString()
                // 추가 컬럼이 있다면 여기에 작성
              };

              resultList.Add(item as TResult);
            }
          }

        }
      }
      return resultList;
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
          /*foreach (var prop in ModelObject.GetType().GetProperties())
          {
            var value = prop.GetValue(ModelObject) ?? DBNull.Value;
            cmd.Parameters.AddWithValue($"@p_{prop.Name.ToLower()}", value);
          }*/

          cmd.Parameters.AddWithValue("@p_docno", (ModelObject as DocumentModelForCRUD)?.DocNo);
          cmd.Parameters.AddWithValue("@p_entryid", (ModelObject as DocumentModelForCRUD)?.EntryId);
          cmd.Parameters.AddWithValue("@p_doctitle", (ModelObject as DocumentModelForCRUD)?.DocTitle);
          cmd.Parameters.AddWithValue("@p_doccontent", (ModelObject as DocumentModelForCRUD)?.DocContent);
          cmd.Parameters.AddWithValue("@p_docfilenm", (ModelObject as DocumentModelForCRUD)?.DocFilenm);
          cmd.Parameters.AddWithValue("@p_docdiv", (ModelObject as DocumentModelForCRUD)?.DocDiv);
          cmd.Parameters.AddWithValue("@p_doccomment", (ModelObject as DocumentModelForCRUD)?.DocComment);
          cmd.Parameters.AddWithValue("@p_entrydt", (ModelObject as DocumentModelForCRUD)?.Entrydt);
          cmd.Parameters.AddWithValue("@p_updatedt", (ModelObject as DocumentModelForCRUD)?.Updatedt);
          cmd.Parameters.AddWithValue("@p_enddt", (ModelObject as DocumentModelForCRUD)?.Enddt);

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