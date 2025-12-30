using KYS.NET.DATA.Repositories;

public class CodeService
{
  public List<ComboItem> GetItems(string codekind, string kind)
  {
    var list = new CodeRepository().Select(codekind, kind);
    return list ?? new List<ComboItem>();
  }
}