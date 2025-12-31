using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.BL.Interfaces
{
  public interface IBaseService<T> where T : class
  {
    (bool IsSuccess, string Message) InsertDocument(T ModelObject);
  }
}
