using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.DATA.Interfaces
{
  public interface IReadOnlyRepository<T> where T : class
  {
    List<T> Select(string codekind, string kind);
  }
}
