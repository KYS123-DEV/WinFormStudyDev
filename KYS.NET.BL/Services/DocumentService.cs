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
    public DocumentService() : this(new DocumentRepository()) { }
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
    /// 문서 조회 (SELECT)
    /// 수정 필요
    /// </summary>
    /// <param name="ModelObject"></param>
    public async Task<(bool IsSuccess, string Message, List<TResult> SelectList)>
    SelectDocumentAsync<TResult, TSearch>(TSearch ModelObject)
    where TResult : class, new()
    where TSearch : class
    {
      // Repository의 비동기 메서드를 await로 호출
      var result = await _doc.SelectDocumentAsync<TResult, TSearch>(ModelObject);

      if (result == null || result.Count == 0)
        return (false, "조회된 문서가 없습니다.", new List<TResult>());

      return (true, "", result);
    }

    /// <summary>
    /// 문서 저장 ( Insert 혹은 Update )
    /// </summary>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public async Task<(bool IsSuccess, string Message)> SaveDocumentAsync<T>(T ModelObject) where T : class
    {
      var crudModel = ModelObject as DocumentModelForCRUD;
      if (crudModel == null) return (false, "유효하지 않은 모델 형식입니다.");

      string newDocNo;
      //docNo가 없으면 신규 채번 (Insert)
      if (string.IsNullOrEmpty(crudModel.DocNo))
      {
        newDocNo = GenerateDocumentNumber();
        if (string.IsNullOrEmpty(newDocNo))
        {
          return (false, "채번 실패!");
        }

        crudModel = crudModel with
        {
          DocNo = newDocNo,
          EntryId = SessionManager.CurrentSession?.UserId
        };

        bool isOk = await _doc.InsertDocumentAsync(crudModel);
        return isOk ? (true, "저장 성공") : (false, "저장 실패");
      }
      else
      {
        bool isOk = await _doc.UpdateDocumentAsync(crudModel);
        return isOk ? (true, "수정 성공") : (false, "수정 실패");
      }
    }

    /// <summary>
    /// 문서 삭제 로직
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelObject"></param>
    /// <returns></returns>
    public async Task<(bool IsSuccess, string Message)> DeleteDocumentAsync(string val)
    {
      bool isOk = await _doc.DeleteDocumentAsync(val);
      return isOk ? (true, "삭제 완료.") : (false, "삭제 실패");
    }

    /// <summary>
    /// 첨부 파일 저장 로직
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ModelOjbect"></param>
    /// <returns></returns>
    public async Task<(bool IsValid, string Message)> FileSaveAsync<T>(T ModelOjbect)
    {
      bool isOk = await _doc.FileSaveAsync<FileModel>(ModelOjbect as FileModel);
      return isOk ? (true, "파일 저장 성공.") : (false, "파일 저장 실패");
    }

    /// <summary>
    /// 첨부 파일 다운로드 로직
    /// </summary>
    /// <returns></returns>
    public async Task<(bool IsValid, string Message, byte[] filedata)> FileDownloadAsync(string filekey)
    {
      (bool isOk, byte[] fileBytes) = await _doc.FileDownloadAsync(filekey);
      return isOk ? (true, "", fileBytes) : (false, "파일 불러오기 실패!", fileBytes);
    }
  }
}
