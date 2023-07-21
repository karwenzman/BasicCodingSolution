namespace BasicCodingConsole.ConsoleMenus;

public class ContentMainMenu : IMenuContent
{
    public string[]? CaptionItems { get; } =
    {
        "Main",
    };

    public string[]? MenuItems { get; } =
    {
        "A - no function, yet                         | D - Open SettingViewVersion2",
        "B - Run FibonacciApp                         | E - Open SettingViewVersion3",
        "C - Open SettingView",
        "",
        "",
    };

    public string[]? StatusItems { get; } =
    {
        "Select a menu item or press ESC to exit.",
    };
}
