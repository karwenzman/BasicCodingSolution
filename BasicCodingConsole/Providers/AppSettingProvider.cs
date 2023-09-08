using BasicCodingConsole.Models;
using BasicCodingLibrary.Models;
using Microsoft.Extensions.Configuration;
using PaperDeliveryLibrary.Models;

namespace BasicCodingConsole.Providers;

/// <summary>
/// This class is providing services for instances of <see cref="AppSetting"/>.
/// </summary>
public class AppSettingProvider : IAppSettingProvider
{
    private readonly IConfiguration _configuration;

    public AppSettingProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AppSetting GetAppSetting()
    {
        AppSetting output = new()
        {
            CommandLineArgument = _configuration.GetValue<string>("CommandLineArgument")!,
            ConnectionString = _configuration.GetConnectionString("Default")!,
            ApplicationSetting = _configuration.GetSection("ApplicationSetting").Get<ApplicationSetting>()!,
            PaperDeliverySetting = _configuration.GetSection("PaperDeliverySetting").Get<PaperDeliverySetting>()!,
            UserSetting = _configuration.GetSection("UserSetting").Get<UserSetting>()!,
        };

        return output;
    }
}

