using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using BasicCodingConsole.Views.PaperDeliveryClientView;
using BasicCodingConsole.Views.PaperDeliveryContractorView;
using BasicCodingConsole.Views.PaperDeliveryContractView;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasicCodingConsole.Views.PaperDeliveryReferenceDataView;

public class PaperDeliveryReferenceDataView : ViewBase, IPaperDeliveryReferenceDataView
{
    private readonly ILogger<PaperDeliveryReferenceDataView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;
    private readonly IPaperDeliveryClientView _paperDeliveryClientView;
    private readonly IPaperDeliveryContractView _paperDeliveryContractView;
    private readonly IPaperDeliveryContractorView _paperDeliveryContractorView;

    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public PaperDeliveryReferenceDataView(ILogger<PaperDeliveryReferenceDataView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting, IPaperDeliveryClientView paperDeliveryClientView, IPaperDeliveryContractView paperDeliveryContractView, IPaperDeliveryContractorView paperDeliveryContractorView)
    {
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;
        _paperDeliveryClientView = paperDeliveryClientView;
        _paperDeliveryContractView = paperDeliveryContractView;
        _paperDeliveryContractorView = paperDeliveryContractorView;

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
                        _paperDeliveryClientView.Run();
                        break;
                    case ConsoleKey.B:
                        _paperDeliveryContractView.Run();
                        break;
                    case ConsoleKey.C:
                        _paperDeliveryContractorView.Run();
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
