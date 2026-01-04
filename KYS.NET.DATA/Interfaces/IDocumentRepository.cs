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
    List<T> SelectDocument<T>(T ModelObject) where T : class;
    bool InsertDocument<T>(T ModelObject) where T : class;
    int UpdateDocument<T>(T ModelObject) where T : class;
  }
}
