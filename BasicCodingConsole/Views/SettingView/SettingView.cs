using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BasicCodingConsole.Views.SettingView;

public class SettingView : ISettingView
{
    #region ***** Field *****
    private readonly ILogger<SettingView> _logger;
    private readonly IConfiguration _configuration;
    private readonly ISettingViewModel _settingViewModel;
    #endregion

    #region ***** Constructor *****
    public SettingView(ILogger<SettingView> logger, IConfiguration configuration, ISettingViewModel settingViewModel)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(SettingView)}>.");

        _logger = logger;
        _configuration = configuration;
        _settingViewModel = settingViewModel;
    }
    #endregion

    #region ***** Interface Member (ISettingView) *****
    public string[]? CaptionItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string[]? MenuItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string[]? StatusItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void ArgumentExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }

    public void CaptureUserInput()
    {
        throw new NotImplementedException();
    }

    public void ClearMenu()
    {
        Console.Clear();
    }

    public void ClearView()
    {
        Console.Clear();
    }

    public void EndingAppMessage()
    {
        Console.WriteLine("\nPress ENTER to leave the app...");
        Console.ReadLine();
    }

    public void EndingViewMessage()
    {
        Console.WriteLine("\nPress ENTER to continue...");
        Console.ReadLine();
    }

    public void OverflowExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        ClearView();
        StartingViewMessage();
        ShowView();
        EndingViewMessage();
    }

    public void ShowMenu()
    {
        throw new NotImplementedException();
    }

    public void ShowView()
    {
        Console.WriteLine("This is individual text by karwenzman!");
    }

    public void StartingAppMessage()
    {
        string message = $"You have started the app: {nameof(SettingView)}";
        Console.WriteLine(message);
        Console.WriteLine("=".PadLeft(message.Length, '='));
    }

    public void StartingViewMessage()
    {
        string message = $"You have started the view: {nameof(SettingView)}";
        Console.WriteLine(message);
        Console.WriteLine("=".PadLeft(message.Length, '='));
    }

    public void UnhandledExceptionMessage(Exception e)
    {
        throw new NotImplementedException();
    }
    #endregion
}
