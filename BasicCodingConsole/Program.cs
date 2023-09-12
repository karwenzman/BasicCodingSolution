using BasicCodingConsole.Models;
using BasicCodingConsole.Views.MainView;
using BasicCodingConsole.Views.PaperDeliveryContractView;
using BasicCodingConsole.Views.PaperDeliveryStandingDataView;
using BasicCodingConsole.Views.PaperDeliveryView;
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

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.File("LogFiles/apploggings.txt")
    .CreateLogger();

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddLogging();
        services.AddOptions<AppSetting>().Bind(context.Configuration.GetSection(nameof(AppSetting)));
        services.AddOptions<ConnectionStrings>().Bind(context.Configuration.GetSection(nameof(ConnectionStrings)));
        services.AddOptions<ApplicationSetting>().Bind(context.Configuration.GetSection(nameof(ApplicationSetting)));
        services.AddOptions<PaperDeliverySetting>().Bind(context.Configuration.GetSection(nameof(PaperDeliverySetting)));
        services.AddOptions<ConsoleSetting>().Bind(context.Configuration.GetSection(nameof(ConsoleSetting)));
        services.AddOptions<UserSetting>().Bind(context.Configuration.GetSection(nameof(UserSetting)));
        services.AddTransient<IStartup, Startup>();
        services.AddTransient<IMainView, MainView>();
        services.AddTransient<ISettingView, SettingView>();
        services.AddTransient<IPaperDeliveryView, PaperDeliveryView>();
        services.AddTransient<IPaperDeliveryStandingDataView, StandingDataView>();
        services.AddTransient<IPaperDeliveryContractView, ContractView>();
        services.AddTransient<IPaperDeliveryProvider, PaperDeliveryProvider>();
    })
    .UseSerilog()
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    Log.Logger.Information("***** Run Application *****");
    services.GetRequiredService<IStartup>().WriteSettingsToConsole();
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
