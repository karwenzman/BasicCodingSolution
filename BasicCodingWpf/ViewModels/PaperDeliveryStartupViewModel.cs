using BasicCodingLibrary.Models;
using BasicCodingWpf.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperDeliveryLibrary.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace BasicCodingWpf.ViewModels;

public partial class PaperDeliveryStartupViewModel : ViewModelBase, IPaperDeliveryStartupViewModel
{
    public CommandBinding CommandBinding_Stop { get; set; }
    public ICommand RelayCommand_ModifyProperty { get; set; }

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
        IOptionsSnapshot<PaperDeliverySetting> optionsOfPaperDeliverySetting,
        IOptionsSnapshot<ApplicationSetting> optionsOfApplicationSetting,
        IOptionsSnapshot<ConnectionStrings> optionsOfConnectionStrings,
        IOptionsSnapshot<UserSetting> optionsOfUserSetting)
    {
        logger.LogInformation("* Loading: {class}", nameof(PaperDeliveryStartupViewModel));

        PaperDeliverySetting = optionsOfPaperDeliverySetting.Value;
        ApplicationSetting = optionsOfApplicationSetting.Value;
        ConnectionStrings = optionsOfConnectionStrings.Value;
        UserSetting = optionsOfUserSetting.Value;

        CommandBinding_Stop = new CommandBinding(ApplicationCommands.Stop, Stop_Executed, Stop_CanExecute);
        RelayCommand_ModifyProperty = new RelayCommand(ModifyProperty_Execute, ModifyProperty_CanExecute);

        DeveloperName = "Thorsten";
        EnvironmentVariable = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

    }

    private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        Application.Current.MainWindow.Close();
    }
    private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }

    private void ModifyProperty_Execute(object? parameter)
    {
        // do something
        counter++;
        DeveloperName = "T.W. Jenning - " + counter;
    }
    private bool ModifyProperty_CanExecute(object? parameter)
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
