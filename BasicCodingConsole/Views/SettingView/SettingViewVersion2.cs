using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Logging;

namespace BasicCodingConsole.Views.SettingView;

public class SettingViewVersion2 : ViewBase, ISettingViewVersion2
{
    private readonly IAppSettingProviderVersion2 _appSettingProvider;
    private readonly ILogger<SettingView> _logger;

    /// <summary>
    /// This property is providing the information collected from configuration.
    /// </summary>
    public IAppSettingModel AppSettingModel { get; set; }
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

    public SettingViewVersion2(IAppSettingProviderVersion2 appSettingProvider, ILogger<SettingView> logger)
    {
        // in this version2 there is:
        // - IAppSettingProvider replaced by IAppSettingProviderVersion2
        // - property just have plain getter and setter
        // - _appSettingProvider.Get() is used to feed the property AppSettingModel
        // - the interface ISettingViewVersion2 is including a member of type IAppSettingModel

        _appSettingProvider = appSettingProvider;
        _logger = logger;

        AppSettingModel = new AppSettingModel();
        Display = new SettingDisplay();
        Menu = new SettingMenu();
        Message = new SettingMessage();

        _logger.LogInformation("* Load: {view}", nameof(SettingViewVersion2));
    }

    /// <summary>
    /// This method is getting the current configuration and writing it to a console.
    /// It is public and can be accessed via the dependency injection system.
    /// </summary>
    public void Run()
    {
        AppSettingModel = _appSettingProvider.Get();

        Message.Start(showMessage: false, clearScreen: true);
        WriteMenu(Menu);
        WriteContent();
        Message.End(showMessage: true, clearScreen: true);
    }

    /// <summary>
    /// This method is writing the members of <see cref="AppSettingModel"/> to a console.
    /// </summary>
    private void WriteContent()
    {
        Console.WriteLine($"\nInformation about user <{AppSettingModel.UserInformation.NickName}>");
        Console.WriteLine($"\tName  : " +
            $"{AppSettingModel.UserInformation.Person.FirstName} " +
            $"{AppSettingModel.UserInformation.Person.LastName}");
        Console.WriteLine($"\tGender: " +
            $"{AppSettingModel.UserInformation.Person.Gender}");
        Console.WriteLine($"\tID    : " +
            $"{AppSettingModel.UserInformation.Person.Id,4:0000}");

        Console.WriteLine($"\nInformation about app <{nameof(BasicCodingConsole)}>");
        Console.WriteLine($"\tLanguage : {AppSettingModel.ApplicationInformation.Language}");
        Console.WriteLine($"\tLastLogin: {AppSettingModel.ApplicationInformation.LastLogin}");
        Console.WriteLine($"\tMaxHeight: {AppSettingModel.ApplicationInformation.ConsoleHeightMaximum}");
        Console.WriteLine($"\tMinHeight: {AppSettingModel.ApplicationInformation.ConsoleHeightMinimum}");
        Console.WriteLine($"\tMaxWidth : {AppSettingModel.ApplicationInformation.ConsoleWidthMaximum}");
        Console.WriteLine($"\tMinWidth : {AppSettingModel.ApplicationInformation.ConsoleWidthMinimum}");
        Console.WriteLine($"\nInformation about command line arguments");
        Console.WriteLine($"\tArguments: {AppSettingModel.CommandLineArgument}");
        Console.WriteLine($"\nInformation about connection strings");
        Console.WriteLine($"\tDefault: {AppSettingModel.ConnectionString}");
    }
}
