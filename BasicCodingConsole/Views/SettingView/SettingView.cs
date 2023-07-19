using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BasicCodingConsole.Views.SettingView;

public class SettingView : ViewBase, ISettingView
{
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly ILogger<SettingView> _logger;

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
    public AppSettingModel AppSetting { get; set; }

    public SettingView(IAppSettingProvider appSettingProvider, ILogger<SettingView> logger)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(SettingView)}>.");
        _appSettingProvider = appSettingProvider;
        _logger = logger;

        AppSetting = _appSettingProvider.Get();
    }

    public void Run()
    {
        Debug.WriteLine($"Passing <{nameof(Run)}> in <{nameof(SettingView)}>.");
        _logger.LogInformation("* Load: {view}", nameof(SettingView));

        Message.Start();
        WriteMenu(Menu);
        WriteContent();
        Message.End();
    }

    /// <summary>
    /// This method is writing the members of <see cref="AppSetting"/> to a console.
    /// </summary>
    private void WriteContent()
    {
        Console.WriteLine($"\nInformation about user <{AppSetting.UserInformation.NickName}>");
        Console.WriteLine($"\tName  : " +
            $"{AppSetting.UserInformation.Person.FirstName} " +
            $"{AppSetting.UserInformation.Person.LastName}");
        Console.WriteLine($"\tGender: " +
            $"{AppSetting.UserInformation.Person.Gender}");
        Console.WriteLine($"\tID    : " +
            $"{AppSetting.UserInformation.Person.Id,4:0000}");

        Console.WriteLine($"\nInformation about app <{nameof(BasicCodingConsole)}>");
        Console.WriteLine($"\tLanguage : {AppSetting.ApplicationInformation.Language}");
        Console.WriteLine($"\tLastLogin: {AppSetting.ApplicationInformation.LastLogin}");
        Console.WriteLine($"\tMaxHeight: {AppSetting.ApplicationInformation.ConsoleHeightMaximum}");
        Console.WriteLine($"\tMinHeight: {AppSetting.ApplicationInformation.ConsoleHeightMinimum}");
        Console.WriteLine($"\tMaxWidth : {AppSetting.ApplicationInformation.ConsoleWidthMaximum}");
        Console.WriteLine($"\tMinWidth : {AppSetting.ApplicationInformation.ConsoleWidthMinimum}");
        Console.WriteLine($"\nInformation about command line arguments");
        Console.WriteLine($"\tArguments: {AppSetting.CommandLineArgument}");
        Console.WriteLine($"\nInformation about connection strings");
        Console.WriteLine($"\tDefault: {AppSetting.ConnectionString}");
    }
}
