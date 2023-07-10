namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing members to access the <b>appsettings.json</b> file.
/// </summary>
public class AppSetting
{
    public UserInformation UserInformation { get; set; } = new UserInformation();
    public ApplicationInformation ApplicationInformation { get; set; } = new ApplicationInformation();
    public string CommandLineArgument { get; set; } = "default";
}
