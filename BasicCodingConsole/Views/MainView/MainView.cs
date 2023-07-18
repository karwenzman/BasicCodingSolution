using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Views.SettingView;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Diagnostics;

namespace BasicCodingConsole.Views.MainView;

public class MainView : ViewBase, IMainView
{
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly IConfiguration _configuration;
    private readonly IHost _hostProvider;
    private readonly ILogger<MainView> _logger;

    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="ContentMainMenu"/>.
    /// </summary>
    public IMenu Menu => new MainMenu();
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StartingApp"/>,
    /// <see cref="EndingApp"/> and <see cref="ContinueMessage"/>
    /// </summary>
    public IMessage Message => new MainMessage();
    /// <summary>
    /// This property is providing standard method used to manipulate the console.
    /// <para></para>
    /// The method's behavior is implemented in the files <see cref="ClearingApp"/> and
    /// <see cref="ResizingApp"/>.
    /// </summary>
    public IDisplay Display => new MainDisplay();
    /// <summary>
    /// This property is providing the information collected from configuration.
    /// </summary>
    public AppSettingModel AppSetting { get; set; } = new AppSettingModel();

    public MainView(IAppSettingProvider appSettingProvider, IConfiguration configuration, IHost hostProvider, ILogger<MainView> logger)
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(MainView)}>.");
        _appSettingProvider = appSettingProvider;
        _configuration = configuration;
        _hostProvider = hostProvider;
        _logger = logger;
    }

    public void Run()
    {
        Debug.WriteLine($"Passing <{nameof(Run)}> in <{nameof(MainView)}>.");
        _logger.LogInformation("* Load: {view}", nameof(MainView));
        AppSetting = _appSettingProvider.Get();
        Message.Start();

        try
        {
            bool exitApp = false;
            do
            {
                WriteMenu(Menu);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        ResizeConsoleIfNeededAndClearIt();
                        exitApp = true;
                        break;
                    case ConsoleKey.A:
                        ResizeConsoleIfNeededAndClearIt();
                        Action_A();
                        break;
                    case ConsoleKey.B:
                        ResizeConsoleIfNeededAndClearIt();
                        Action_B();
                        break;
                    case ConsoleKey.C:
                        ResizeConsoleIfNeededAndClearIt();
                        Action_C();
                        break;
                    default:
                        Console.Beep();
                        break;
                }
            } while (exitApp == false);
        }
        catch (Exception e)
        {
            Log.Logger.Error("Unexpected Exception!", e);
        }

        Message.End();
    }

    /// <summary>
    /// This method starts the logic behind this menu item.
    /// </summary>
    private void Action_A()
    {
        Display.Clear();
        WriteContent(); // to do
        Message.Continue();
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
    private void Action_C()
    {
        using var scope = _hostProvider.Services.CreateScope();
        var services = scope.ServiceProvider;
        services.GetRequiredService<ISettingView>().Run();
    }

    private void WriteContent()
    {
        Console.WriteLine($"\nInformation about user <{AppSetting.UserInformation.NickName}>");
        Console.WriteLine($"\tName  : " +
            $"{AppSetting.UserInformation.Person.FirstName} " +
            $"{AppSetting.UserInformation.Person.LastName}");
        Console.WriteLine($"\tGender: " +
            $"{AppSetting.UserInformation.Person.Gender}");
        Console.WriteLine($"\tID    : " +
            $"{AppSetting.UserInformation.Person.Id,4:0000}");

        Console.WriteLine($"\nInformation about app <{nameof(BasicCodingConsole)}>");
        Console.WriteLine($"\tLanguage : {AppSetting.ApplicationInformation.Language}");
        Console.WriteLine($"\tLastLogin: {AppSetting.ApplicationInformation.LastLogin}");
        Console.WriteLine($"\tMaxHeight: {AppSetting.ApplicationInformation.ConsoleHeightMaximum}");
        Console.WriteLine($"\tMinHeight: {AppSetting.ApplicationInformation.ConsoleHeightMinimum}");
        Console.WriteLine($"\tMaxWidth : {AppSetting.ApplicationInformation.ConsoleWidthMaximum}");
        Console.WriteLine($"\tMinWidth : {AppSetting.ApplicationInformation.ConsoleWidthMinimum}");
        Console.WriteLine($"\nInformation about command line arguments");
        Console.WriteLine($"\tArguments: {AppSetting.CommandLineArgument}");
        Console.WriteLine($"\nInformation about connection strings");
        Console.WriteLine($"\tDefault: {AppSetting.ConnectionString}");

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
}
