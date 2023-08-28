using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Models;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Logging;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;
using Serilog;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContractView : ViewBase, IPaperDeliveryContractView
{
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly ILogger<ContractView> _logger;
    private readonly IPaperDeliveryProvider _paperDeliveryProvider;

    string contractFile = "Contracts.csv";
    string contractorFile = "Contractors.csv";
    string clientFile = "Clients.csv";
    string fulfillmentFile = "Fulfillments.csv";
    string paperDeliveryDirectory = "PaperDeliveryFiles";
    string fileName = "";


    /// <summary>
    /// This property is providing a list of contracts.
    /// </summary>
    public List<PaperDeliveryContract> Contracts { get; set; }

    /// <summary>
    /// This property is providing the settings used by <see cref="PaperDeliveryLibrary"/>.
    /// <para></para>
    /// The content is provided by <see cref="AppSettingProvider.Get()"/>.
    /// </summary>
    public PaperDeliverySetting PaperDeliverySetting { get; set; }

    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="ContractMenuContent"/>.
    /// </summary>
    public IMenu Menu { get; set; }

    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StandardMessageEnd"/>,
    /// <see cref="StandardMessageStart"/> and <see cref="StandardMessageContinue"/>
    /// </summary>
    public IMessage Message { get; set; }

    public ContractView(IPaperDeliveryProvider paperDeliveryProvider, IAppSettingProvider appSettingProvider, ILogger<ContractView> logger)
    {
        _paperDeliveryProvider = paperDeliveryProvider;
        _appSettingProvider = appSettingProvider;
        _logger = logger;

        PaperDeliverySetting = new PaperDeliverySetting(_appSettingProvider.Get());
        Menu = new ContractMenu(_appSettingProvider.Get());
        Message = new ContractMessage();

        Contracts = _paperDeliveryProvider.GetContractList();

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
                        Console.WriteLine("No content, yet");
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
                        WriteContractsToConsole();
                        Message.Continue();
                        break;
                    case ConsoleKey.Z:
                        WriteHardcodedContractsToConsole();
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
            Log.Logger.Error("Unexpected Exception!", e);
        }

        Message.End(showMessage: true, clearScreen: true);
    }

    /// <summary>
    /// This method is writing the members of <see cref="Contracts"/> to a console.
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


        #region ##### Sync Saving Record to File #####
        Console.WriteLine("\n##### Sync - Save Single Record To File #################################");
        try
        {
            // issues with the header and map!
            //fileName = Path.Combine(Directory.GetCurrentDirectory(), paperDeliveryDirectory, contractorFile);
            //PaperDeliveryContractor contractorToWrite = new() { FirstName = "DummyYummy" };
            //_paperDeliveryProvider.WriteRecordToFile(fileName, contractorToWrite);
            //var receivedContracatorList = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContractor>(fileName, new PaperDeliveryContractorMap());
            //foreach (var item in receivedContracatorList)
            //{
            //    Console.Write(item.ToConsole());
            //}

            fileName = Path.Combine(Directory.GetCurrentDirectory(), paperDeliveryDirectory, contractFile);
            PaperDeliveryContract contractToWrite = new()
            {
                Id = "Dummy",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 25, 00),
            };
            _paperDeliveryProvider.WriteRecordToFile(fileName, contractToWrite);
            var receivedContractList = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(fileName);
            foreach (var item in receivedContractList)
            {
                Console.Write(item.ToConsole());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected Exception while running 'WriteRecordToFile!");
            Console.WriteLine(e);
            Console.WriteLine($"\n***** Press ENTER To Continue *****");
            Console.ReadLine();
            throw;
        }
        #endregion

        Console.WriteLine("\n##### Berechnung Abgaben und Lohn #################################");
        double grossSalary;
        grossSalary = 150;
        Console.WriteLine($"Brutto:  {grossSalary,8:c2}");
        Console.WriteLine($"Abgaben: {BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary),8:c2}");
        Console.WriteLine($"Netto:   {BusinessMiniJob.CalculateEmployeeSalary(grossSalary),8:c2}");
        Console.WriteLine();
        grossSalary = 25;
        Console.WriteLine($"Brutto:  {grossSalary,8:c2}");
        Console.WriteLine($"Abgaben: {BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary),8:c2}");
        Console.WriteLine($"Netto:   {BusinessMiniJob.CalculateEmployeeSalary(grossSalary),8:c2}");
        Console.WriteLine();
        grossSalary = 520;
        Console.WriteLine($"Brutto:  {grossSalary,8:c2}");
        Console.WriteLine($"Abgaben: {BusinessMiniJob.CalculateEmployeeStatutoryPensionContribution(grossSalary),8:c2}");
        Console.WriteLine($"Netto:   {BusinessMiniJob.CalculateEmployeeSalary(grossSalary),8:c2}");
        Console.WriteLine();
    }

    private void WriteHardcodedContractsToConsole()
    {
        Contracts = _paperDeliveryProvider.GetContractList();
        foreach (var contract in Contracts)
        {
            Console.Write(contract.ToConsole());
        }
    }

    private void WriteContractsToConsole()
    {
        try
        {
            fileName = Path.Combine(Directory.GetCurrentDirectory(), PaperDeliverySetting.PaperDeliveryDirectory, PaperDeliverySetting.ContractFile);
            Contracts = _paperDeliveryProvider.ReadRecordsFromFile<PaperDeliveryContract>(fileName);
            foreach (var item in Contracts)
            {
                Console.Write(item.ToConsole());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected Exception while running {nameof(WriteContractsToConsole)}!");
            Console.WriteLine(e);
            Console.WriteLine($"\n***** Press ENTER To Continue *****");
            Console.ReadLine();
            throw;
        }
    }
}
