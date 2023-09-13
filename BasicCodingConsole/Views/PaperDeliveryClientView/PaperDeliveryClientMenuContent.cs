using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryClientView;

public class PaperDeliveryClientMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
{
        "",
        "Main / PaperDelivery / Reference Data / Client",
        "",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - Add Client                        | L - List all clients",
        "D - Delete Client                     | Z - Load hardcoded client list and save to a new file",
        "E - Edit Client",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit."
    };
}
