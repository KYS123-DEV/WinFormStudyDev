using KYS.NET.DATA.Common;
using KYS.NET.DATA.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.DATA.Repositories
{
  public class ComboItem
  {
    public string? Code { get; set; }
    public string? CodeNm { get; set; }
  }

  public class CodeRepository : IReadOnlyRepository<ComboItem>
  {
    private readonly string? _Connstr;
    public CodeRepository()
    {
      _Connstr = DBConnectionObject.DBConnStr;
    }

    public List<ComboItem> Select(string codekind, string kind)
    {
      List<ComboItem> items = new();
      using (SqlConnection conn = new(_Connstr))
      {
        // 데이터 조회 및 items 채우기
        conn.Open();
        string query =
          " SELECT a.code AS code, a.codenm AS codenm" +
          " FROM bicod01t a " +
          " WHERE a.codekind = @codekind " +
          " AND ISNULL(a.kind1,'') = @kind1 ";
        using (SqlCommand cmd = new(query, conn))
        {
          SqlParameter param1 = new SqlParameter("@codekind", codekind);
          SqlParameter param2 = new SqlParameter("@kind1", kind);

          cmd.Parameters.Add(param1);
          cmd.Parameters.Add(param2);
          var sdr = cmd.ExecuteReader();
          while (sdr.Read())
          {
            items.Add(new ComboItem { Code = sdr["code"].ToString()!
                                    , CodeNm = sdr["codenm"].ToString()! });
          }
        }
      }
      return items;
    }

  }
}