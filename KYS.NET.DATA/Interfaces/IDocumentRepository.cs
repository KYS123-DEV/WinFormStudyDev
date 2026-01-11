using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.DATA.Interfaces
{
  public interface IDocumentRepository
  {
    public string GenerateDocumentNumber();
    Task<List<TResult>> SelectDocumentAsync<TResult, TSearch>(TSearch ModelObject)
      where TResult : class, new()
      where TSearch : class;
    Task<bool> InsertDocumentAsync<T>(T ModelObject) where T : class;
    Task<bool> UpdateDocumentAsync<T>(T ModelObject) where T : class;
    Task<bool> DeleteDocumentAsync(string val);
  }
}
