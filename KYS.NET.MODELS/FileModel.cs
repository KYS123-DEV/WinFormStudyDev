using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYS.NET.MODELS
{
  /// <summary>
  /// 첨부파일 DTO
  /// </summary>
  public record FileModelBase
  {
    public string? FileKey { get; init; }
    public byte[]? FileData { get; init; } // DB의 varbinary(max)와 직접 매핑되는 타입
  }

  public record FileModel : FileModelBase
  {
    
    public string? FileNm { get; init; }
    public long? FileSize { get; init; }
    public string? EntryId { get; init; }
    public string? EntryDt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    public FileModel(string fileKey, string fileNm, byte[] fileData, long fileSize, string entryId)
    {
      FileKey = fileKey;
      FileNm = fileNm;
      FileData = fileData;
      FileSize = fileSize;
      EntryId = entryId;
    }

    public override string ToString() {
      return $"FileKey  : {FileKey}\n" +
             $"FileNm   : {FileNm}\n" +
             $"FileData : {FileData}\n" +
             $"FileSize : {FileSize}\n" +
             $"EntryId  : {EntryId}\n" +
             $"EntryDt  : {EntryDt}";
    }
  }
}
