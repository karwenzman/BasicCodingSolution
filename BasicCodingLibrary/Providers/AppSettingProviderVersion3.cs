using BasicCodingLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This class is providing services for instances of <see cref="AppSettingModel"/>.
/// </summary>
public class AppSettingProviderVersion3 : IAppSettingProviderVersion3
{
    private readonly IConfiguration _configuration;

    public AppSettingProviderVersion3(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// This method is getting the current values from the configuration files.
    /// </summary>
    /// <returns>An instance of class <see cref="AppSettingModel"/> is returned.</returns>
    public AppSettingModel Get()
    {
        AppSettingModel output = new AppSettingModel();

        output.CommandLineArgument = _configuration.GetValue<string>("CommandLineArgument")!;
        output.ConnectionString = _configuration.GetConnectionString("Default")!;
        output.ApplicationInformation = _configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>()!;
        output.UserInformation = _configuration.GetSection("UserInformation").Get<UserInformation>()!;

        return output;
    }
}
