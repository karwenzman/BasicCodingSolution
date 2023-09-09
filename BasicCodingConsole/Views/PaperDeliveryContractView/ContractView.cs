using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;
using BasicCodingConsole.Providers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContractView : ViewBase, IPaperDeliveryContractView
{
    private readonly ILogger<ContractView> _logger;
    private readonly IOptions<ConsoleSetting> _optionsOfConsoleSetting;
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly IPaperDeliveryProvider _paperDeliveryProvider;
    private readonly IOptions<PaperDeliverySetting> _options;

    public PaperDeliveryContract Contract { get; set; }
    public List<PaperDeliveryContract> Contracts { get; set; }
    public PaperDeliverySetting PaperDeliverySetting { get; set; }
    public IMenu Menu { get; set; }
    public IMessage Message { get; set; }

    public ContractView(ILogger<ContractView> logger, IOptions<ConsoleSetting> optionsOfConsoleSetting, IOptions<PaperDeliverySetting> options, IAppSettingProvider appSettingProvider, IPaperDeliveryProvider paperDeliveryProvider)
    {
        _paperDeliveryProvider = paperDeliveryProvider;
        _appSettingProvider = appSettingProvider;
        _logger = logger;
        _optionsOfConsoleSetting = optionsOfConsoleSetting;
        _options = options;

        _logger.LogInformation("* Dependendy Injection: {class}", nameof(ContractView));

        Menu = new ContractMenu(_optionsOfConsoleSetting.Value);
        Message = new ContractMessage();
        PaperDeliverySetting = _options.Value;

        Contract = new();
        Contracts = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile));
    }

    public void Run()
    {
        _logger.LogInformation("** {class}.{method}()", nameof(ContractView), nameof(Run));

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
                        _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeA), e);
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
    /// This method is performing the logic when calling menu key 'D'.
    /// </summary>
    private void KeystrokeD()
    {
        Contract = new();
        bool isValidated;
        bool isRecordFound;
        string searchId = "";

        Console.WriteLine("Deleting a contract");
        Console.WriteLine("===================");
        Console.WriteLine("ContractID - enter date of contract (yyyymmdd): ");
        isValidated = false;
        do
        {
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length == 8)
                {
                    searchId = input + "KA";
                    isValidated = true;
                    continue;
                }
            }
            Console.WriteLine("Incorrect Value!");
        } while (!isValidated);


        // load contracts and filter contract
        isRecordFound = false;
        try
        {
            Contracts = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile));
            Contracts.Sort();
            foreach (var item in Contracts)
            {
                if (item.Id == searchId)
                {
                    Contract = item;
                    isRecordFound = true;
                    break;
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeD), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeD)}! Refer to log file for details.");
        }

        // display contract
        if (isRecordFound)
        {
            Console.WriteLine(Contract.ToConsole());
        }
        else
        {
            Console.WriteLine("Record not found!");
            return;
        }

        // confirm delete
        Console.WriteLine("Do you want to delete this contract? (y/n)");
        isValidated = false;
        do
        {
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToLower() == "y")
                {
                    Console.WriteLine("Deleting contract from contracts and save!");
                    try
                    {
                        Contracts.Remove(Contract);
                        _paperDeliveryProvider.WriteRecordsToFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile), Contracts);
                        isValidated = true;
                        continue;
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeD), e);
                        Console.WriteLine($"Exception while running {nameof(KeystrokeD)}! Refer to log file for details.");
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
    /// This method is performing the logic when calling menu key 'E'.
    /// </summary>
    private void KeystrokeE()
    {

        Contract = new();
        bool isValidated;
        bool isRecordFound;
        string searchId = "";
        PaperDeliveryContract updatedContract = new();

        Console.WriteLine("Editing a contract");
        Console.WriteLine("==================");
        Console.WriteLine("ContractID - enter date of contract (yyyymmdd): ");
        isValidated = false;
        do
        {
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length == 8)
                {
                    searchId = input + "KA";
                    isValidated = true;
                    continue;
                }
            }
            Console.WriteLine("Incorrect Value!");
        } while (!isValidated);

        //show values
        isRecordFound = false;
        try
        {
            Contracts = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile));
            Contracts.Sort();
            foreach (var item in Contracts)
            {
                if (item.Id == searchId)
                {
                    Contract = item;
                    isRecordFound = true;
                    break;
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeD), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeD)}! Refer to log file for details.");
        }

        if (isRecordFound)
        {
            Console.WriteLine("current Contract");
            Console.WriteLine(Contract.ToConsole());
        }
        else
        {
            Console.WriteLine("Record not found!");
            return;
        }

        //moving current values to new object - except the properties that are going to be updated
        updatedContract.Id = Contract.Id;
        updatedContract.HourlyWageRate = Contract.HourlyWageRate;
        updatedContract.Region = Contract.Region;
        updatedContract.Site = Contract.Site;
        updatedContract.Route = Contract.Route;
        updatedContract.NumberOfPapers = Contract.NumberOfPapers;

        Console.WriteLine($"Standardized Working Hours: {Contract.StandardizedWorkingHours}");
        Console.WriteLine("Standardized Working Hours - enter new time (hh:mm): ");
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
                        updatedContract.StandardizedWorkingHours = new TimeOnly(hours, minutes, 00);
                        isValidated = true;
                        continue;
                    }
                }
            }
            Console.WriteLine("Incorrect Value!");
        } while (!isValidated);

        Console.WriteLine("updated Contract");
        Console.WriteLine(updatedContract.ToConsole());

        Console.WriteLine("Do you want to save this edited contract? (y/n)");
        isValidated = false;
        do
        {
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.ToLower() == "y")
                {
                    Console.WriteLine("Updating contract and save!");
                    try
                    {
                        Contracts.Remove(Contract);
                        Contracts.Add(updatedContract);
                        _paperDeliveryProvider.WriteRecordsToFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile), Contracts);
                        isValidated = true;
                        continue;
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeE), e);
                        Console.WriteLine($"Exception while running {nameof(KeystrokeE)}! Refer to log file for details.");
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
        Console.WriteLine("Listing contracts (sorted by Contract-ID)");
        Console.WriteLine("=========================================");

        try
        {
            Contracts = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile));
            Contracts.Sort();
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeL), e);
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
        Contracts.Sort();

        try
        {
            _paperDeliveryProvider.WriteRecordsToFile<PaperDeliveryContract>(Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile), Contracts);
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while running {method}(): {error}", nameof(KeystrokeZ), e);
            Console.WriteLine($"Exception while running {nameof(KeystrokeZ)}! Refer to log file for details.");
        }
    }
}
