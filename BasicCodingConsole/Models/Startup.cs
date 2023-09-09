﻿using BasicCodingConsole.Providers;
using BasicCodingConsole.Views.MainView;
using BasicCodingLibrary.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperDeliveryLibrary.Models;
using System.Text;

namespace BasicCodingConsole.Models;

/// <summary>
/// This class is providing members to start an application.
/// </summary>
public class Startup : IStartup
{
    private readonly ILogger<Startup> _logger;
    private readonly IOptions<AppSetting> _optionsOfAppSetting;
    private readonly IOptions<ConnectionStrings> _optionsOfConnectionStrings;
    private readonly IOptions<ApplicationSetting> _optionsOfApplicationSetting;
    private readonly IOptions<PaperDeliverySetting> _optionsOfPaperDeliverySetting;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;
    private readonly IOptions<UserSetting> _optionsOfUserSetting;
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly IMainView _mainView;

    public AppSetting AppSetting { get; set; }

    public Startup(
        ILogger<Startup> logger,
        IOptions<AppSetting> optionsOfAppSetting,
        IOptions<ConnectionStrings> optionsOfConnectionStrings,
        IOptions<ApplicationSetting> optionsOfApplicationSetting,
        IOptions<PaperDeliverySetting> optionsOfPaperDeliverySetting,
        IOptions<ConsoleSetting> optionsOfConsoleSetting,
        IOptions<UserSetting> optionsOfUserSetting,
        IAppSettingProvider appSettingProvider, IMainView mainView)
    {
        _logger = logger;
        _optionsOfAppSetting = optionsOfAppSetting;
        _optionsOfConnectionStrings = optionsOfConnectionStrings;
        _optionsOfApplicationSetting = optionsOfApplicationSetting;
        _optionsOfPaperDeliverySetting = optionsOfPaperDeliverySetting;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;
        _optionsOfUserSetting = optionsOfUserSetting;

        _appSettingProvider = appSettingProvider;
        _mainView = mainView;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(Startup));
        AppSetting = new()
        {
            CommandLineArgument = _optionsOfAppSetting.Value.CommandLineArgument,
            ConnectionStrings = _optionsOfConnectionStrings.Value,
            ApplicationSetting = _optionsOfApplicationSetting.Value,
            PaperDeliverySetting = _optionsOfPaperDeliverySetting.Value,
            UserSetting = _optionsOfUserSetting.Value,
        };

        //AppSetting = _optionsOfAppSetting.Value;
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

        Console.WriteLine("".PadLeft(80, '*'));
        Console.WriteLine($"Content of '{nameof(AppSetting)}' reflecting the app's configuration.");
        Console.WriteLine("".PadLeft(80, '*'));

        Console.WriteLine($"DOTNET_ENVIRONMENT's value: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}\n");
        Console.WriteLine(GetUserSetting());
        Console.WriteLine(GetPaperDeliverySetting());
        Console.WriteLine(GetCommandlineArgument());
        Console.WriteLine(GetConnectionString());
        Console.WriteLine(GetConsoleSetting());

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
        builder.AppendLine($"*** {nameof(AppSetting.ConnectionStrings)} ***");
        builder.AppendLine($"\tValue: {AppSetting.ConnectionStrings.Default}");
        return builder;
    }

    private StringBuilder GetConsoleSetting()
    {
        var settings = _optionsOfConsoleSetting.Value;
        var builder = new StringBuilder();
        builder.AppendLine($"*** {nameof(ConsoleSetting)} ***");
        builder.AppendLine($"\t{nameof(settings.BackgroundColor)}: {settings.BackgroundColor}");
        builder.AppendLine($"\t{nameof(settings.ForegroundColor)}: {settings.ForegroundColor}");
        builder.AppendLine($"\t{nameof(settings.HeightMaximum)}: {settings.HeightMaximum}");
        builder.AppendLine($"\t{nameof(settings.HeightMinimum)}: {settings.HeightMinimum}");
        builder.AppendLine($"\t{nameof(settings.WidthMaximum)}: {settings.WidthMaximum}");
        builder.AppendLine($"\t{nameof(settings.WidthMinimum)}: {settings.WidthMinimum}");
        return builder;
    }
}
