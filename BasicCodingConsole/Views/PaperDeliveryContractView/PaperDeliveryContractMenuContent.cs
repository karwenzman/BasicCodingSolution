﻿using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class PaperDeliveryContractMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "",
        "Main / PaperDelivery / Reference Data / Contract",
        "",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - Add Contract                      | L - List all contracts",
        "D - Delete Contract                   | Z - Load hardcoded contract list and save to a new file",
        "E - Edit Contract",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit."
    };
}
