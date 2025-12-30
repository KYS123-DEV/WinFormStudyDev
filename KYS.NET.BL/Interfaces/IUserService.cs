using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.BL.Interfaces
{
  public interface IUserService
  {
    (bool IsSuccess, string? userid, string? usernm, string Message) Login(string id, string pw);
  }
}
