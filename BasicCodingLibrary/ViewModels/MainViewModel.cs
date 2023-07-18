using BasicCodingLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BasicCodingLibrary.ViewModels;

public class MainViewModel : IMainViewModel
{
    #region ***** Field *****
    private readonly ILogger<MainViewModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly IAppSettingProvider _appSettingProvider;
    #endregion

    #region ***** Property *****
    public string DefaultMessage { get; set; } = "";
    public string ClassName { get; set; } = "MainViewModel (default value)";
    public AppSettingModel AppSetting { get; set; } = new AppSettingModel();
    #endregion

    #region ***** Constructor *****
    public MainViewModel(ILogger<MainViewModel> logger, IConfiguration configuration, IAppSettingProvider appSettingsProvider)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(MainViewModel)}>.");

        _logger = logger;
        _configuration = configuration; // brauche ich wohl nicht, wenn ich alles über AppsettingsProvider lade
        _appSettingProvider = appSettingsProvider;

        //AppSetting = _appSettingProvider.Get();
    }
    #endregion

    #region ***** Interface Member (IMainViewModel) *****
    /// <summary>
    /// This method is getting the current values of <see cref="MainViewModel"/>.
    /// A new snapshot of the file 'appsettings.json' is created.
    /// </summary>
    /// <returns>An instance of class <see cref="MainViewModel"/>.</returns>
    public MainViewModel Get()
    {
        Debug.WriteLine($"Passing <{nameof(Get)}> in <{nameof(MainViewModel)}>.");
        AppSetting = _appSettingProvider.Get();
        return this;
    }
    #endregion
}
