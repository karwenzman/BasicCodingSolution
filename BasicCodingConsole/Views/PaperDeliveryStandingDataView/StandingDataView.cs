﻿using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using BasicCodingConsole.Views.PaperDeliveryContractView;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasicCodingConsole.Views.PaperDeliveryStandingDataView;

public class StandingDataView : ViewBase, IPaperDeliveryStandingDataView
{
    private readonly ILogger<StandingDataView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;
    private readonly IPaperDeliveryContractView _paperDeliveryContractView;

    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public StandingDataView(ILogger<StandingDataView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting, IPaperDeliveryContractView paperDeliveryContractView)
    {
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;
        _paperDeliveryContractView = paperDeliveryContractView;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(StandingDataView));

        Menu = new StandingDataMenu(_optionsOfConsoleSetting.Value);
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
