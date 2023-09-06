using BasicCodingConsole.Models;
using BasicCodingConsole.Providers;
using BasicCodingConsole.Views.MainView;
using BasicCodingConsole.Views.PaperDeliveryContractView;
using BasicCodingConsole.Views.PaperDeliveryStandingDataView;
using BasicCodingConsole.Views.SettingView;
using BasicCodingLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;
using Serilog;
using System.Text;

/// Information about this application's configuration:
/// - using appsettings.json
/// - using appsettings.Production.json
/// - using launchSettings.json
/// - using secrets.json
/// - using command line

Console.OutputEncoding = Encoding.Default; // this is needed to enable the console to print "€" symbol
Console.OutputEncoding = Encoding.UTF8; // this is needed to enable the console to print "€" symbol

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

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddLogging();
        services.Configure<ApplicationSetting>(builder.Build().GetSection("ApplicationSetting"));
        services.Configure<PaperDeliverySetting>(builder.Build().GetSection("PaperDeliverySetting"));
        services.Configure<UserSetting>(builder.Build().GetSection("UserSetting"));
        services.AddTransient<IStartup, Startup>();
        services.AddTransient<IMainView, MainView>();
        services.AddTransient<ISettingView, SettingView>();
        services.AddTransient<IPaperDeliveryStandingDataView, StandingDataView>();
        services.AddTransient<IPaperDeliveryContractView, ContractView>();
        services.AddTransient<IAppSettingProvider, AppSettingProvider>();
        services.AddTransient<IPaperDeliveryProvider, PaperDeliveryProvider>();
    })
    .UseSerilog()
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    Log.Logger.Information("***** Run Application *****");
    Log.Logger.Information($"EnvironmentVariable: if there is no value, then the app is in production mode!");
    Log.Logger.Information($"EnvironmentVariable: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
    Log.Logger.Information($"CommandLineArgument: {builder.Build().GetValue<string>("CommandLineArgument")}");
    services.GetRequiredService<IStartup>().WriteAppSettingToConsole();
    services.GetRequiredService<IStartup>().Run();
}
catch (Exception e)
{
    Log.Logger.Error("Unexpected Exception: {error}", e);

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
