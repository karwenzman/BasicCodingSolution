using BasicCodingLibrary.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperDeliveryLibrary.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace BasicCodingWpf.ViewModels;

[ObservableObject]
public partial class PaperDeliveryStartupViewModel : ViewModelBase, IPaperDeliveryStartupViewModel
{
    public CommandBinding StopCommand { get; set; }

    int counter = 0;

    [ObservableProperty]
    private string? _EnvironmentVariable;
    [ObservableProperty]
    private string _DeveloperName;
    [ObservableProperty]
    private PaperDeliverySetting _PaperDeliverySetting;
    [ObservableProperty]
    private UserSetting _UserSetting;
    [ObservableProperty]
    private ApplicationSetting _ApplicationSetting;
    [ObservableProperty]
    private ConnectionStrings _ConnectionStrings;

    public PaperDeliveryStartupViewModel(
        ILogger<PaperDeliveryStartupViewModel> logger,
        IOptions<PaperDeliverySetting> optionsOfPaperDeliverySetting,
        IOptions<ApplicationSetting> optionsOfApplicationSetting,
        IOptions<ConnectionStrings> optionsOfConnectionStrings,
        IOptions<UserSetting> optionsOfUserSetting)
    {
        logger.LogInformation("* Loading: {class}", nameof(PaperDeliveryStartupViewModel));

        PaperDeliverySetting = optionsOfPaperDeliverySetting.Value;
        ApplicationSetting = optionsOfApplicationSetting.Value;
        ConnectionStrings = optionsOfConnectionStrings.Value;
        UserSetting = optionsOfUserSetting.Value;

        StopCommand = new CommandBinding(ApplicationCommands.Stop, Stop, CanStop);

        DeveloperName = "Thorsten";
        EnvironmentVariable = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

    }

    private void Stop(object sender, ExecutedRoutedEventArgs e)
    {
        Application.Current.MainWindow.Close();
    }
    private void CanStop(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }

    [RelayCommand(CanExecute = nameof(CanModifyProperty))]
    private void ModifyProperty(object? parameter)
    {
        // do something
        counter++;
        DeveloperName = "T.W. Jenning - " + counter;
    }
    private bool CanModifyProperty(object? parameter)
    {
        return true;
    }

    public void PaperDeliveryStartupView_Closing(object? sender, CancelEventArgs e)
    {
        MessageBoxResult messageBoxResult = MessageBox.Show(
            "Soll das Fenster geschlossen werden?",
            $"{nameof(PaperDeliveryStartupView_Closing)}",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question,
            MessageBoxResult.No);

        if (messageBoxResult == MessageBoxResult.No)
        {
            e.Cancel = true;
        }
    }

}
