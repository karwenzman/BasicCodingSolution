using BasicCodingLibrary.Interfaces;
using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing services for instances of <see cref="AppSetting"/>.
/// </summary>
public class AppSettingProvider : IAppSettingProvider
{
    #region ***** Field *****
    private readonly AppSetting _appSetting;
    private readonly ILogger<MainViewModel> _logger;
    private readonly IConfiguration _configuration;
    #endregion

    #region ***** Constructor *****
    public AppSettingProvider(ILogger<MainViewModel> logger, IConfiguration configuration, IOptionsSnapshot<AppSetting> optionsSnapshot)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(AppSettingProvider)}>.");

        _logger = logger;
        _configuration = configuration;
        _appSetting = optionsSnapshot.Value;
    }
    #endregion

    #region ***** Interface Member (IAppSettingsProvider) *****
    /// <summary>
    /// This method is getting the current values of <see cref="AppSetting"/>.
    /// A new snapshot of the file 'appsettings.json' is created.
    /// </summary>
    /// <returns>An instance of class <see cref="AppSetting"/>.</returns>
    public AppSetting Get()
    {
        Debug.WriteLine($"Passing <{nameof(Get)}> in <{nameof(AppSettingProvider)}>.");

        //_appSetting.ApplicationInformation.Language = _configuration.GetValue<string>("ApplicationInformation:Language")!;
        //_appSetting.ApplicationInformation.LastLogin = _configuration.GetValue<string>("ApplicationInformation:LastLogin")!;

        if (_configuration.GetValue<string>("CommandLineArgument") == null | _configuration.GetValue<string>("CommandLineArgument") == string.Empty)
        {
            _appSetting.CommandLineArgument = "CommandLineArgumentIsNullOrEmpty";
        }
        else
        {
            _appSetting.CommandLineArgument = _configuration.GetValue<string>("CommandLineArgument")!;
        }

        if (_configuration.GetSection("UserInformation").Get<UserInformation>() == null)
        {
            _appSetting.UserInformation = new UserInformation
            {
                NickName = "none - UserInformationIsNullOrEmpty",
                Person = new Person
                {
                    FirstName = "none - UserInformationIsNullOrEmpty",
                    LastName = "none - UserInformationIsNullOrEmpty",
                    Gender = 0,
                    Id = 0,
                }
            };
        }
        else
        {
            _appSetting.UserInformation = _configuration.GetSection("UserInformation").Get<UserInformation>()!;
        }

        if (_configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>() == null)
        {
            _appSetting.ApplicationInformation = new ApplicationInformation
            {
                Language = "none - ApplicationInformationIsNullOrEmpty",
                LastLogin = "none - ApplicationInformationIsNullOrEmpty",
            };
        }
        else
        {
            _appSetting.ApplicationInformation = _configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>()!;
        }

        return _appSetting;
    }
    #endregion
}
