using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Views.SettingView;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContractView : ViewBase, IPaperDeliveryContractView
{
    private readonly IPaperDeliveryProvider _provider;

    /// <summary>
    /// This property is providing a list of contracts.
    /// </summary>
    public List<IPaperDeliveryContract> Contracts { get; set; }
    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="SettingMenuContent"/>.
    /// </summary>
    public IMenu Menu { get; set; }
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StartingView"/>,
    /// <see cref="EndingView"/> and <see cref="StandardMessageContinue"/>
    /// </summary>
    public IMessage Message { get; set; }

    public ContractView(IPaperDeliveryProvider provider)
    {
        _provider = provider;
        Contracts = _provider.GetContractList();

        Menu = new ContractMenu();
        Message = new ContractMessage();
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
        foreach (var item in Contracts)
        {
            Console.WriteLine($"\nContractID {item.ContractID} - Tour {item.Route} {item.Site} {item.Region}");
            Console.WriteLine($"{"Workload",10} {"Schedule",10} {"HourlyWage",12} {"Wage",13}");
            Console.WriteLine($"{item.NumberOfPapers,10} {item.StandardizedWorkingHours,10} {item.HourlyWageRate,8:f2} EUR ==> {item.Wage:f2} EUR");
        }
    }
}
