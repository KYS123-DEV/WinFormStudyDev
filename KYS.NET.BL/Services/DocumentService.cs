using KYS.NET.DATA.Common;
using KYS.NET.DATA.Interfaces;
using KYS.NET.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.BL.Services
{
  /// <summary>
  /// 문저 관련 서비스 (CRUD)
  /// </summary>
  internal class DocumentService : IRepository<DocumentModel>
  {
    public readonly string? Connstr;
    public DocumentService()
    {
      Connstr = DBConnectionObject.DBconnStr;
    }

    /// <summary>
    /// 문서 생성 수정 예정
    /// </summary>
    /// <param name="Model"></param>
    /// <returns></returns>
    public bool Create(DocumentModel Model)
    {
      return false;
    }

    // 수정 필요
    public List<DocumentModel> GetAll()
    {
      throw new NotImplementedException();
    }

    public List<DocumentModel> Select()
    {
      throw new NotImplementedException();
    }
  }
}
