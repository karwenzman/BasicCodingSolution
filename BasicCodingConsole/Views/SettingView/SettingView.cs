using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using BasicCodingConsole.Providers;
using Microsoft.Extensions.Logging;

namespace BasicCodingConsole.Views.SettingView;

public class SettingView : ViewBase, ISettingView
{
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly ILogger<SettingView> _logger;

    /// <summary>
    /// This property is providing the information collected from configuration.
    /// </summary>
    public IAppSetting AppSettingModel { get; set; }
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

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(SettingView));

        AppSettingModel = _appSettingProvider.GetAppSetting();
        Menu = new SettingMenu(AppSettingModel);
        Message = new SettingMessage();
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(SettingView), nameof(Run));

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
            $"{AppSettingModel.UserSetting.UserDetails.FirstName} " +
            $"{AppSettingModel.UserSetting.UserDetails.LastName}");
        Console.WriteLine($"\tGender: " +
            $"{AppSettingModel.UserSetting.UserDetails.Gender}");
        Console.WriteLine($"\tID    : " +
            $"{AppSettingModel.UserSetting.UserDetails.Id,4:0000}");

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
