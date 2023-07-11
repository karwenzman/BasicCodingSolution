using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BasicCodingConsole.Views.SettingView;

public class SettingView : ViewBase, ISettingView
{
    private readonly ILogger<SettingView> _logger;
    private readonly IConfiguration _configuration;
    private readonly ISettingViewModel _settingViewModel;

    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="ContentSettingMenu"/>.
    /// </summary>
    public IMenu Menu => new SettingMenu();
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StartingView"/>,
    /// <see cref="EndingView"/> and <see cref="ContinueMessage"/>
    /// </summary>
    public IMessage Message => new SettingMessage();
    /// <summary>
    /// This property is providing standard method used to manipulate the console.
    /// <para></para>
    /// The method's behavior is implemented in the files <see cref="ClearingView"/> and
    /// <see cref="ResizingView"/>.
    /// </summary>
    public IDisplay Display => new SettingDisplay();

    public SettingView(ILogger<SettingView> logger, IConfiguration configuration, ISettingViewModel settingViewModel)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(SettingView)}>.");

        _logger = logger;
        _configuration = configuration;
        _settingViewModel = settingViewModel; // to do
    }

    public void Run()
    {
        Debug.WriteLine($"Passing <{nameof(Run)}> in <{nameof(SettingView)}>.");
        _logger.LogInformation("* Load: {view}", nameof(SettingView));

        Message.Start();
        WriteMenu(Menu.CaptionItems, Menu.MenuItems, Menu.StatusItems);
        WriteContent(); // to do 
        Message.End();
    }

    private void WriteContent()
    {
        string message = "This is individual text by karwenzman!";
        Console.WriteLine(message);
        Console.WriteLine($"\nConnectionString (key = Default): {_configuration.GetConnectionString("Default")}");
    }
}
