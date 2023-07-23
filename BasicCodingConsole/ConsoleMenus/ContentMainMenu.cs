namespace BasicCodingConsole.ConsoleMenus;

public class ContentMainMenu : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "Main",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - no function, yet                         | D - Open SettingViewVersion2",
        "B - Run FibonacciApp                         | E - Open SettingViewVersion3",
        "C - Open SettingView",
        "",
        "",
    };

    public string[]? StatusItems { get; set; } =
    {
        "Select a menu item or press ESC to exit.",
    };
}
