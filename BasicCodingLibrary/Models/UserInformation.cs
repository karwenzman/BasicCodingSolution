namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public class UserInformation
{
    /// <summary>
    /// The user's nickname.
    /// </summary>
    public string NickName { get; set; } = "default";
    /// <summary>
    /// The user's personal information.
    /// </summary>
    public Person Person { get; set; } = new Person();
}
