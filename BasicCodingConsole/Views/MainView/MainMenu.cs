using BasicCodingConsole.ConsoleMenus;

namespace BasicCodingConsole.Views.MainView;

public class MainMenu : IMenu
{
    public string[]? CaptionItems { get; set; }
    public string[]? MenuItems { get; set; }
    public string[]? StatusItems { get; set; }
    public int ConsoleHeightMaximum { get; set; }
    public int ConsoleHeightMinimum { get; set; }
    public int ConsoleWidthMaximum { get; set; }
    public int ConsoleWidthMinimum { get; set; }

    /// <summary>
    /// This parameterless constructor reads the console size values
    /// from a class implementing <see cref="IMenuBehavior"/>.
    /// </summary>
    public MainMenu()
    {
        IMenuContent content = new MainMenuContent();
        CaptionItems = content.CaptionItems;
        MenuItems = content.MenuItems;
        StatusItems = content.StatusItems;

        IMenuBehavior behavior = new MainMenuBehavior();
        ConsoleHeightMaximum = behavior.ConsoleHeightMaximum;
        ConsoleHeightMinimum = behavior.ConsoleHeightMinimum;
        ConsoleWidthMaximum = behavior.ConsoleWidthMaximum;
        ConsoleWidthMinimum = behavior.ConsoleWidthMinimum;
    }
}
