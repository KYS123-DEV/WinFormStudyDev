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
      using SqlConnection conn = new(_connStr);
      conn.Open();
      using SqlCommand cmd = new("dbo.usp_get_new_docno", conn);

      //1. 프로시저로 설정 및 실행
      cmd.CommandType = CommandType.StoredProcedure;

      //2. 결과 값 반환
      return cmd.ExecuteScalar().ToString() ?? string.Empty;
    }

    /// <summary>
    /// 조회 로직
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    public async Task<List<TResult>> SelectDocumentAsync<TResult, TSearch>(TSearch ModelObject)
      where TResult : class, new()
      where TSearch : class
    {
      var resultList = new List<TResult>();
      var m = ModelObject as DocumentModelForSearch;

      using SqlConnection conn = new(_connStr);
      await conn.OpenAsync();
      using SqlCommand cmd = new("dbo.usp_doc_s", conn);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@p_docdtdiv", m?.DocDtDiv);
      cmd.Parameters.AddWithValue("@p_dt1", m?.Dt1);
      cmd.Parameters.AddWithValue("@p_dt2", m?.Dt2);
      cmd.Parameters.AddWithValue("@p_doccontentdiv", m?.DocContentDiv);
      cmd.Parameters.AddWithValue("@p_docsearchtext", m?.DocSearchText);

      using SqlDataReader sdr = await cmd.ExecuteReaderAsync();
      var properties = typeof(TResult).GetProperties();

      while (await sdr.ReadAsync())
      {
        var item = new TResult();
        foreach (var prop in properties)
        {
          try
          {
            int ordinal = sdr.GetOrdinal(prop.Name);
            if (!sdr.IsDBNull(ordinal))
              prop.SetValue(item, sdr.GetValue(ordinal));
          }
          catch
          {
            continue;
          }
        }
        resultList.Add(item);
      }

      return resultList;
    }

    /// <summary>
    /// 신규 문서 저장 Proc 호출
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public async Task<bool> InsertDocumentAsync<T>(T ModelObject) where T : class
    {
      using SqlConnection conn = new(_connStr);
      await conn.OpenAsync();
      using SqlCommand cmd = new("dbo.usp_doc_iu", conn);
      cmd.CommandType = CommandType.StoredProcedure;

      var m = ModelObject as DocumentModelForCRUD;

      //플래그 값 설정 : 'i' - Insert
      cmd.Parameters.AddWithValue("@p_flag", "i");
      cmd.Parameters.AddWithValue("@p_docno", m?.DocNo);
      cmd.Parameters.AddWithValue("@p_entryid", m?.EntryId);
      cmd.Parameters.AddWithValue("@p_doctitle", m?.DocTitle);
      cmd.Parameters.AddWithValue("@p_doccontent", m?.DocContent);
      cmd.Parameters.AddWithValue("@p_docfilenm", m?.DocFilenm);
      cmd.Parameters.AddWithValue("@p_docdiv", m?.DocDiv);
      cmd.Parameters.AddWithValue("@p_doccomment", m?.DocComment);
      cmd.Parameters.AddWithValue("@p_entrydt", m?.EntryDt);
      cmd.Parameters.AddWithValue("@p_updatedt", m?.UpdateDt);
      cmd.Parameters.AddWithValue("@p_enddt", m?.EndDt);

      //프로시저 실행
      cmd.CommandType = CommandType.StoredProcedure;
      var result = await cmd.ExecuteScalarAsync();

      return Convert.ToByte(result) > 0;
    }

    /// <summary>
    /// 문서 업데이트 구현 필요
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<bool> UpdateDocumentAsync<T>(T ModelObject) where T : class
    {
      using SqlConnection conn = new(_connStr);
      await conn.OpenAsync();
      using SqlCommand cmd = new("dbo.usp_doc_iu", conn);
      cmd.CommandType = CommandType.StoredProcedure;

      var m = ModelObject as DocumentModelForCRUD;

      //플래그 값 설정 : 'u' - Update
      cmd.Parameters.AddWithValue("@p_flag", "u");
      cmd.Parameters.AddWithValue("@p_docno", m?.DocNo);
      cmd.Parameters.AddWithValue("@p_entryid", m?.EntryId);
      cmd.Parameters.AddWithValue("@p_doctitle", m?.DocTitle);
      cmd.Parameters.AddWithValue("@p_doccontent", m?.DocContent);
      cmd.Parameters.AddWithValue("@p_docfilenm", m?.DocFilenm);
      cmd.Parameters.AddWithValue("@p_docdiv", m?.DocDiv);
      cmd.Parameters.AddWithValue("@p_doccomment", m?.DocComment);
      cmd.Parameters.AddWithValue("@p_entrydt", m?.EntryDt);
      cmd.Parameters.AddWithValue("@p_updatedt", m?.UpdateDt);
      cmd.Parameters.AddWithValue("@p_enddt", m?.EndDt);

      //프로시저 실행
      cmd.CommandType = CommandType.StoredProcedure;
      var result = await cmd.ExecuteScalarAsync();

      return Convert.ToByte(result) > 0;
    }

    /// <summary>
    /// 문서 삭제 로직
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public async Task<bool> DeleteDocumentAsync(string val)
    {
      using SqlConnection conn = new(_connStr);
      await conn.OpenAsync();
      
      string deleteQuery = "DELETE FROM sydoc01t WHERE doc_no = @doc_no ";
      using SqlCommand cmd = new(deleteQuery, conn);
      cmd.Parameters.Add(new SqlParameter("@doc_no", val));

      //DELETE 실행.
      int result = cmd.ExecuteNonQuery();

      return result > 0 ? true : false;
    }

    /// <summary>
    /// 첨부파일 저장 로직
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public async Task<bool> FileSaveAsync<T>(T ModelObject) where T : class
    {
      using SqlConnection conn = new (_connStr);
      await conn.OpenAsync();
      using SqlCommand cmd = new("dbo.usp_fileSave_iu", conn);

      var m = ModelObject as FileModel;

      //수정 필요
      cmd.Parameters.Add(new SqlParameter("@p_filekey",m?.FileKey));
      cmd.Parameters.Add(new SqlParameter("@p_filenm", m?.FileNm));
      cmd.Parameters.Add(new SqlParameter("@p_filesize", m?.FileSize));
      cmd.Parameters.Add(new SqlParameter("@p_filedata", m?.FileData));
      cmd.Parameters.Add(new SqlParameter("@p_entryid", m?.EntryId));
      cmd.Parameters.Add(new SqlParameter("@p_entrydt", m?.EntryDt));

      cmd.CommandType = CommandType.StoredProcedure;
      var result = await cmd.ExecuteScalarAsync();

      return Convert.ToByte(result) > 0;
    }
  }
}
