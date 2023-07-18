namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing members to access the <b>appsettings.json</b> file.
/// </summary>
public class AppSettingModel
{
    /// <summary>
    /// This property is providing user information received from configuration.
    /// </summary>
    public UserInformation UserInformation { get; set; } = new UserInformation();
    /// <summary>
    /// This property is providing application information received from configuration.
    /// </summary>
    public ApplicationInformation ApplicationInformation { get; set; } = new ApplicationInformation();
    /// <summary>
    /// This property is providing the command line arguments received from configuration.
    /// </summary>
    public string CommandLineArgument { get; set; } = "default";
    /// <summary>
    /// This property is providing the connection string received from configuration.
    /// </summary>
    public string ConnectionString { get; set; } = "default";
}
