using BasicCodingLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This class is providing services for instances of <see cref="AppSettingModel"/>.
/// </summary>
public class AppSettingProvider : IAppSettingProvider
{
    private readonly IConfiguration _configuration;

    public AppSettingProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// This method is getting the current values from the configuration files.
    /// </summary>
    /// <returns>An instance of class <see cref="AppSettingModel"/> is returned.</returns>
    public AppSettingModel Get()
    {
        AppSettingModel output = new()
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
