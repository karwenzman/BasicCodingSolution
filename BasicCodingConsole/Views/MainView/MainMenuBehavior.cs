using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.MainView;

public class MainMenuBehavior : IMenuBehavior
{
    public int ConsoleHeightMaximum { get; set; } = 20;
    public int ConsoleHeightMinimum { get; set; } = 20;
    public int ConsoleWidthMaximum { get; set; } = 80;
    public int ConsoleWidthMinimum { get; set; } = 80;
}
