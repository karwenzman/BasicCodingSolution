using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasicCodingConsole.Views.PaperDeliveryOperationalDataView;

public class PaperDeliveryOperationalDataView : ViewBase, IPaperDeliveryOperationalDataView
{
    private readonly ILogger<PaperDeliveryOperationalDataView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;

    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public PaperDeliveryOperationalDataView(ILogger<PaperDeliveryOperationalDataView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting)
    {
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(PaperDeliveryOperationalDataView));

        Menu = new PaperDeliveryOperationalDataMenu(_optionsOfConsoleSetting.Value);
        Message = new PaperDeliveryOperationalDataMessage();
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(PaperDeliveryOperationalDataView), nameof(Run));

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
