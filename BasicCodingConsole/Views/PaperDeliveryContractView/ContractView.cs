using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Logging;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContractView : ViewBase, IPaperDeliveryContractView
{
    private readonly IAppSettingProvider _appSettingProvider;
    private readonly ILogger<ContractView> _logger;
    private readonly IPaperDeliveryProvider _paperDeliveryProvider;

    /// <summary>
    /// This property is providing a list of contracts.
    /// </summary>
    public List<PaperDeliveryContract> Contracts { get; set; }
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

        Contracts = _paperDeliveryProvider.GetContractList();
        Menu = new ContractMenu(_appSettingProvider.Get());
        Message = new ContractMessage();

        _logger.LogInformation("* Load: {view}", nameof(ContractView));
    }

    public void Run()
    {
        WriteMenu(Menu);
        WriteContent();
        Message.Continue();
    }

    /// <summary>
    /// This method is writing the members of <see cref="Contracts"/> to a console.
    /// </summary>
    private void WriteContent()
    {
        foreach (var contract in Contracts)
        {
            Console.WriteLine($"\nContractID {contract.ContractID} - Tour {contract.Route} {contract.Site} {contract.Region}");
            Console.WriteLine($"{"Workload",10} {"Schedule",10} {"HourlyWage",12} {"Wage",13}");
            Console.WriteLine($"{contract.NumberOfPapers,10} {contract.StandardizedWorkingHours,10} {contract.HourlyWageRate,8:f2} EUR ==> {contract.Wage:f2} EUR");
        }

        Console.WriteLine("######################################");
        string file = "Contracts.csv";
        string subDirectory = "PaperDeliveryFiles";
        string fileName = Path.Combine(Directory.GetCurrentDirectory(), subDirectory, file);
        _paperDeliveryProvider.WriteContractList(fileName, Contracts);

        List<PaperDeliveryContract> list = new();
        list = _paperDeliveryProvider.GetContractList(fileName);
        foreach (var item in list)
        {
            Console.WriteLine($"\nContractID {item.ContractID} - Tour {item.Route} {item.Site} {item.Region}");
            Console.WriteLine($"{"Workload",10} {"Schedule",10} {"HourlyWage",12} {"Wage",13}");
            Console.WriteLine($"{item.NumberOfPapers,10} {item.StandardizedWorkingHours,10} {item.HourlyWageRate,8:f2} EUR ==> {item.Wage:f2} EUR");
        }

        Console.WriteLine("######################################");
        List<PaperDeliveryContractor> contractors = new List<PaperDeliveryContractor>();
        contractors = _paperDeliveryProvider.GetContractorList();
        foreach (var contractor in contractors)
        {
            Console.WriteLine($"\nContractorID {contractor.ContractorID}");
            Console.WriteLine($"\t{contractor.FirstName} {contractor.LastName}");
            Console.WriteLine($"\t{contractor.Street}");
            Console.WriteLine($"\t{contractor.PostalCode} {contractor.City}");
            Console.WriteLine($"\t{contractor.Site}");
        }

        Console.WriteLine("######################################");
        List<PaperDeliveryClient> clients = new List<PaperDeliveryClient>();
        clients = _paperDeliveryProvider.GetClientList();
        foreach (var client in clients)
        {
            Console.WriteLine($"\nClientID {client.Id}");
            Console.WriteLine($"\t{client.Name}");
            if (!string.IsNullOrEmpty(client.AdditionalInformation))
            {
                Console.WriteLine($"\t{client.AdditionalInformation}");
            }
            Console.WriteLine($"\t{client.PostalAddress.Street}");
            if (!string.IsNullOrEmpty(client.PostalAddress.AdditionalInformation))
            {
                Console.WriteLine($"\t{client.PostalAddress.AdditionalInformation}");
            }
            Console.WriteLine($"\t{client.PostalAddress.PostalCode} {client.PostalAddress.City}");
            Console.WriteLine($"\t{client.PostalAddress.Country}");
            if (!string.IsNullOrEmpty(client.ContactDetails.Email))
            {
                Console.WriteLine($"\tEmail: {client.ContactDetails.Email}");
            }
            if (!string.IsNullOrEmpty(client.ContactDetails.Mobile))
            {
                Console.WriteLine($"\tMobile: {client.ContactDetails.Mobile}");
            }
            if (!string.IsNullOrEmpty(client.ContactDetails.Phone))
            {
                Console.WriteLine($"\tPhone: {client.ContactDetails.Phone}");
            }
        }
    }
}
