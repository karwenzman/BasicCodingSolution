namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing members to access the <b>appsettings.json</b> file.
/// </summary>
public class AppSettingModel : IAppSettingModel
{
    public ApplicationInformation ApplicationInformation { get; set; } = new ApplicationInformation();
    public PaperDeliverySetting PaperDeliverySetting { get; set; } = new PaperDeliverySetting();
    public UserInformation UserInformation { get; set; } = new UserInformation();
    public string CommandLineArgument { get; set; } = "default";
    public string ConnectionString { get; set; } = "default";
}
