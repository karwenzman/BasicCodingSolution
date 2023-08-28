namespace BasicCodingLibrary.Models;

/// <summary>
/// This interface is providing members to setup the class <see cref="AppSettingModel"/>.
/// </summary>
public interface IAppSettingModel
{
    public ApplicationInformation ApplicationInformation { get; set; }
    public PaperDeliverySetting PaperDeliverySetting { get; set; }
    public UserInformation UserInformation { get; set; }
    public string CommandLineArgument { get; set; }
    public string ConnectionString { get; set; }
}
