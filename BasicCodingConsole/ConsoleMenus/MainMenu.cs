namespace BasicCodingConsole.ConsoleMenus;

public class MainMenu : IMenu
{
    public string[]? CaptionItems { get; }
    public string[]? MenuItems { get; }
    public string[]? StatusItems { get; }

    public MainMenu()
    {
        ContentMainMenu content = new ContentMainMenu();
        CaptionItems = content.CaptionItems;
        MenuItems = content.MenuItems;
        StatusItems = content.StatusItems;
    }

    public void ShowMenu()
    {
        throw new NotImplementedException();
    }
}
