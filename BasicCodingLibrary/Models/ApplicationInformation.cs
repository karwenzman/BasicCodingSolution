namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public class ApplicationInformation
{
    #region ***** Property *****
    public string LastLogin { get; set; } = "default";
    public string Language { get; set; } = "default";
    #endregion
}
