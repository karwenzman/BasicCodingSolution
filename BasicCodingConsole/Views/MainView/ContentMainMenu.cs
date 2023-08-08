using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.MainView;

public class ContentMainMenu : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "Main",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - no function, yet                         | D - PaperDelivery - List Contracts",
        "B - Run FibonacciApp                         | E - no function, yet",
        "C - Open SettingView",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit.",
    };
}
