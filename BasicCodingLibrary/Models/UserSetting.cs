namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public class UserSetting
{
    #region ***** Property *****
    public string NickName { get; set; } = "default";
    public Person Person { get; set; } = new Person();
    #endregion
}
