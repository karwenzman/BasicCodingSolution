using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Providers;
using Microsoft.Extensions.Logging;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;
using System.Globalization;

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
            Console.Write(contract.ToConsole());
        }

        Console.WriteLine("######################################");
        string file = "Contracts.csv";
        string subDirectory = "PaperDeliveryFiles";
        string fileName = Path.Combine(Directory.GetCurrentDirectory(), subDirectory, file);
        _paperDeliveryProvider.WriteContractList(fileName, Contracts);

        List<PaperDeliveryContract> list = new();
        list = _paperDeliveryProvider.GetContractList(fileName);
        list.Reverse();
        foreach (var item in list)
        {
            Console.Write(item.ToConsole());
        }

        Console.WriteLine("######################################");
        List<PaperDeliveryContractor> contractors = new List<PaperDeliveryContractor>();
        contractors = _paperDeliveryProvider.GetContractorList();
        foreach (var contractor in contractors)
        {
            Console.Write(contractor.ToConsole());
        }

        Console.WriteLine("######################################");
        List<PaperDeliveryClient> clients = new List<PaperDeliveryClient>();
        clients = _paperDeliveryProvider.GetClientList();
        foreach (var client in clients)
        {
            Console.Write(client.ToConsole());
        }
    }
}
