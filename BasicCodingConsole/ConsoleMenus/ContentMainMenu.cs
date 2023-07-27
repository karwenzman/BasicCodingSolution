﻿namespace BasicCodingConsole.ConsoleMenus;

public class ContentMainMenu : IMenuContent
{
    public string[]? CaptionItems { get; set; } =
    {
        "Main",
    };

    public string[]? MenuItems { get; set; } =
    {
        "A - no function, yet                         | D - no function, yet",
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
