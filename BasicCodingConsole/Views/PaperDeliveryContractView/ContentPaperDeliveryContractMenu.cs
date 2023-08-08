﻿using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContentPaperDeliveryContractMenu : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "Main/PaperDeliveryContract",
    };

    public string[]? MenuItems { get; set; } = null;

    public string[]? StatusItems { get; set; } =
    {
        "ESC to exit.",
    };
}
