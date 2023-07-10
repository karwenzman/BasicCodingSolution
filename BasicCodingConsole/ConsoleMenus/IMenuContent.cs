namespace BasicCodingConsole.ConsoleMenus;

public interface IMenuContent
{
    string[]? CaptionItems { get; }
    string[]? MenuItems { get; }
    string[]? StatusItems { get; }
}
