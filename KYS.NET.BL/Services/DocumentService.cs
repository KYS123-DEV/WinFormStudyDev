using KYS.NET.BL.Common;
using KYS.NET.BL.Interfaces;
using KYS.NET.DATA.Interfaces;
using KYS.NET.DATA.Repositories;
using KYS.NET.MODELS;

namespace KYS.NET.BL.Services
{
  /// <summary>
  /// 문서 관련 서비스 (CRUD)
  /// </summary>
  public class DocumentService : IDocumentService
  {
    private readonly IDocumentRepository _doc;
    public DocumentService() : this(new DocumentRepository()) {}
    public DocumentService(IDocumentRepository doc)
    {
      _doc = doc;
    }

    /// <summary>
    /// 문서 번호 채번
    /// </summary>
    /// <returns></returns>
    public string GenerateDocumentNumber()
    {
      return _doc.GenerateDocumentNumber();
    }

    /// <summary>
    /// 문서 저장 ( Insert 혹은 Update )
    /// </summary>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public (bool IsSuccess, string Message) InsertDocument(DocumentModel ModelObject)
    {
      //1. docNo 비어 있는지 확인
      string docNo = ModelObject.DocNo ?? string.Empty;

      //2. docNo 비어 있으면 채번 프로시저 호출하여 획득 (프로시저) : 신규 입력 저장
      if (string.IsNullOrEmpty(docNo))
      {
        docNo = GenerateDocumentNumber();

        if (string.IsNullOrEmpty(docNo))
          return (false, "문서 채번 로직 오류!");
      } else
      {
        //3. docNo 값이 있으면 Update 로직 호출
        return UpdateDocument(ModelObject);
      }

        ModelObject = ModelObject with
        {
          DocNo = docNo,
          EntryId = SessionManager.CurrentSession?.UserId
        };

      //3. 문서 Save 프로시저 호출
      bool result = _doc.InsertDocument<DocumentModel>(ModelObject);

      return result ? (true, "문서 저장 성공!") : (false, "문서 저장 실패!");
    }

    /// <summary>
    /// 문서 UPDATE 로직
    /// </summary>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public (bool IsSuccess, string Message) UpdateDocument(DocumentModel ModelObject)
    {
      if (_doc.UpdateDocument<DocumentModel>(ModelObject) <= 0)
      {
        return (false, "문서 수정 실패!");
      }
      else
      {
        return (true, "문서 수정 성공!");
      }
    }
  }
}
