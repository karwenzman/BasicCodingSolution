using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Views.SettingView;
using BasicCodingLibrary.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Diagnostics;

namespace BasicCodingConsole.Views.MainView;

public class MainView : ViewBase, IMainView
{
    #region ***** UI *****
    private readonly string[]? _caption =
    {
        "Main",
    };
    private readonly string[]? _menu =
    {
        "A - Show Application Settings",
        "B - Run FibonacciApp",
        "C - Run SettingView",
        "",
        "",
    };
    private readonly string[]? _status =
    {
        "Select a menu item or press ESC to exit.",
    };
    #endregion

    private readonly ILogger<MainView> _logger;
    private readonly IConfiguration _configuration;
    private readonly IMainViewModel _mainViewModel;
    private readonly IHost _hostProvider;

    public IMenu Menu => new MainMenu();
    public IMessageApp Message => new MessageApp();
    public IDisplay Display => new DisplayApp();

    public MainView(ILogger<MainView> logger, IConfiguration configuration, IMainViewModel mainViewModel, IHost hostProvider)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(MainView)}>.");
        _logger = logger;
        _configuration = configuration;
        _mainViewModel = mainViewModel;
        _hostProvider = hostProvider;
    }

    public void Run(string[] args)
    {
        Debug.WriteLine($"Passing <{nameof(Run)}> in <{nameof(MainView)}>.");
        _logger.LogInformation("* Load: {view}", nameof(MainView));

        Message.Start();
        Display.Clear();
        Display.Resize(0, 0);

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
                    case ConsoleKey.B:
                        CheckWindowSize();
                        Action_B();
                        DrawHeader(_caption, _menu, _status);
                        break;
                    case ConsoleKey.C:
                        CheckWindowSize();
                        Action_C(args);
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
        }

        Message.End();
    }

    #region ***** Private Method (Handling User Input) *****
    /// <summary>
    /// This method starts the logic behind this menu item.
    /// </summary>
    private void Action_A()
    {
        DrawContent();
    }

    /// <summary>
    /// This method starts the logic behind this menu item.
    /// </summary>
    private void Action_B()
    {
        // basics are working; improving needed
        string processName = @"C:\Users\jenni\source\repos\MathSolutions\FibonacciApp\bin\Debug\net7.0\FibonacciApp.exe";
        string processArgs = "";
        //string processArgs = "--CommandLineArgument CommandLineStringIsPassedOnByBasicCodingConsole";

        // get current console state
        ConsoleColor foregroundColor = Console.ForegroundColor;
        ConsoleColor backgroundColor = Console.BackgroundColor;

        ProcessStartInfo startinfo = new ProcessStartInfo(processName, processArgs);

        // Sync
        startinfo.UseShellExecute = false;
        Process p = Process.Start(startinfo)!;
        p.WaitForExit();

        // Async
        //startinfo.UseShellExecute = true;
        //var task = Process.Start(startinfo)!.WaitForExitAsync();
        //if (task.IsCompleted)
        //{
        //    task.Dispose(); // closing the window is not stopping the task, so this is needed!
        //}

        // set saved console state
        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backgroundColor;

    }

    /// <summary>
    /// This method starts the logic behind this menu item.
    /// </summary>
    private void Action_C(string[] args)
    {
        using var scope = _hostProvider.Services.CreateScope();
        var services = scope.ServiceProvider;
        services.GetService<ISettingView>()!.Run();
        //services.GetService<ISettingView>()!.Run(args);
    }
    #endregion

    #region ***** Private Method *****
    private void DrawContent()
    {
        _mainViewModel.Get(); // reloadOnChange? would it make this call unneccessary?

        Console.WriteLine($"TestProperty - Default  : {_configuration.GetConnectionString("Default")}");
        Console.WriteLine($"TestProperty - ClassName: {_mainViewModel.ClassName}");

        Console.WriteLine($"\nInformation about user <{_mainViewModel.AppSetting.UserInformation.NickName}>");
        Console.WriteLine($"\tName  : " +
            $"{_mainViewModel.AppSetting.UserInformation.Person.FirstName} " +
            $"{_mainViewModel.AppSetting.UserInformation.Person.LastName}");
        Console.WriteLine($"\tGender: " +
            $"{_mainViewModel.AppSetting.UserInformation.Person.Gender}");
        Console.WriteLine($"\tID    : " +
            $"{_mainViewModel.AppSetting.UserInformation.Person.Id,4:0000}");

        Console.WriteLine($"\nInformation about app <{nameof(BasicCodingConsole)}>");
        Console.WriteLine($"\tLanguage : {_mainViewModel.AppSetting.ApplicationInformation.Language}");
        Console.WriteLine($"\tLastLogin: {_mainViewModel.AppSetting.ApplicationInformation.LastLogin}");

        Console.WriteLine($"\nInformation about command line arguments");
        Console.WriteLine($"\tArguments: {_mainViewModel.AppSetting.CommandLineArgument}");

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
    }
    #endregion
}
