namespace KYS.NET.MODELS
{
  /// <summary>
  /// 데이터 전달용 모델
  /// </summary>
  public record DocumentModel
  {
    public string? DocNo { init; get; } = string.Empty;
    public string? EntryId { init; get; } = string.Empty;
    public string? DocTitle { init; get; } = string.Empty;
    public string? DocContent { init; get; } = string.Empty;
    public string? DocFilenm { init; get; } = string.Empty;
    public string? DocDiv { init; get; } = string.Empty;
    public string? DocContentDiv { init; get; } = string.Empty;
    public string? DocDtDiv { init; get; } = string.Empty;
    public string? DocComment { init; get; } = string.Empty;
    public string? Entrydt { init; get; } = string.Empty;
    public string? Updatedt { init; get; } = string.Empty;
    public string? Enddt { init; get; } = string.Empty;
    public string? Dt1 { init; get; } = string.Empty;
    public string? Dt2 { init; get; } = string.Empty;
    public string? DocSearchText { init; get; } = string.Empty;
  }

  /// <summary>
  /// 조회 조건용 Model
  /// </summary>
  public record DocumentModelForSearch
  {
    public string? DocDtDiv { init; get; } = string.Empty;
    public string? DocContentDiv { init; get; } = string.Empty;
    public string? Dt1 { init; get; } = string.Empty;
    public string? Dt2 { init; get; } = string.Empty;
    public string? DocSearchText { init; get; } = string.Empty;
  }
}
