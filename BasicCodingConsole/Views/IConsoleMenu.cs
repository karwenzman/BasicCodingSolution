namespace BasicCodingConsole.Views;

public interface IConsoleMenu : IMenu
{
    string[]? CaptionItems { get; set; }
    string[]? MenuItems { get; set; }
    string[]? StatusItems { get; set; }
}
