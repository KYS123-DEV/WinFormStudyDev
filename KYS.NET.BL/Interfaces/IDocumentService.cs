using KYS.NET.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.BL.Interfaces
{
  public interface IDocumentService
  {
    //문서 서비스에 필요한 채번 메서드
    public string GenerateDocumentNumber();
    (bool IsSuccess, string Message, List<TResult> SelectList) SelectDocument<TResult, TSearch>(TSearch ModelObject)
      where TResult : class
      where TSearch : class;
    (bool IsSuccess, string Message) InsertDocument<T>(T ModelObject) where T : class;
    (bool IsSuccess, string Message) UpdateDocument<T>(T ModelObject) where T : class;
  }
}
