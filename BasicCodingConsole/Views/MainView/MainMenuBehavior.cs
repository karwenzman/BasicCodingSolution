using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.MainView;

public class MainMenuBehavior : IMenuBehavior
{
    public int ConsoleHeightMaximum { get; set; } = 40;
    public int ConsoleHeightMinimum { get; set; } = 40;
    public int ConsoleWidthMaximum { get; set; } = 160;
    public int ConsoleWidthMinimum { get; set; } = 160;
}
