using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryContractorView;

public class PaperDeliveryContractorMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
{
        "",
        "Main / PaperDelivery / Reference Data / Contractor",
        "",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - Add Contractor                    | L - List all contractors",
        "D - Delete Contractor                 | Z - Load hardcoded contractor list and save to a new file",
        "E - Edit Contractor",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit."
    };
}
