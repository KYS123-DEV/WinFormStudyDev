namespace KYS.NET.MODELS
{
  /// <summary>
  /// 기본 Model
  /// </summary>
  public record DocumentModelBase
  {
    public string? DocNo { get; set; } = string.Empty;
    public string? DocContent { get; set; } = string.Empty;
    public string? DocDiv { get; set; } = string.Empty;
    public string? DocFilenm { get; set; } = string.Empty;
    public string? DocComment { get; set; } = string.Empty;
  }

  /// <summary>
  /// 조회 결과용 Model
  /// </summary>
  public record DocumentModelForCRUD : DocumentModelBase
  {
    public string? DocTitle { get; set; } = string.Empty;
    public string? EntryId { get; set; } = string.Empty;
    public string? EntryDt { get; set; } = string.Empty;
    public string? UpdateDt { get; set; } = string.Empty;
    public string? EndDt { get; set; } = string.Empty;
  }

  /// <summary>
  /// 조회 조건용 Model
  /// </summary>
  public record DocumentModelForSearch : DocumentModelBase
  {
    public string? DocDtDiv { get; set; } = string.Empty;
    public string? Dt1 { get; set; } = string.Empty;
    public string? Dt2 { get; set; } = string.Empty;
    public string? DocContentDiv { get; set; } = string.Empty;
    public string? DocSearchText { get; set; } = string.Empty;
  }
}
