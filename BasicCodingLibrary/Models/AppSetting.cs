namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing members to access the <b>appsettings.json</b> file.
/// </summary>
public class AppSetting
{
    #region ***** Property *****
    public UserInformation UserInformation { get; set; } = new UserInformation();
    public ApplicationInformation ApplicationInformation { get; set; } = new ApplicationInformation();
    #endregion
}
