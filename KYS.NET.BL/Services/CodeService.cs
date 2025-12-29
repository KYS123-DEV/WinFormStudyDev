using KYS.NET.DATA.Common;
using KYS.NET.DATA.Repositories;
using Microsoft.Data.SqlClient;

public class CodeService
{
  private CodeRepository _codeRepo = new();
  public List<ComboItem> GetItems(string codekind, string kind)
  {
    var list = _codeRepo.Select(codekind, kind);
    return list ?? new List<ComboItem>();
  }
}