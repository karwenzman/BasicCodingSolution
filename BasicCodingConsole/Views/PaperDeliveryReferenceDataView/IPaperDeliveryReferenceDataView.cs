﻿using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.PaperDeliveryReferenceDataView;

public interface IPaperDeliveryReferenceDataView
{
    /// <summary>
    /// A value used to control the menu's behavior.
    /// <para></para>
    /// The content is provided by <see cref="ContractMenu"/>.
    /// </summary>
    IMenu Menu { get; set; }

    /// <summary>
    /// A value used to control the message's behavior.
    /// <para></para>
    /// The content is provided by <see cref="ContractMessage"/>.
    /// </summary>
    IMessage Message { get; set; }

    /// <summary>
    /// A method used to run the view.
    /// </summary>
    void Run();
}
