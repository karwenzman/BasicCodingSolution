using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BasicCodingConsole.Views.SettingView;

public class SettingView : ISettingView
{
    private readonly ILogger<SettingView> _logger;
    private readonly IConfiguration _configuration;
    private readonly ISettingViewModel _settingViewModel;

    public IMessageView Message => new MessageView();
    public IDisplay Display => new DisplayView();

    public SettingView(ILogger<SettingView> logger, IConfiguration configuration, ISettingViewModel settingViewModel)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(SettingView)}>.");

        _logger = logger;
        _configuration = configuration;
        _settingViewModel = settingViewModel;
    }

    public void Run()
    {
        Run(Array.Empty<string>());
    }

    public void Run(string[] args)
    {
        Message.Start();
        Display.Clear();
        Display.Resize(0, 0);
        ShowContent();
        Message.Continue();
        Message.End();
    }

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
