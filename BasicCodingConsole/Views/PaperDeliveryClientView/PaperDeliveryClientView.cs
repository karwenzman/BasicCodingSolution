using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryClientView;

public class PaperDeliveryClientView : ViewBase, IPaperDeliveryClientView
{
    private readonly ILogger<PaperDeliveryClientView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;
    private readonly IPaperDeliveryProvider _paperDeliveryProvider;
    private readonly IOptions<PaperDeliverySetting> _optionsOfPaperDeliverySetting;

    public PaperDeliveryClient Client { get; set; }
    public List<PaperDeliveryClient> Clients { get; set; }
    public PaperDeliverySetting PaperDeliverySetting { get; set; }
    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public PaperDeliveryClientView(ILogger<PaperDeliveryClientView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting, IOptions<PaperDeliverySetting> optionsOfPaperDeliverySetting, IPaperDeliveryProvider paperDeliveryProvider)
    {
        _paperDeliveryProvider = paperDeliveryProvider;
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;
        _optionsOfPaperDeliverySetting = optionsOfPaperDeliverySetting;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(PaperDeliveryClientView));

        Menu = new PaperDeliveryClientMenu(_optionsOfConsoleSetting.Value);
        Message = new PaperDeliveryClientMessage();
        PaperDeliverySetting = _optionsOfPaperDeliverySetting.Value;

        Client = new();
        Clients = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryClient>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ClientFile));
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(PaperDeliveryClientView), nameof(Run));

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
                        KeystrokeA();
                        Message.Continue();
                        break;
                    case ConsoleKey.D:
                        KeystrokeD();
                        Message.Continue();
                        break;
                    case ConsoleKey.E:
                        KeystrokeE();
                        Message.Continue();
                        break;
                    case ConsoleKey.L:
                        KeystrokeL();
                        Message.Continue();
                        break;
                    case ConsoleKey.Z:
                        KeystrokeZ();
                        KeystrokeL();
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

    /// <summary>
    /// This method is performing the logic when calling menu key 'A'.
    /// </summary>
    private void KeystrokeA()
    {
        Console.WriteLine("Adding a new client");
        Console.WriteLine("===================");
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'D'.
    /// </summary>
    private void KeystrokeD()
    {
        Console.WriteLine("Deleting a client");
        Console.WriteLine("===================");
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'E'.
    /// </summary>
    private void KeystrokeE()
    {
        Console.WriteLine("Editing a client");
        Console.WriteLine("================");
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'L'.
    /// </summary>
    private void KeystrokeL()
    {
        Console.WriteLine("Listing clients (sorted by Client-ID)");
        Console.WriteLine("=====================================");

        try
        {
            Clients = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryClient>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ClientFile));
            Clients.Sort();
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeL), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeL)}! Refer to log file for details.");
        }

        foreach (var item in Clients)
        {
            Console.Write(item.ToConsole());
        }
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'Z'.
    /// </summary>
    private void KeystrokeZ()
    {
        Clients = _paperDeliveryProvider.GetClientList();
        Clients.Sort();

        try
        {
            _paperDeliveryProvider.WriteRecordsToFile<PaperDeliveryClient>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ClientFile), Clients);
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeZ), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeZ)}! Refer to log file for details.");
        }
    }
}
