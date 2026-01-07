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
    Task<List<TResult>> SelectDocument<TResult, TSearch>(TSearch ModelObject)
      where TResult : class
      where TSearch : class;
    Task<bool> InsertDocument<T>(T ModelObject) where T : class;
    Task<int> UpdateDocument<T>(T ModelObject) where T : class;
  }
}
