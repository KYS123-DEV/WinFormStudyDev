using KYS.NET.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.BL.Services
{
  public class AuthService
  {
    private UserRepository _userRepo = new UserRepository();

    /// <summary>
    /// 로그인 확인
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pw"></param>
    /// <returns></returns>
    //  Tuple 리턴
    public (bool IsSuccess, string? userid, string? usernm, string Message) Login(string id, string pw)
    {
      if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(pw))
        return (false, "", "", "아이디와 비밀번호를 입력해주세요.");

      // DATA 계층의 프로시저 실행 메서드 호출
      (bool isValid, string? userid, string? usernm) = _userRepo.CheckLogin(id, pw);

      if (isValid)
        return (true, userid, usernm, "로그인 성공!");
      else
        return (false, "", "", "아이디 또는 비밀번호가 틀렸습니다.");
    }
  }
}
