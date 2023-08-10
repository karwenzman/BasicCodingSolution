using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Diagnostics;

namespace BasicCodingConsole.Views.MainView;

public class MainView : ViewBase, IMainView
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<MainView> _logger;
    private readonly ISettingView _settingView;
    private readonly IPaperDeliveryContractView _paperDeliveryContractView;

    /// <summary>
    /// This property is providing standard method used to manipulate the console.
    /// <para></para>
    /// The method's behavior is implemented in the files <see cref="ClearingView"/> and
    /// <see cref="ResizingView"/>.
    /// </summary>
    public IDisplay Display { get; set; }
    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="MainMenuContent"/>.
    /// </summary>
    public IMenu Menu { get; set; }
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StartingView"/>,
    /// <see cref="EndingView"/> and <see cref="StandardContinueMessage"/>
    /// </summary>
    public IMessage Message { get; set; }

    public MainView(IConfiguration configuration, ILogger<MainView> logger, IPaperDeliveryContractView paperDeliveryContractView, ISettingView settingView)
    {
        _configuration = configuration;
        _logger = logger;
        _paperDeliveryContractView = paperDeliveryContractView;
        _settingView = settingView;

        Display = new MainDisplay();
        Menu = new MainMenu();
        Message = new MainMessage();

        _logger.LogInformation("* Load: {view}", nameof(MainView));
    }

    public void Run()
    {
        Message.Start(showMessage: false, clearScreen: true);

        try
        {
            bool exitApp = false;
            do
            {
                WriteMenu(Menu);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        ResizeConsoleIfNeededAndClearIt(Menu);
                        exitApp = true;
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine("No content, yet");
                        break;
                    case ConsoleKey.B:
                        Action_B();
                        break;
                    case ConsoleKey.C:
                        _settingView.Run();
                        break;
                    case ConsoleKey.D:
                        _paperDeliveryContractView.Run();
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("No content, yet");
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

        Message.End(showMessage: true, clearScreen: true);
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
}
