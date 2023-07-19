using System.Diagnostics;

namespace BasicCodingConsole.ConsoleMenus;

public class SettingMenu : IMenu
{
    public string[]? CaptionItems { get; }
    public string[]? MenuItems { get; }
    public string[]? StatusItems { get; }
    public int ConsoleHeightMaximum { get; set; }
    public int ConsoleHeightMinimum { get; set; }
    public int ConsoleWidthMaximum { get; set; }
    public int ConsoleWidthMinimum { get; set; }
    public SettingMenu()
    {
        Debug.WriteLine($"Passing <Constructor> in <{nameof(SettingMenu)}>.");

        IMenuContent content = new ContentSettingMenu();
        CaptionItems = content.CaptionItems;
        MenuItems = content.MenuItems;
        StatusItems = content.StatusItems;

        IMenuBehavior behavior = new BehaviorAllConsole();
        ConsoleHeightMaximum = behavior.ConsoleHeightMaximum;
        ConsoleHeightMinimum = behavior.ConsoleHeightMinimum;
        ConsoleWidthMaximum = behavior.ConsoleWidthMaximum;
        ConsoleWidthMinimum = behavior.ConsoleWidthMinimum;
    }
}
