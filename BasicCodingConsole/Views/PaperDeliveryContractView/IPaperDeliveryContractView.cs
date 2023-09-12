using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public interface IPaperDeliveryContractView
{
    /// <summary>
    /// A value used to store a single <see cref="PaperDeliveryContract"/>.
    /// </summary>
    PaperDeliveryContract Contract { get; set; }

    /// <summary>
    /// A value used to store a list of <see cref="PaperDeliveryContract"/>.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryProvider.GetContractList()"/>.
    /// </summary>
    List<PaperDeliveryContract> Contracts { get; set; }

    /// <summary>
    /// A value used to store the setting loaded from 'appsettings.json'.
    /// <para></para>
    /// The content is provided by <see cref="AppSettingProvider.GetPaperDeliverySetting()"/>.
    /// </summary>
    PaperDeliverySetting PaperDeliverySetting { get; set; }

    /// <summary>
    /// A value used to control the menu's behavior.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryContractMenu"/>.
    /// </summary>
    IMenu Menu { get; set; }

    /// <summary>
    /// A value used to control the message's behavior.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryContractMessage"/>.
    /// </summary>
    IMessage Message { get; set; }

    /// <summary>
    /// A method used to run the view.
    /// </summary>
    void Run();
}
