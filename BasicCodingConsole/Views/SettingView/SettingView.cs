using BasicCodingConsole.ConsoleMessages;
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

    #region ***** Property *****
    public IMessage StartMessage => new StartingView(nameof(SettingView));
    public IMessage EndMessage => new EndingView(nameof(SettingView));
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

    public void Run()
    {
        ClearView();
        StartMessage.Message();
        ShowView();
        EndMessage.Message();
    }

    public void ShowMenu()
    {
        throw new NotImplementedException();
    }

    public void ShowView()
    {
        Console.WriteLine("This is individual text by karwenzman!");
    }

    #endregion
}
