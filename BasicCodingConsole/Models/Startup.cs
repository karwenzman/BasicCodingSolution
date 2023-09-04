using BasicCodingConsole.Providers;
using BasicCodingConsole.Views.MainView;
using Microsoft.Extensions.Logging;

namespace BasicCodingConsole.Models;

/// <summary>
/// This class is providing members to start an application.
/// </summary>
public class Startup : IStartup
{
    private readonly ILogger<Startup> _logger;
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly IMainView _mainView;

    public AppSetting AppSetting { get; set; }

    public Startup(ILogger<Startup> logger, IAppSettingProvider appSettingProvider, IMainView mainView)
    {
        _logger = logger;
        _appSettingProvider = appSettingProvider;
        _mainView = mainView;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(Startup));

        AppSetting = new();
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(Startup), nameof(Run));

        AppSetting = _appSettingProvider.GetAppSetting();

        _mainView.Run();
    }
}
