using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BasicCodingConsole.Views.SettingView;

public class SettingViewWithConstructorInjection : ViewBase, ISettingView
{
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly ILogger<SettingViewWithConstructorInjection> _logger;

    /// <summary>
    /// This property is providing standard method used to manipulate the console.
    /// <para></para>
    /// The method's behavior is implemented in the files <see cref="ClearingView"/> and
    /// <see cref="ResizingView"/>.
    /// </summary>
    public IDisplay Display { get; set; }
    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="ContentSettingMenu"/>.
    /// </summary>
    public IMenu Menu { get; set; }
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StartingView"/>,
    /// <see cref="EndingView"/> and <see cref="ContinueMessage"/>
    /// </summary>
    public IMessage Message { get; set; }

    public SettingViewWithConstructorInjection(IAppSettingProvider appSettingProvider, ILogger<SettingViewWithConstructorInjection> logger)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(SettingViewWithConstructorInjection)}>.");
        _appSettingProvider = appSettingProvider;
        _logger = logger;

        Display = new SettingDisplay();
        Menu = new SettingMenu();
        Message = new SettingMessage();
    }

    public void Run()
    {
        Debug.WriteLine($"Passing <{nameof(Run)}> in <{nameof(SettingViewWithConstructorInjection)}>.");
        _logger.LogInformation("* Load: {view}", nameof(SettingViewWithConstructorInjection));

        Message.Start();
        WriteMenu(Menu);
        WriteContent();
        Message.End();
    }

    /// <summary>
    /// This method is writing the members of <see cref="IAppSettingProvider"/> to a console.
    /// </summary>
    private void WriteContent()
    {
        Console.WriteLine($"\nInformation about user <{_appSettingProvider.UserInformation.NickName}>");
        Console.WriteLine($"\tName  : " +
            $"{_appSettingProvider.UserInformation.Person.FirstName} " +
            $"{_appSettingProvider.UserInformation.Person.LastName}");
        Console.WriteLine($"\tGender: " +
            $"{_appSettingProvider.UserInformation.Person.Gender}");
        Console.WriteLine($"\tID    : " +
            $"{_appSettingProvider.UserInformation.Person.Id,4:0000}");

        Console.WriteLine($"\nInformation about app <{nameof(BasicCodingConsole)}>");
        Console.WriteLine($"\tLanguage : {_appSettingProvider.ApplicationInformation.Language}");
        Console.WriteLine($"\tLastLogin: {_appSettingProvider.ApplicationInformation.LastLogin}");
        Console.WriteLine($"\tMaxHeight: {_appSettingProvider.ApplicationInformation.ConsoleHeightMaximum}");
        Console.WriteLine($"\tMinHeight: {_appSettingProvider.ApplicationInformation.ConsoleHeightMinimum}");
        Console.WriteLine($"\tMaxWidth : {_appSettingProvider.ApplicationInformation.ConsoleWidthMaximum}");
        Console.WriteLine($"\tMinWidth : {_appSettingProvider.ApplicationInformation.ConsoleWidthMinimum}");
        Console.WriteLine($"\nInformation about command line arguments");
        Console.WriteLine($"\tArguments: {_appSettingProvider.CommandLineArgument}");
        Console.WriteLine($"\nInformation about connection strings");
        Console.WriteLine($"\tDefault: {_appSettingProvider.ConnectionString}");
    }
}
