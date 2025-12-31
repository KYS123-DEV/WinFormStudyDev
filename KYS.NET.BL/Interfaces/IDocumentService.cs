using KYS.NET.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.BL.Interfaces
{
  public interface IDocumentService : IBaseService<DocumentModel>
  {
    //문서 서비스에 필요한 채번 메서드
    public string GenerateDocumentNumber();
  }
}
