namespace BasicCodingConsole.ConsoleMenus;

public class StandardMenuBehavior : IMenuBehavior
{
    public int ConsoleHeightMaximum { get; set; } = 40;
    public int ConsoleHeightMinimum { get; set; } = 20;
    public int ConsoleWidthMaximum { get; set; } = 160;
    public int ConsoleWidthMinimum { get; set; } = 80;
}
