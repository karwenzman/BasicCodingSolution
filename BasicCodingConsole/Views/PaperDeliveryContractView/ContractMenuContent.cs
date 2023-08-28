using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContractMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "",
        "Main / PaperDeliveryContract",
        "",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - Add Contract                      | L - List all Contracts",
        "D - Delete Contract                   | Z - Load Hardcoded Contracts and save to file",
        "E - Edit Contract",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit."
    };
}
