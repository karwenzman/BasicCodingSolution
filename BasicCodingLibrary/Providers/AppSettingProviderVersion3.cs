using BasicCodingLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This class is providing services for instances of <see cref="AppSettingModel"/>.
/// </summary>
public class AppSettingProviderVersion3 : IAppSettingProviderVersion3
{
    private readonly IConfiguration _configuration;

    public UserInformation UserInformation { get; set; }
    public ApplicationInformation ApplicationInformation { get; set; }
    public string CommandLineArgument { get; set; }
    public string ConnectionString { get; set; }

    public AppSettingProviderVersion3(IConfiguration configuration)
    {
        _configuration = configuration;
        CommandLineArgument = _configuration.GetValue<string>("CommandLineArgument")!;
        ConnectionString = _configuration.GetConnectionString("Default")!;
        ApplicationInformation = _configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>()!;
        UserInformation = _configuration.GetSection("UserInformation").Get<UserInformation>()!;
    }
}
