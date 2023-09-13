using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using PaperDeliveryLibrary.Models;
using PaperDeliveryLibrary.Providers;

namespace BasicCodingConsole.Views.PaperDeliveryContractorView;

public interface IPaperDeliveryContractorView
{
    /// <summary>
    /// A value used to store a single <see cref="PaperDeliveryContractor"/>.
    /// </summary>
    PaperDeliveryContractor Contractor { get; set; }

    /// <summary>
    /// A value used to store a list of <see cref="PaperDeliveryContractor"/>.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryProvider.GetContractorList()"/>.
    /// </summary>
    List<PaperDeliveryContractor> Contractors { get; set; }

    /// <summary>
    /// A value used to store the setting loaded from 'appsettings.json'.
    /// <para></para>
    /// The content is provided by <see cref="AppSettingProvider.GetPaperDeliverySetting()"/>.
    /// </summary>
    PaperDeliverySetting PaperDeliverySetting { get; set; }

    /// <summary>
    /// A value used to control the menu's behavior.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryContractorMenu"/>.
    /// </summary>
    IMenu Menu { get; set; }

    /// <summary>
    /// A value used to control the message's behavior.
    /// <para></para>
    /// The content is provided by <see cref="PaperDeliveryContractorMessage"/>.
    /// </summary>
    IMessage Message { get; set; }

    /// <summary>
    /// A method used to run the view.
    /// </summary>
    void Run();
}
