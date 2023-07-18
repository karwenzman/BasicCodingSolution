namespace BasicCodingConsole.ConsoleMenus;

public class ContentMainMenu : IMenuContent
{
    public string[]? CaptionItems { get; } =
    {
        "Main",
    };

    public string[]? MenuItems { get; } =
    {
        "A - no function, yet",
        "B - Run FibonacciApp",
        "C - Run SettingView",
        "",
        "",
    };

    public string[]? StatusItems { get; } =
    {
        "Select a menu item or press ESC to exit.",
    };
}
