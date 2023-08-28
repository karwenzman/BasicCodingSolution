using BasicCodingConsole.Views;
using BasicCodingConsole.Views.MainView;
using BasicCodingConsole.Views.PaperDeliveryContractView;
using BasicCodingConsole.Views.SettingView;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaperDeliveryLibrary.Providers;
using Serilog;
using System.Text;

Console.OutputEncoding = Encoding.Default; // this is set to enable the console to print "€" symbol
Console.OutputEncoding = Encoding.UTF8; // this is set to enable the console to print "€" symbol

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.File("LogFiles/apploggings.txt")
    .CreateLogger();

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddLogging();
        services.Configure<ApplicationInformation>(builder.Build().GetSection("ApplicationInformation"));
        services.Configure<PaperDeliverySetting>(builder.Build().GetSection("PaperDeliverySetting"));
        services.Configure<UserInformation>(builder.Build().GetSection("UserInformation"));
        services.AddTransient<IMainView, MainView>();
        services.AddTransient<ISettingView, SettingView>();
        services.AddTransient<IPaperDeliveryContractView, ContractView>();
        services.AddTransient<IAppSettingProvider, AppSettingProvider>();
        services.AddTransient<IPaperDeliveryProvider, PaperDeliveryProvider>();
    })
    .UseSerilog()
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

//var configurations = scope.ServiceProvider.GetRequiredService<IConfiguration>(); // for testing only
//ShowEnvironmentValues(args, builder, configurations); // for testing only

try
{
    Log.Logger.Information("***** Run Application *****");
    Log.Logger.Information($"EnvironmentVariable: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
    Log.Logger.Information($"CommandLineArgument: {builder.Build().GetValue<string>("CommandLineArgument")}");
    services.GetRequiredService<IMainView>().Run();
}
catch (Exception e)
{
    Log.Logger.Error("Unexpected Exception!", e);
    Console.WriteLine("Unexpected Exception!");
    Console.WriteLine(e);
    Console.WriteLine($"\n***** Press ENTER To Continue *****");
    Console.ReadLine();
}
finally
{
    Log.Logger.Information("***** End Application *****");
}

#if DEBUG
Console.Clear();
Console.WriteLine($"\n***** End Of Debug Mode - Press ENTER To Close The Window *****");
Console.ReadLine();
#endif




static void ShowEnvironmentValues(string[] args, IConfigurationBuilder builder, IConfiguration configuration)
{
    // other values
    Console.WriteLine($"EnvironmentVariable: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
    Console.WriteLine($"CommandLineArgument: {builder.Build().GetValue<string>("CommandLineArgument")}");

    // args
    if (args.Length > 0)
    {
        foreach (var item in args)
        {
            Log.Logger.Information($"Args: {item}");
            Console.WriteLine($"Args: {item}");
        }
    }
    else
    {
        Console.WriteLine("No Args provided.");
    }

    // appSetting
    var appSetting = new AppSettingModel();
    if (configuration.GetSection("UserInformation").Get<UserInformation>() == null)
    {
        appSetting.UserInformation = new UserInformation
        {
            NickName = "none - UserInformationIsNullOrEmpty",
            Person = new Person
            {
                FirstName = "none - UserInformationIsNullOrEmpty",
                LastName = "none - UserInformationIsNullOrEmpty",
                Gender = 0,
                Id = 0,
            }
        };
    }
    else
    {
        appSetting.UserInformation = configuration.GetSection("UserInformation").Get<UserInformation>()!;
    }

    if (configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>() == null)
    {
        appSetting.ApplicationInformation = new ApplicationInformation
        {
            Language = "none - ApplicationInformationIsNullOrEmpty",
            LastLogin = "none - ApplicationInformationIsNullOrEmpty",
            ConsoleHeightMaximum = 0,
            ConsoleWidthMaximum = 0,
            ConsoleHeightMinimum = 0,
            ConsoleWidthMinimum = 0,
        };
    }
    else
    {
        appSetting.ApplicationInformation = configuration.GetSection("ApplicationInformation").Get<ApplicationInformation>()!;
    }

    Console.WriteLine($"MaxHeight: {appSetting.ApplicationInformation.ConsoleHeightMaximum}");
    Console.WriteLine($"MinHeight: {appSetting.ApplicationInformation.ConsoleHeightMinimum}");
    Console.WriteLine($"MaxWidth : {appSetting.ApplicationInformation.ConsoleWidthMaximum}");
    Console.WriteLine($"MinWidth : {appSetting.ApplicationInformation.ConsoleWidthMinimum}");

    Console.ReadLine();
}