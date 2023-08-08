using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Views.SettingView;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class PaperDeliveryContractView : ViewBase, IPaperDeliveryContractView
{
    private readonly IPaperDeliveryProvider _provider;

    /// <summary>
    /// This property is providing a list of contracts.
    /// </summary>
    public List<IPaperDeliveryContract> PaperDeliveryContracts { get; set; }
    /// <summary>
    /// This property is providing standard method used to manipulate the console.
    /// <para></para>
    /// The method's behavior is implemented in the files <see cref="ClearingView"/> and
    /// <see cref="ResizingView"/>.
    /// </summary>
    public IDisplay Display { get; set; }
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
    /// <see cref="EndingView"/> and <see cref="ContinueMessage"/>
    /// </summary>
    public IMessage Message { get; set; }

    public PaperDeliveryContractView(IPaperDeliveryProvider provider)
    {
        _provider = provider;
        PaperDeliveryContracts = _provider.GetContractList();

        Display = new SettingDisplay();
        Menu = new PaperDeliveryContractMenu();
        Message = new SettingMessage();
    }

    public void Run()
    {
        WriteMenu(Menu);
        WriteContent();
        Console.ReadLine();
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
