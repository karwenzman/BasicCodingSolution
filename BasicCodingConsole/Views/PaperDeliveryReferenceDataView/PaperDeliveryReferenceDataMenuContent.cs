using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryReferenceDataView;

public class PaperDeliveryReferenceDataMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "",
        "Main / PaperDelivery / Reference Data",
        "",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - Client",
        "B - Contract",
        "C - Contractor",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit."
    };
}
