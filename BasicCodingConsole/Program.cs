using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Views.MainView;
using BasicCodingConsole.Views.SettingView;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

#region ***** Configuration *****
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    //.WriteTo.Console()  // activate to send the logging to the console
    .WriteTo.File("LogFiles/apploggings.txt") // activate to send the logging to a file
    .CreateLogger();
var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddLogging();
        services.Configure<UserInformation>(builder.Build().GetSection("UserInformation"));
        services.Configure<ApplicationInformation>(builder.Build().GetSection("ApplicationInformation"));
        services.AddTransient<IMainView, MainView>();
        services.AddTransient<IMainViewModel, MainViewModel>();
        services.AddTransient<IMainViewMessage, MainViewMessage>();
        services.AddTransient<IAppSettingProvider, AppSettingProvider>();
        services.AddTransient<ISettingView, SettingView>();
        services.AddTransient<ISettingViewModel, SettingViewModel>();
    })
    .UseSerilog()
    .Build();

var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
#endregion

#region ***** Run *****
try
{
    Log.Logger.Information("***** Run Application *****");
    Log.Logger.Information($"EnvironmentVariable: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
    Console.WriteLine($"EnvironmentVariable: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
    Log.Logger.Information($"CommandLineArgument: {builder.Build().GetValue<string>("CommandLineArgument")}");
    Console.WriteLine($"CommandLineArgument: {builder.Build().GetValue<string>("CommandLineArgument")}");
    foreach (var item in args)
    {
        Log.Logger.Information($"Args: {item}");
        Console.WriteLine($"Args: {item}");
    }
    Console.ReadLine();
    services.GetService<IMainView>()!
        .Run(args);
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

#if DEBUG
    Console.Clear();
    Console.WriteLine($"\n***** End Of Debug Mode - Press ENTER To Close The Window *****");
    Console.ReadLine();
#endif
}
#endregion
