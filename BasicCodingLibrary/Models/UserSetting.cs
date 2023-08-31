namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public class UserSetting
{
    /// <summary>
    /// The user's nickname.
    /// </summary>
    public string NickName { get; set; } = "default";
    /// <summary>
    /// The user's personal information.
    /// </summary>
    public UserInformation UserInformation { get; set; } = new UserInformation();
}
