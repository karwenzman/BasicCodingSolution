namespace BasicCodingConsole.ConsoleMenus;

public class SettingMenu : IMenu
{
    public string[]? CaptionItems { get; }
    public string[]? MenuItems { get; }
    public string[]? StatusItems { get; }

    public SettingMenu()
    {
        IMenuContent content = new ContentSettingMenu();
        CaptionItems = content.CaptionItems;
        MenuItems = content.MenuItems;
        StatusItems = content.StatusItems;
    }

    public void ShowMenu()
    {
        throw new NotImplementedException();
    }
}
