using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryClientView;

public interface IPaperDeliveryClientView
{
    /// <summary>
    /// A value used to store a single <see cref="PaperDeliveryClient"/>.
    /// </summary>
    PaperDeliveryClient Client { get; set; }

    /// <summary>
    /// A value used to store a list of <see cref="PaperDeliveryClient"/>.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryProvider.GetClientList()"/>.
    /// </summary>
    List<PaperDeliveryClient> Clients { get; set; }

    /// <summary>
    /// A value used to store the setting loaded from 'appsettings.json'.
    /// <para></para>
    /// The content is provided by <see cref="AppSettingProvider.GetPaperDeliverySetting()"/>.
    /// </summary>
    PaperDeliverySetting PaperDeliverySetting { get; set; }

    /// <summary>
    /// A value used to control the menu's behavior.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryClientMenu"/>.
    /// </summary>
    IMenu Menu { get; set; }

    /// <summary>
    /// A value used to control the message's behavior.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryClientMessage"/>.
    /// </summary>
    IMessage Message { get; set; }

    /// <summary>
    /// A method used to run the view.
    /// </summary>
    void Run();
}
