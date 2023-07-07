using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.ConsoleViews;
using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BasicCodingConsole.Views.SettingView;

public class SettingView : ISettingView
{
    #region ***** Field *****
    private readonly ILogger<SettingView> _logger;
    private readonly IConfiguration _configuration;
    private readonly ISettingViewModel _settingViewModel;
    #endregion

    #region ***** Property *****
    public IMessaging StartMessage => new StartingView(nameof(SettingView));
    public IMessaging EndMessage => new EndingView(nameof(SettingView));
    public IView Display => new View();
    #endregion

    #region ***** Constructor *****
    public SettingView(ILogger<SettingView> logger, IConfiguration configuration, ISettingViewModel settingViewModel)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(SettingView)}>.");

        _logger = logger;
        _configuration = configuration;
        _settingViewModel = settingViewModel;
    }
    #endregion

    #region ***** Interface Member (ISettingView) *****
    public void Run()
    {
        Display.Clear();
        Display.Resize(0, 0);
        StartMessage.Show();
        ShowContent();
        EndMessage.Show();
    }
    #endregion

    #region ***** Private Member *****
    private void ShowContent()
    {
        string message = "This is individual text by karwenzman!";
        Console.WriteLine(message);
        _logger.LogInformation(message);

        Console.WriteLine($"\nConnectionString (key = Default): {_configuration.GetConnectionString("Default")}");
    }
    #endregion
}
