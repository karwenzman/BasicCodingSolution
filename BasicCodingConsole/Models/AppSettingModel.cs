using BasicCodingLibrary.Models;
using PaperDeliveryLibrary.Models;

namespace BasicCodingConsole.Models;

/// <summary>
/// This class is providing members to access the <b>appsettings.json</b> file.
/// </summary>
public class AppSettingModel : IAppSettingModel
{
    public ApplicationSetting ApplicationSetting { get; set; } = new ApplicationSetting();
    public PaperDeliverySetting PaperDeliverySetting { get; set; } = new PaperDeliverySetting();
    public UserSetting UserSetting { get; set; } = new UserSetting();
    public string CommandLineArgument { get; set; } = "default";
    public string ConnectionString { get; set; } = "default";
}
