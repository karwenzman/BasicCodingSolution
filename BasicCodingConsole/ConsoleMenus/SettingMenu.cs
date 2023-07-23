namespace BasicCodingConsole.ConsoleMenus;

public class SettingMenu : IMenu
{
    public string[]? CaptionItems { get; set; }
    public string[]? MenuItems { get; set; }
    public string[]? StatusItems { get; set; }
    public int ConsoleHeightMaximum { get; set; }
    public int ConsoleHeightMinimum { get; set; }
    public int ConsoleWidthMaximum { get; set; }
    public int ConsoleWidthMinimum { get; set; }
    public SettingMenu()
    {
        IMenuContent content = new ContentSettingMenu();
        CaptionItems = content.CaptionItems;
        MenuItems = content.MenuItems;
        StatusItems = content.StatusItems;

        IMenuBehavior behavior = new BehaviorSettingMenu();
        ConsoleHeightMaximum = behavior.ConsoleHeightMaximum;
        ConsoleHeightMinimum = behavior.ConsoleHeightMinimum;
        ConsoleWidthMaximum = behavior.ConsoleWidthMaximum;
        ConsoleWidthMinimum = behavior.ConsoleWidthMinimum;
    }
}
