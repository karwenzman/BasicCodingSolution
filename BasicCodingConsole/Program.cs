using BasicCodingConsole.Views.MainView;
using BasicCodingConsole.Views.SettingView;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.File("LogFiles/apploggings.txt")
    .CreateLogger();
var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddLogging();
        services.Configure<UserInformation>(builder.Build().GetSection("UserInformation"));
        services.Configure<ApplicationInformation>(builder.Build().GetSection("ApplicationInformation"));
        services.AddTransient<IMainView, MainView>();
        services.AddTransient<IMainViewModel, MainViewModel>();
        services.AddTransient<IAppSettingProvider, AppSettingProvider>();
        services.AddTransient<ISettingView, SettingView>();
        services.AddTransient<ISettingViewModel, SettingViewModel>();
    })
    .UseSerilog()
    .Build();

//ShowEnvironmentValues(args, builder); // for testing only

var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    Log.Logger.Information("***** Run Application *****");
    Log.Logger.Information($"EnvironmentVariable: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
    Log.Logger.Information($"CommandLineArgument: {builder.Build().GetValue<string>("CommandLineArgument")}");
    services.GetService<IMainView>()!
    .Run();
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




static void ShowEnvironmentValues(string[] args, ConfigurationBuilder builder)
{
    Console.WriteLine($"EnvironmentVariable: {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}");
    Console.WriteLine($"CommandLineArgument: {builder.Build().GetValue<string>("CommandLineArgument")}");

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
    Console.ReadLine();
}