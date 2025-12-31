namespace KYS.NET.MODELS
{
  /// <summary>
  /// 데이터 전달용 모델
  /// </summary>
  public record DocumentModel
  {
    public string? DocNo { init; get; } = string.Empty;
    //entryid
    public string? DocTitle { init; get; }
    public string? DocContent { init; get; } = string.Empty;
    public string? DocFilenm { init; get; } = string.Empty;
    public string DocDiv { init; get; } = string.Empty;
    public string? DocComment { init; get; } = string.Empty;
    //entrydt
    //updatedt
    //enddt
  }
}
