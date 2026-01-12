namespace KYS.NET.BL.Interfaces
{
  public interface IDocumentService
  {
    string GenerateDocumentNumber();     //채번 로직
    Task<(bool IsSuccess, string Message, List<TResult> SelectList)>
      SelectDocumentAsync<TResult, TSearch>(TSearch ModelObject)
      where TResult : class, new()
      where TSearch : class;
    Task<(bool IsSuccess, string Message)> SaveDocumentAsync<T>(T ModelObject) where T : class;
    Task<(bool IsSuccess, string Message)> DeleteDocumentAsync(string val);
    Task<(bool IsValid, string Message)> FileSaveAsync<T>(T ModelOjbect);
  }
}
