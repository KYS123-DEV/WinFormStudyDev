using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.DATA.Interfaces
{
  public interface IUserRepository
  {
    (bool isValid, string? userid, string? usernm) Login(string userId, string pwd);
  }
}
