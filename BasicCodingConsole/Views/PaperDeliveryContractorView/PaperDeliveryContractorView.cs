using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryContractorView;

public class PaperDeliveryContractorView : ViewBase, IPaperDeliveryContractorView
{
    private readonly ILogger<PaperDeliveryContractorView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;
    private readonly IPaperDeliveryProvider _paperDeliveryProvider;
    private readonly IOptions<PaperDeliverySetting> _optionsOfPaperDeliverySetting;

    public PaperDeliveryContractor Contractor { get; set; }
    public List<PaperDeliveryContractor> Contractors { get; set; }
    public PaperDeliverySetting PaperDeliverySetting { get; set; }
    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public PaperDeliveryContractorView(ILogger<PaperDeliveryContractorView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting, IOptions<PaperDeliverySetting> optionsOfPaperDeliverySetting, IPaperDeliveryProvider paperDeliveryProvider)
    {
        _paperDeliveryProvider = paperDeliveryProvider;
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;
        _optionsOfPaperDeliverySetting = optionsOfPaperDeliverySetting;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(PaperDeliveryContractorView));

        Menu = new PaperDeliveryContractorMenu(_optionsOfConsoleSetting.Value);
        Message = new PaperDeliveryContractorMessage();
        PaperDeliverySetting = _optionsOfPaperDeliverySetting.Value;

        Contractor = new();
        Contractors = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContractor>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractorFile));
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(PaperDeliveryContractorView), nameof(Run));

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
        Console.WriteLine("Adding a new contractor");
        Console.WriteLine("=======================");
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'D'.
    /// </summary>
    private void KeystrokeD()
    {
        Console.WriteLine("Deleting a contractor");
        Console.WriteLine("=====================");
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'E'.
    /// </summary>
    private void KeystrokeE()
    {
        Console.WriteLine("Editing a contractor");
        Console.WriteLine("====================");
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'L'.
    /// </summary>
    private void KeystrokeL()
    {
        Console.WriteLine("Listing contractors (sorted by Contractor-ID)");
        Console.WriteLine("=============================================");

        try
        {
            Contractors = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContractor>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractorFile));
            Contractors.Sort();
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeL), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeL)}! Refer to log file for details.");
        }

        foreach (var item in Contractors)
        {
            Console.Write(item.ToConsole());
        }
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'Z'.
    /// </summary>
    private void KeystrokeZ()
    {
        Contractors = _paperDeliveryProvider.GetContractorList();
        Contractors.Sort();

        try
        {
            _paperDeliveryProvider.WriteRecordsToFile<PaperDeliveryContractor>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractorFile), Contractors);
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeZ), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeZ)}! Refer to log file for details.");
        }
    }
}
