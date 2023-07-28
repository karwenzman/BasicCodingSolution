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
    private readonly IHost _hostProvider;
    private readonly ILogger<MainView> _logger;

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
    /// The content is implemented in file <see cref="ContentMainMenu"/>.
    /// </summary>
    public IMenu Menu { get; set; }
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StartingView"/>,
    /// <see cref="EndingView"/> and <see cref="ContinueMessage"/>
    /// </summary>
    public IMessage Message { get; set; }

    public MainView(IConfiguration configuration, IHost hostProvider, ILogger<MainView> logger)
    {
        _configuration = configuration;
        _hostProvider = hostProvider; // rework here; not using the services somewhere in code
        _logger = logger;

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
                        Action_A();
                        break;
                    case ConsoleKey.B:
                        Action_B();
                        break;
                    case ConsoleKey.C:
                        Action_C();
                        break;
                    case ConsoleKey.D:
                        Action_D();
                        break;
                    case ConsoleKey.E:
                        Action_E();
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
    private void Action_A()
    {
        Display.Clear();
        Console.WriteLine($"\nNo content, yet");
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

    /// <summary>
    /// This method starts the logic behind this menu item.
    /// </summary>
    private void Action_D()
    {
        Display.Clear();
        Console.WriteLine($"\nNo content, yet");
        Message.Continue();
    }

    /// <summary>
    /// This method starts the logic behind this menu item.
    /// </summary>
    private void Action_E()
    {
        Display.Clear();
        Console.WriteLine($"\nNo content, yet");
        Message.Continue();
    }
}
