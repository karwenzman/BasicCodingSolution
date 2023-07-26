namespace BasicCodingConsole.ConsoleMenus;

public class BehaviorSettingMenu : IMenuBehavior
{
    public int ConsoleHeightMaximum { get; set; } = 40;
    public int ConsoleHeightMinimum { get; set; } = 40;
    public int ConsoleWidthMaximum { get; set; } = 120;
    public int ConsoleWidthMinimum { get; set; } = 120;
}
