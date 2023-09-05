using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Views.PaperDeliveryContractView;
using Microsoft.Extensions.Logging;

namespace BasicCodingConsole.Views.PaperDeliveryStandingDataView;

public class StandingDataView : ViewBase, IPaperDeliveryStandingDataView
{
    private readonly ILogger<StandingDataView> _logger;
    private readonly IPaperDeliveryContractView _paperDeliveryContractView;

    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public StandingDataView(ILogger<StandingDataView> logger, IPaperDeliveryContractView paperDeliveryContractView)
    {
        _logger = logger;
        _paperDeliveryContractView = paperDeliveryContractView;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(StandingDataView));

        Menu = new StandingDataMenu();
        Message = new StandingDataMessage();
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(StandingDataView), nameof(Run));

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
                        Console.WriteLine("No content, yet");
                        Message.Continue();
                        break;
                    case ConsoleKey.C:
                        _paperDeliveryContractView.Run();
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
    }
}
