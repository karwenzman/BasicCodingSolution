using BasicCodingLibrary.Models;
using PaperDeliveryLibrary.Models;

namespace BasicCodingConsole.Models;

/// <summary>
/// This interface is providing members to setup the class <see cref="AppSetting"/>.
/// </summary>
public interface IAppSetting
{
    public ApplicationSetting ApplicationSetting { get; set; }
    public PaperDeliverySetting PaperDeliverySetting { get; set; }
    public UserSetting UserSetting { get; set; }
    public string CommandLineArgument { get; set; }
    public string ConnectionString { get; set; }
}
