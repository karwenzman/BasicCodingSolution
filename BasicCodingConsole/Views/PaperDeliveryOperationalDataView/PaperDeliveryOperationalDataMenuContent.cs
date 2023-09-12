using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryOperationalDataView;

public class PaperDeliveryOperationalDataMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "",
        "Main / PaperDelivery / Operational Data",
        "",
    };

    public string[]? MenuItems { get; set; } =
    {
        "no content, yet",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit."
    };
}
