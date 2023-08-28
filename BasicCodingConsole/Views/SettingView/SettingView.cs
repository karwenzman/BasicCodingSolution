using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Logging;

namespace BasicCodingConsole.Views.SettingView;

public class SettingView : ViewBase, ISettingView
{
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly ILogger<SettingView> _logger;

    /// <summary>
    /// This property is providing the information collected from configuration.
    /// </summary>
    public IAppSettingModel AppSettingModel { get; set; }
    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="SettingMenuContent"/>.
    /// </summary>
    public IMenu Menu { get; set; }
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StandardMessageEnd"/>,
    /// <see cref="StandardMessageStart"/> and <see cref="StandardMessageContinue"/>
    /// </summary>
    public IMessage Message { get; set; }

    public SettingView(IAppSettingProvider appSettingProvider, ILogger<SettingView> logger)
    {
        _appSettingProvider = appSettingProvider;
        _logger = logger;

        AppSettingModel = _appSettingProvider.Get();
        Menu = new SettingMenu(AppSettingModel);
        Message = new SettingMessage();

        _logger.LogInformation("* Load: {view}", nameof(SettingView));
    }

    public void Run()
    {
        WriteMenu(Menu);
        WriteContent();
        Message.Continue(showMessage: true, clearScreen: true);
    }

    /// <summary>
    /// This method is writing the members of <see cref="AppSettingModel"/> to a console.
    /// </summary>
    private void WriteContent()
    {
        Console.WriteLine($"\nInformation about user <{AppSettingModel.UserSetting.NickName}>");
        Console.WriteLine($"\tName  : " +
            $"{AppSettingModel.UserSetting.Person.FirstName} " +
            $"{AppSettingModel.UserSetting.Person.LastName}");
        Console.WriteLine($"\tGender: " +
            $"{AppSettingModel.UserSetting.Person.Gender}");
        Console.WriteLine($"\tID    : " +
            $"{AppSettingModel.UserSetting.Person.Id,4:0000}");

        Console.WriteLine($"\nInformation about app <{nameof(BasicCodingConsole)}>");
        Console.WriteLine($"\tLanguage : {AppSettingModel.ApplicationSetting.Language}");
        Console.WriteLine($"\tLastLogin: {AppSettingModel.ApplicationSetting.LastLogin}");
        Console.WriteLine($"\tMaxHeight: {AppSettingModel.ApplicationSetting.ConsoleHeightMaximum}");
        Console.WriteLine($"\tMinHeight: {AppSettingModel.ApplicationSetting.ConsoleHeightMinimum}");
        Console.WriteLine($"\tMaxWidth : {AppSettingModel.ApplicationSetting.ConsoleWidthMaximum}");
        Console.WriteLine($"\tMinWidth : {AppSettingModel.ApplicationSetting.ConsoleWidthMinimum}");
        Console.WriteLine($"\nInformation about command line arguments");
        Console.WriteLine($"\tArguments: {AppSettingModel.CommandLineArgument}");
        Console.WriteLine($"\nInformation about connection strings");
        Console.WriteLine($"\tDefault: {AppSettingModel.ConnectionString}");

    }
}
