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
    public List<IPaperDeliveryContract> PaperDeliveryContracts { get; set; }
    /// <summary>
    /// This property is providing the menu's content written to the console.
    /// <para></para>
    /// The content is implemented in file <see cref="ContentSettingMenu"/>.
    /// </summary>
    public IMenu Menu { get; set; }
    /// <summary>
    /// This property is providing standard messages written to the console.
    /// <para></para>
    /// The content is implemented in the files <see cref="StartingView"/>,
    /// <see cref="EndingView"/> and <see cref="StandardContinueMessage"/>
    /// </summary>
    public IMessage Message { get; set; }

    public ContractView(IPaperDeliveryProvider provider)
    {
        _provider = provider;
        PaperDeliveryContracts = _provider.GetContractList();

        Menu = new ContractMenu();
        Message = new ContractMessage();
    }

    public void Run()
    {
        Message.Start();
        WriteMenu(Menu);
        WriteContent();
        Message.Continue();
    }

    /// <summary>
    /// This method is writing the members of <see cref="PaperDeliveryContracts"/> to a console.
    /// </summary>
    private void WriteContent()
    {
        foreach (var item in PaperDeliveryContracts)
        {
            Console.WriteLine($"\nContractID: {item.ContractID}");
            Console.WriteLine($"{"Tour",10}: {item.Route} {item.Site} {item.Region} {item.NumberOfPapers}x papers");
            Console.WriteLine($"{"Schedule",10} {"HourlyWage",12}");
            Console.WriteLine($"{item.StandardizedWorkingHours,10} {item.HourlyWageRate,8:f2} EUR ==> {item.Wage:f2} EUR");
        }
    }
}
