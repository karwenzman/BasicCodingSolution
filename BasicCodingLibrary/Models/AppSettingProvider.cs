using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing services for instances of <see cref="AppSettingModel"/>.
/// </summary>
public class AppSettingProvider : IAppSettingProvider
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<AppSettingProvider> _logger;
    /// <summary>
    /// This field is used to return the fetched data from configuration.
    /// </summary>
    private readonly AppSettingModel appSetting;

    public AppSettingProvider(IConfiguration configuration, ILogger<AppSettingProvider> logger, IOptionsSnapshot<AppSettingModel> optionsSnapshot)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(AppSettingProvider)}>.");
        _configuration = configuration;
        _logger = logger;

        appSetting = optionsSnapshot.Value;
    }

    /// <summary>
    /// This method is getting the current values of <see cref="AppSettingModel"/>.
    /// A new snapshot of the file 'appsettings.json' is created.
    /// </summary>
    /// <returns>An instance of class <see cref="AppSettingModel"/>.</returns>
    public AppSettingModel Get()
    {
        Debug.WriteLine($"Passing <{nameof(Get)}> in <{nameof(AppSettingProvider)}>.");

        // alternative syntax to access configuration files
        //appSetting.ApplicationInformation.Language = _configuration.GetValue<string>("ApplicationInformation:Language")!;
        //appSetting.ApplicationInformation.LastLogin = _configuration.GetValue<string>("ApplicationInformation:LastLogin")!;

        appSetting.CommandLineArgument = _configuration.GetValue<string>("CommandLineArgument")!;
        appSetting.ConnectinString = _configuration.GetConnectionString("Default");
        appSetting.ApplicationInformation = _configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>()!;
        appSetting.UserInformation = _configuration.GetSection("UserInformation").Get<UserInformation>()!;

        // GetSection() will never return null
        //if (_configuration.GetValue<string>("CommandLineArgument") == null || _configuration.GetValue<string>("CommandLineArgument") == string.Empty)
        //{
        //    _logger.LogWarning("CommandLineArgumentIsNullOrEmpty");
        //    appSetting.CommandLineArgument = "none - CommandLineArgumentIsNullOrEmpty";
        //}
        //else
        //{
        //    appSetting.CommandLineArgument = _configuration.GetValue<string>("CommandLineArgument")!;
        //}

        //if (_configuration.GetSection("UserInformation").Get<UserInformation>() == null)
        //{
        //    _logger.LogWarning("UserInformationIsNullOrEmpty");
        //    appSetting.UserInformation = new UserInformation
        //    {
        //        NickName = "none - UserInformationIsNullOrEmpty",
        //        Person = new Person
        //        {
        //            FirstName = "none - UserInformationIsNullOrEmpty",
        //            LastName = "none - UserInformationIsNullOrEmpty",
        //            Gender = 0,
        //            Id = 0,
        //        }
        //    };
        //}
        //else
        //{
        //    appSetting.UserInformation = _configuration.GetSection("UserInformation").Get<UserInformation>()!;
        //}

        //if (_configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>() == null)
        //{
        //    _logger.LogWarning("ApplicationInformationIsNullOrEmpty");
        //    appSetting.ApplicationInformation = new ApplicationInformation
        //    {
        //        Language = "none - ApplicationInformationIsNullOrEmpty",
        //        LastLogin = "none - ApplicationInformationIsNullOrEmpty",
        //        ConsoleHeightMaximum = 0,
        //        ConsoleWidthMaximum = 0,
        //        ConsoleHeightMinimum = 0,
        //        ConsoleWidthMinimum = 0,
        //    };
        //}
        //else
        //{
        //    appSetting.ApplicationInformation = _configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>()!;
        //}

        return appSetting;
    }
}
