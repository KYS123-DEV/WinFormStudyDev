using KYS.NET.DATA.Common;
using Microsoft.Data.SqlClient;

public class CodeService
{
  public readonly string? Connstr;
  public CodeService()
  {
    Connstr = DBConnectionObject.DBconnStr;
  }

  public class ComboItem
  {
    public string? Code { get; set; }
    public string? CodeNm { get; set; }
  }

  public List<ComboItem> GetItems(string codekind, string kind1)
  {
    List<ComboItem> items = new ();
    using (SqlConnection conn = new(Connstr))
    {
      // 데이터 조회 및 items 채우기
      conn.Open();
      string query = "SELECT a.code AS code, a.codenm AS codenm" +
        " FROM bicod01t a " +
        " WHERE a.codekind = @codekind " +
        " AND a.kind1 = @kind1";
      using (SqlCommand cmd = new(query, conn))
      {
        SqlParameter param1 = new SqlParameter("@codekind", codekind);
        SqlParameter param2 = new SqlParameter("@kind1", kind1);

        cmd.Parameters.Add(param1);
        cmd.Parameters.Add(param2);
        var sdr = cmd.ExecuteReader();
        while(sdr.Read())
        {
          items.Add(new ComboItem
          {
            Code = sdr["code"].ToString()!,
            CodeNm = sdr["codenm"].ToString()!
          });
        }
      }
    }
    return items;
  }
}