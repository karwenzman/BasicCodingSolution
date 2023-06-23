using BasicCodingConsole.Interfaces;
using BasicCodingLibrary.Interfaces;
using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Diagnostics;

namespace BasicCodingConsole.Views;

internal class MainView : ViewBase, IMainView
{
    #region ***** UI *****
    private readonly string[]? _caption =
    {
        "Main",
    };
    private readonly string[]? _menu =
    {
        "A - Show Content of File <appsettings.json>",
        "",
        "",
    };
    private readonly string[]? _status =
    {
        "Select a menu item or press ESC to exit.",
    };
    #endregion

    #region ***** Field *****
    private readonly ILogger<MainView> _logger;
    private readonly IConfiguration _configuration;
    private readonly IMainViewModel _mainViewModel;
    #endregion

    #region ***** Property *****
    public MainViewModel MainViewModel { get; set; }
    #endregion

    #region ***** Constructor *****
    public MainView(ILogger<MainView> logger, IConfiguration configuration, IMainViewModel mainViewModel)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(MainView)}>.");

        _logger = logger;
        _configuration = configuration;
        _mainViewModel = mainViewModel;

        MainViewModel = _mainViewModel.Get();
    }
    #endregion

    #region ***** Interface Member (IMainView) *****
    public void Run(string[] args)
    {
        Debug.WriteLine($"Passing <{nameof(Run)}> in <{nameof(MainView)}>.");

        _logger.LogInformation("* Load: {view}", nameof(MainView));
        DrawHeader(_caption, _menu, _status);

        try
        {
            bool exitApp = false;
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        exitApp = true;
                        break;
                    case ConsoleKey.A:
                        CheckWindowSize();
                        Action_A();
                        DrawHeader(_caption, _menu, _status);
                        break;
                    default:
                        Console.Beep();
                        break;
                }
            } while (!exitApp);
        }
        catch (Exception e)
        {
            Log.Logger.Error("Unexpected Exception!", e);
            Console.WriteLine("Unexpected Exception!");
            Console.WriteLine(e);
            DrawFooter();
        }
    }
    #endregion

    #region ***** Private Method (Handling User Input) *****
    /// <summary>
    /// This method starts the logic behind this menu item.
    /// </summary>
    private void Action_A()
    {
        DrawContent();
    }
    #endregion

    #region ***** Private Method *****
    private void DrawContent()
    {
        MainViewModel = _mainViewModel.Get();

        Console.WriteLine($"MainView - Default   : {_configuration.GetConnectionString("Default")}");
        Console.WriteLine($"MainView - ClassName : {MainViewModel.ClassName}");

        Console.WriteLine($"\nInformation about user <{MainViewModel.AppSetting.UserInformation.NickName}>");
        Console.WriteLine($"\tName  : " +
            $"{MainViewModel.AppSetting.UserInformation.Person.FirstName} " +
            $"{MainViewModel.AppSetting.UserInformation.Person.LastName}");
        Console.WriteLine($"\tGender: " +
            $"{MainViewModel.AppSetting.UserInformation.Person.Gender}");
        Console.WriteLine($"\tID    : " +
            $"{MainViewModel.AppSetting.UserInformation.Person.Id,4:0000}");

        Console.WriteLine($"\nInformation about app <{nameof(BasicCodingConsole)}>");
        Console.WriteLine($"\tMainView - Language  : {MainViewModel.AppSetting.ApplicationInformation.Language}");
        Console.WriteLine($"\tMainView - LastLogin : {MainViewModel.AppSetting.ApplicationInformation.LastLogin}");

        #region ***** Testing to write a file *****
        //Console.WriteLine("Creating a json file");
        //try
        //{
        //    var options = new JsonSerializerOptions { WriteIndented = true };
        //    var jsonString = JsonSerializer.Serialize(new AppSettings(), options);
        //    //var jsonString = JsonSerializer.Serialize(new { AppSettings = new AppSettings() }, options);
        //    File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestFile.json"), jsonString);
        //}
        //catch (Exception e)
        //{
        //    Debug.WriteLine($"Exception!");
        //    Debug.WriteLine(e.ToString());
        //}
        //Console.WriteLine(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestFile.json")));
        #endregion

        DrawFooter();
    }
    #endregion
}
