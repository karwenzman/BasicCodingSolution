namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing members to access the <b>appsettings.json</b> file.
/// </summary>
public class AppSetting
{
    #region ***** Property *****
    public UserSetting UserSetting { get; set; } = new UserSetting();
    public ApplicationSetting ApplicationSetting { get; set; } = new ApplicationSetting();
    #endregion
}
