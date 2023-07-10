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

    public IMenu Menu => new SettingMenu();
    public IMessage Message => new SettingMessage();
    public IDisplay Display => new ConsoleDisplays.SettingDisplay();

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
        // these methods are now available through all this "interfacing"
        // for each view a individual content and behaviour can be set without touching the main logic here
        // to visualize the differences between MainView and SettingView the text written to console
        // is "app" (in MainView)
        // is "view" (in SettingView)
        // the method's behavior can be altered in e.g. EndingView, StartingView, 
        //Message.Continue();
        //Message.End();
        //Message.Start();
        // the method's behavior can be altered in e.g. ClearingView, ResizingView, 
        //Display.Clear();
        //Display.Resize(0, 0);
        // the properties content can be altered in e.g. ContentSettingMenu, 
        //var menuItems = Menu.MenuItems;
        //var statusItems = Menu.StatusItems;
        //var captionItems = Menu.CaptionItems;
        // the method's behavior can be altered in e.g. BehaviorSettingMenu, 
        //Menu.ShowMenu();

        DrawHeader(Menu.CaptionItems, Menu.MenuItems, Menu.StatusItems); // to do 
        ShowContent(); // to do 

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
