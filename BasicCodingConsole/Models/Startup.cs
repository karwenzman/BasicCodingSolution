using BasicCodingConsole.Providers;
using BasicCodingConsole.Views.MainView;
using Microsoft.Extensions.Logging;
using System.Text;

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

    public void WriteAppSettingToConsole()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(Startup), nameof(WriteAppSettingToConsole));

        AppSetting = _appSettingProvider.GetAppSetting();

        Console.WriteLine("".PadLeft(80, '*'));
        Console.WriteLine($"Content of '{nameof(AppSetting)}' reflecting the app's configuration.");
        Console.WriteLine("".PadLeft(80, '*'));

        Console.WriteLine(GetUserSetting());
        Console.WriteLine(GetPaperDeliverySetting());
        Console.WriteLine(GetCommandlineArgument());
        Console.WriteLine(GetConnectionString());

        Console.WriteLine($"\nPress ENTER to continue...");
        Console.ReadLine();
    }

    private StringBuilder GetPaperDeliverySetting()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"*** {nameof(AppSetting.PaperDeliverySetting)} ***");
        builder.AppendLine("\tFiles:");
        builder.AppendLine($"\t- Client.....: {AppSetting.PaperDeliverySetting.ClientFile}");
        builder.AppendLine($"\t- Contract...: {AppSetting.PaperDeliverySetting.ContractFile}");
        builder.AppendLine($"\t- Contractor.: {AppSetting.PaperDeliverySetting.ContractorFile}");
        builder.AppendLine($"\t- Fulfillment: {AppSetting.PaperDeliverySetting.FulfillmentFile}");
        builder.AppendLine($"\tPath: {AppSetting.PaperDeliverySetting.PaperDeliveryDirectory}");
        return builder;
    }

    private StringBuilder GetUserSetting()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"*** {nameof(AppSetting.UserSetting)} ***");
        builder.AppendLine($"\tNickname: {AppSetting.UserSetting.NickName}");
        builder.AppendLine($"\tFirsname: {AppSetting.UserSetting.UserDetails.FirstName}");
        builder.AppendLine($"\tLastname: {AppSetting.UserSetting.UserDetails.LastName}");
        builder.AppendLine($"\tGender..: {AppSetting.UserSetting.UserDetails.Gender}");
        builder.AppendLine($"\tUser-ID.: {AppSetting.UserSetting.UserDetails.Id}");
        return builder;
    }

    private StringBuilder GetCommandlineArgument()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"*** {nameof(AppSetting.CommandLineArgument)} ***");
        builder.AppendLine($"\tValue: {AppSetting.CommandLineArgument}");
        return builder;
    }

    private StringBuilder GetConnectionString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"*** {nameof(AppSetting.ConnectionString)} ***");
        builder.AppendLine($"\tValue: {AppSetting.ConnectionString}");
        return builder;
    }
}
