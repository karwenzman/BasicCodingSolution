namespace BasicCodingConsole.ConsoleMenus;

public interface IConsoleMenu : IMenu
{
    string[]? CaptionItems { get; set; }
    string[]? MenuItems { get; set; }
    string[]? StatusItems { get; set; }
}
