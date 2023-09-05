using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Views.PaperDeliveryContractView;
using BasicCodingConsole.Views.SettingView;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BasicCodingConsole.Views.MainView;

public class MainView : ViewBase, IMainView
{
    private readonly ILogger<MainView> _logger;
    private readonly ISettingView _settingView;
    private readonly IPaperDeliveryContractView _paperDeliveryContractView;

    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="MainMenuContent"/>.
    /// </summary>
    public IMenu Menu { get; set; }
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="MainMessageStart"/>,
    /// <see cref="MainMessageEnd"/> and <see cref="StandardMessageContinue"/>
    /// </summary>
    public IMessage Message { get; set; }

    public MainView(ILogger<MainView> logger, IPaperDeliveryContractView paperDeliveryContractView, ISettingView settingView)
    {
        _logger = logger;
        _paperDeliveryContractView = paperDeliveryContractView;
        _settingView = settingView;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(MainView));

        Menu = new MainMenu();
        Message = new MainMessage();
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(MainView), nameof(Run));

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
                        Message.Continue();
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
                        Message.Continue();
                        break;
                    default:
                        Console.Beep();
                        break;
                }
            } while (exitApp == false);
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(Run), e);
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
