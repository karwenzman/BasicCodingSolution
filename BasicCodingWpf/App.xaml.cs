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
    public static IHost? AppHost { get; private set; }

    public App()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.File("LogFiles/apploggings.txt")
            .CreateLogger();

        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddLogging();
                services.AddOptions<ConnectionStrings>().Bind(context.Configuration.GetSection(nameof(ConnectionStrings)));
                services.AddOptions<ApplicationSetting>().Bind(context.Configuration.GetSection(nameof(ApplicationSetting)));
                services.AddOptions<PaperDeliverySetting>().Bind(context.Configuration.GetSection(nameof(PaperDeliverySetting)));
                services.AddOptions<UserSetting>().Bind(context.Configuration.GetSection(nameof(UserSetting)));
                services.AddSingleton<PaperDeliveryStartupView>();
                services.AddTransient<IPaperDeliveryStartupViewModel, PaperDeliveryStartupViewModel>();
            })
            .UseSerilog()
            .Build();

        Log.Logger.Information("***** {namespace} *****", nameof(BasicCodingWpf));
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        try
        {
            var startupForm = AppHost.Services.GetRequiredService<PaperDeliveryStartupView>();
            startupForm.Show();
        }
        catch (Exception ex)
        {
            Log.Logger.Error("Unexpected Exception: {error}", ex);
        }

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();

        base.OnExit(e);
    }
}
