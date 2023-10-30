using BasicCodingLibrary.Models;
using BasicCodingWpf.ViewModels;
using BasicCodingWpf.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaperDeliveryLibrary.Models;
using Serilog;
using System;
using System.Windows;

namespace BasicCodingWpf;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e); // nötig???

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File("LogFiles/apploggings.txt")
            .CreateLogger();

        using var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddLogging();
                services.AddOptions<ConnectionStrings>().Bind(context.Configuration.GetSection(nameof(ConnectionStrings)));
                services.AddOptions<ApplicationSetting>().Bind(context.Configuration.GetSection(nameof(ApplicationSetting)));
                services.AddOptions<PaperDeliverySetting>().Bind(context.Configuration.GetSection(nameof(PaperDeliverySetting)));
                services.AddOptions<UserSetting>().Bind(context.Configuration.GetSection(nameof(UserSetting)));
                services.AddTransient<PaperDeliveryStartupView>();
                services.AddTransient<IPaperDeliveryStartupViewModel, PaperDeliveryStartupViewModel>();
            })
            .UseSerilog()
            .Build();

        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            Log.Logger.Information("***** Application {namespace} starting *****", nameof(BasicCodingWpf));
            var paperDeliveryStartupView = services.GetRequiredService<PaperDeliveryStartupView>();
            paperDeliveryStartupView.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error has occurred: {ex.Message}");
            Log.Logger.Error("Unexpected Exception: {error}", ex);
        }
        finally
        {
            Log.Logger.Information("***** Application {namespace} ending *****", nameof(BasicCodingWpf));
        }
    }
}
