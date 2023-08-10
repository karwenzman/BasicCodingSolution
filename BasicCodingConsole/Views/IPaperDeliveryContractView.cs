using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using PaperDeliveryLibrary.Models;

namespace BasicCodingConsole.Views;

public interface IPaperDeliveryContractView
{
    /// <summary>
    /// A value to store a list of contracts.
    /// </summary>
    List<IPaperDeliveryContract> PaperDeliveryContracts { get; set; }
    /// <summary>
    /// A value used to control the menu's behavior.
    /// </summary>
    IMenu Menu { get; set; }
    /// <summary>
    /// A value used to control the message's behavior.
    /// </summary>
    IMessage Message { get; set; }

    /// <summary>
    /// A method used to run the view.
    /// </summary>
    void Run();
}
