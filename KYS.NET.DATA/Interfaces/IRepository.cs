using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.DATA.Interfaces
{
  public interface IRepository<T> where T : class
  {
    bool Create(T Model);
    List<T> Select();

    //U,D 추가 예정
    // bool Update(T Model);
    // bool Delete(int id);
  }
}
