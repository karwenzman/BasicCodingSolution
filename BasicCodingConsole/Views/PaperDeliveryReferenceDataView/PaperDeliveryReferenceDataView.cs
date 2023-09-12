using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using BasicCodingConsole.Views.PaperDeliveryContractView;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasicCodingConsole.Views.PaperDeliveryReferenceDataView;

public class PaperDeliveryReferenceDataView : ViewBase, IPaperDeliveryReferenceDataView
{
    private readonly ILogger<PaperDeliveryReferenceDataView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;
    private readonly IPaperDeliveryContractView _paperDeliveryContractView;

    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public PaperDeliveryReferenceDataView(ILogger<PaperDeliveryReferenceDataView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting, IPaperDeliveryContractView paperDeliveryContractView)
    {
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;
        _paperDeliveryContractView = paperDeliveryContractView;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(PaperDeliveryReferenceDataView));

        Menu = new PaperDeliveryReferenceDataMenu(_optionsOfConsoleSetting.Value);
        Message = new PaperDeliveryReferenceDataMessage();
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(PaperDeliveryReferenceDataView), nameof(Run));

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
                        _paperDeliveryContractView.Run();
                        break;
                    case ConsoleKey.C:
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
    }
}
