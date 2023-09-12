using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryView;

public class PaperDeliveryMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
{
        "",
        "Main / PaperDelivery",
        "",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - Reference Data",
        "B - Operational Data",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit."
    };

}
