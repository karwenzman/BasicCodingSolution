using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Logging;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContractView : ViewBase, IPaperDeliveryContractView
{
    private readonly ILogger<ContractView> _logger;
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly IPaperDeliveryProvider _paperDeliveryProvider;

    public PaperDeliveryContract Contract { get; set; }
    public List<PaperDeliveryContract> Contracts { get; set; }
    public PaperDeliverySetting PaperDeliverySetting { get; set; }
    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public ContractView(ILogger<ContractView> logger, IAppSettingProvider appSettingProvider, IPaperDeliveryProvider paperDeliveryProvider)
    {
        _paperDeliveryProvider = paperDeliveryProvider;
        _appSettingProvider = appSettingProvider;
        _logger = logger;

        Menu = new ContractMenu(_appSettingProvider.Get());
        Message = new ContractMessage();
        PaperDeliverySetting = new PaperDeliverySetting(_appSettingProvider.Get());
        Contract = new();
        Contracts = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile));

        _logger.LogInformation("* Load: {view}", nameof(ContractView));
    }

    public void Run()
    {
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
                        Console.WriteLine("No content, yet");
                        Message.Continue();
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("No content, yet");
                        Message.Continue();
                        break;
                    case ConsoleKey.L:
                        KeystrokeL();
                        Message.Continue();
                        break;
                    case ConsoleKey.Z:
                        KeystrokeL();
                        KeystrokeZ();
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
            _logger.LogError("Unexpected Exception!", e);
        }
    }

    /// <summary>
    /// This method is writing the members of <see cref="PaperDeliveryContract"/> to a console.
    /// </summary>
    private void WriteContent()
    {
        #region ##### Sync Saving List to File #####
        //Console.WriteLine("\n##### Sync - List Contracts and Save #################################");
        //foreach (var contract in Contracts)
        //{
        //    Console.Write(contract.ToConsole());
        //}

        //try
        //{
        //    fileName = Path.Combine(Directory.GetCurrentDirectory(), paperDeliveryDirectory, contractFile);
        //    _paperDeliveryProvider.WriteRecordsToFile(fileName, Contracts);
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine($"Unexpected Exception while running 'WriteRecordsToFile!");
        //    Console.WriteLine(e);
        //    Console.WriteLine($"\n***** Press ENTER To Continue *****");
        //    Console.ReadLine();
        //    throw;
        //}

        //Console.WriteLine("\n##### Sync - List Contractors and Save #################################");
        //List<PaperDeliveryContractor> contractors = _paperDeliveryProvider.GetContractorList();
        //foreach (var contractor in contractors)
        //{
        //    Console.Write(contractor.ToConsole());
        //}

        //try
        //{
        //    fileName = Path.Combine(Directory.GetCurrentDirectory(), paperDeliveryDirectory, contractorFile);
        //    _paperDeliveryProvider.WriteRecordsToFile(fileName, contractors, new PaperDeliveryContractorMap());
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine($"Unexpected Exception while running 'WriteRecordsToFile!");
        //    Console.WriteLine(e);
        //    Console.WriteLine($"\n***** Press ENTER To Continue *****");
        //    Console.ReadLine();
        //    throw;
        //}

        //Console.WriteLine("\n##### Sync - List Clients and Save #################################");
        //List<PaperDeliveryClient> clients = _paperDeliveryProvider.GetClientList();
        //foreach (var client in clients)
        //{
        //    Console.Write(client.ToConsole());
        //}

        //try
        //{
        //    fileName = Path.Combine(Directory.GetCurrentDirectory(), paperDeliveryDirectory, clientFile);
        //    _paperDeliveryProvider.WriteRecordsToFile(fileName, clients, new PaperDeliveryClientMap());
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine($"Unexpected Exception while running 'WriteRecordsToFile!");
        //    Console.WriteLine(e);
        //    Console.WriteLine($"\n***** Press ENTER To Continue *****");
        //    Console.ReadLine();
        //    throw;
        //}
        #endregion

        #region ##### Async Reading from File #####
        //Console.WriteLine("\n##### Async - Load Contracts and List #################################");
        //try
        //{
        //    fileName = Path.Combine(Directory.GetCurrentDirectory(), paperDeliveryDirectory, contractFile);
        //    var receivedListAsync = _paperDeliveryProvider.ReadRecordsFromFileAsync<PaperDeliveryContract>(fileName);
        //    List<PaperDeliveryContract> list = new List<PaperDeliveryContract>();
        //    list = receivedListAsync.ToBlockingEnumerable<PaperDeliveryContract>().ToList();
        //    foreach (var contract in list)
        //    {
        //        Console.Write(contract.ToConsole());
        //    }
        //}
        //catch (Exception)
        //{
        //    Console.ReadLine();
        //    throw;
        //}
        #endregion


        //#region ##### Sync Saving Record to File #####
        //Console.WriteLine("\n##### Sync - Save Single Record To File #################################");
        //try
        //{
        //    issues with the header and map!
        //   fileName = Path.Combine(Directory.GetCurrentDirectory(), paperDeliveryDirectory, contractorFile);
        //    PaperDeliveryContractor contractorToWrite = new() { FirstName = "DummyYummy" };
        //    _paperDeliveryProvider.WriteRecordToFile(fileName, contractorToWrite);
        //    var receivedContracatorList = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContractor>(fileName, new PaperDeliveryContractorMap());
        //    foreach (var item in receivedContracatorList)
        //    {
        //        Console.Write(item.ToConsole());
        //    }

        //    fileName = Path.Combine(Directory.GetCurrentDirectory(), paperDeliveryDirectory, contractFile);
        //    PaperDeliveryContract contractToWrite = new()
        //    {
        //        Id = "Dummy",
        //        HourlyWageRate = 12.00,
        //        NumberOfPapers = 205,
        //        Region = "02166",
        //        Route = "KA09",
        //        Site = "809",
        //        StandardizedWorkingHours = new TimeOnly(01, 25, 00),
        //    };
        //    _paperDeliveryProvider.WriteRecordToFile(fileName, contractToWrite);
        //    var receivedContractList = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(fileName);
        //    foreach (var item in receivedContractList)
        //    {
        //        Console.Write(item.ToConsole());
        //    }
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine($"Unexpected Exception while running 'WriteRecordToFile!");
        //    Console.WriteLine(e);
        //    Console.WriteLine($"\n***** Press ENTER To Continue *****");
        //    Console.ReadLine();
        //    throw;
        //}
        //#endregion

        //Console.WriteLine("\n##### Berechnung Abgaben und Lohn #################################");
        //double grossSalary;
        //grossSalary = 150;
        //Console.WriteLine($"Brutto:  {grossSalary,8:c2}");
        //Console.WriteLine($"Abgaben: {BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary),8:c2}");
        //Console.WriteLine($"Netto:   {BusinessMiniJob.CalculateEmployeeSalary(grossSalary),8:c2}");
        //Console.WriteLine();
        //grossSalary = 25;
        //Console.WriteLine($"Brutto:  {grossSalary,8:c2}");
        //Console.WriteLine($"Abgaben: {BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary),8:c2}");
        //Console.WriteLine($"Netto:   {BusinessMiniJob.CalculateEmployeeSalary(grossSalary),8:c2}");
        //Console.WriteLine();
        //grossSalary = 520;
        //Console.WriteLine($"Brutto:  {grossSalary,8:c2}");
        //Console.WriteLine($"Abgaben: {BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary),8:c2}");
        //Console.WriteLine($"Netto:   {BusinessMiniJob.CalculateEmployeeSalary(grossSalary),8:c2}");
        //Console.WriteLine();
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'A'.
    /// </summary>
    private void KeystrokeA()
    {
        // contract erstellen...
        Contract = new();
        bool isValidated;

        Console.WriteLine("Adding a new contract");
        Console.WriteLine("=====================");
        Console.WriteLine("ContractID - enter date of contract (yyyymmdd): ");
        isValidated = false;
        do
        {
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length == 8)
                {
                    Contract.Id = input + "KA";
                    isValidated = true;
                    continue;
                }
            }
            Console.WriteLine("Incorrect Value!");
        } while (!isValidated);

        Console.WriteLine("Standardized Working Hours - enter time (hh:mm): ");
        isValidated = false;
        do
        {
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length == 5)
                {
                    if (input.Contains(':'))
                    {
                        var splittedInput = input.Split(':');
                        int hours = Convert.ToInt32(splittedInput[0]);
                        int minutes = Convert.ToInt32(splittedInput[1]);
                        Contract.StandardizedWorkingHours = new TimeOnly(hours, minutes, 00);
                        isValidated = true;
                        continue;
                    }
                }
            }
            Console.WriteLine("Incorrect Value!");
        } while (!isValidated);

        Console.WriteLine("Summary");
        Console.WriteLine("=======");
        Console.WriteLine(Contract.ToConsole());

        Console.WriteLine("Do you want to save this contract? (y/n)");
        isValidated = false;
        do
        {
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToLower() == "y")
                {
                    Console.WriteLine("Saving record to file!");
                    try
                    {
                        _paperDeliveryProvider.WriteRecordToFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile), Contract);
                        isValidated = true;
                        continue;
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("Exception while running {method}: {error}", nameof(KeystrokeA), e);
                        Console.WriteLine($"Exception while running {nameof(KeystrokeA)}! Refer to log file for details.");
                        isValidated = true;
                        continue;
                    }
                }
                else if (input.ToLower() == "n")
                {
                    Console.WriteLine("Cancelling the process!");
                    isValidated = true;
                    continue;
                }
                Console.WriteLine("Incorrect Value!");
            }
        } while (!isValidated);
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'L'.
    /// </summary>
    private void KeystrokeL()
    {
        try
        {
            Contracts = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile));
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}: {error}", nameof(KeystrokeL), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeL)}! Refer to log file for details.");
        }

        foreach (var item in Contracts)
        {
            Console.Write(item.ToConsole());
        }
    }

    /// <summary>
    /// This method is performing the logic when calling menu key 'Z'.
    /// </summary>
    private void KeystrokeZ()
    {
        Contracts = _paperDeliveryProvider.GetContractList();

        try
        {
            _paperDeliveryProvider.WriteRecordsToFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile), Contracts);
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}: {error}", nameof(KeystrokeZ), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeZ)}! Refer to log file for details.");
        }
    }
}
