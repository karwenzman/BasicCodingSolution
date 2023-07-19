using BasicCodingLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace BasicCodingLibrary.Providers;

/// <summary>
/// This class is providing services for instances of <see cref="AppSettingModel"/>.
/// </summary>
public class AppSettingProviderWithGet : IAppSettingProvider
{
    private readonly IConfiguration _configuration;
    /// <summary>
    /// This field is used to return the fetched data from configuration.
    /// </summary>
    private readonly AppSettingModel appSetting;

    public AppSettingProviderWithGet(IConfiguration configuration, IOptionsSnapshot<AppSettingModel> optionsSnapshot)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(AppSettingProviderWithGet)}>.");
        _configuration = configuration;

        // does this make any difference?
        appSetting = optionsSnapshot.Value;
    }

    public UserInformation UserInformation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ApplicationInformation ApplicationInformation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string CommandLineArgument { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    /// <summary>
    /// This method is getting the current values of <see cref="AppSettingModel"/>.
    /// A new snapshot of the file 'appsettings.json' is created.
    /// </summary>
    /// <returns>An instance of class <see cref="AppSettingModel"/>.</returns>
    public AppSettingModel Get()
    {
        Debug.WriteLine($"Passing <{nameof(Get)}> in <{nameof(AppSettingProvider)}>.");

        appSetting.CommandLineArgument = _configuration.GetValue<string>("CommandLineArgument")!;
        appSetting.ConnectionString = _configuration.GetConnectionString("Default")!;
        appSetting.ApplicationInformation = _configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>()!;
        appSetting.UserInformation = _configuration.GetSection("UserInformation").Get<UserInformation>()!;

        return appSetting;
    }
}
