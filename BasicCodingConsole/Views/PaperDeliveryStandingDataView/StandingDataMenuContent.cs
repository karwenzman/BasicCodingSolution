using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.PaperDeliveryStandingDataView;

public class StandingDataMenuContent : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "",
        "Main / PaperDelivery / StandingData",
        "",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - Client",
        "B - Contract",
        "C - Contractor",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit."
    };
}
