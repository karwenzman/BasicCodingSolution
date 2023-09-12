using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using BasicCodingConsole.Views.PaperDeliveryOperationalDataView;
using BasicCodingConsole.Views.PaperDeliveryReferenceDataView;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasicCodingConsole.Views.PaperDeliveryView;

public class PaperDeliveryView : ViewBase, IPaperDeliveryView
{
    private readonly ILogger<PaperDeliveryView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;
    private readonly IPaperDeliveryOperationalDataView _paperDeliveryOperationalDataView;
    private readonly IPaperDeliveryReferenceDataView _paperDeliveryReferenceDataView;

    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public PaperDeliveryView(ILogger<PaperDeliveryView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting, IPaperDeliveryOperationalDataView paperDeliveryOperationalDataView, IPaperDeliveryReferenceDataView paperDeliveryReferenceDataView)
    {
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;
        _paperDeliveryOperationalDataView = paperDeliveryOperationalDataView;
        _paperDeliveryReferenceDataView = paperDeliveryReferenceDataView;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(PaperDeliveryView));

        Menu = new PaperDeliveryMenu(_optionsOfConsoleSetting.Value);
        Message = new PaperDeliveryMessage();
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(PaperDeliveryView), nameof(Run));

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
                        _paperDeliveryReferenceDataView.Run();
                        break;
                    case ConsoleKey.B:
                        _paperDeliveryOperationalDataView.Run();
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
