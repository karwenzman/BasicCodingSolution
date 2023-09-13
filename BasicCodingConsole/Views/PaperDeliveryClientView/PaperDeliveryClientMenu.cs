using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.Models;

namespace BasicCodingConsole.Views.PaperDeliveryClientView;

public class PaperDeliveryClientMenu : IMenu
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
    /// <para></para>
    /// These values are hard coded and can not be changed from outside the application.
    /// If you want to override them, use the constructor with parameters.
    /// </summary>
    public PaperDeliveryClientMenu() : this(new ConsoleSetting())
    {

    }

    /// <summary>
    /// This constructor with parameter reads the console size values
    /// from a class implementing <see cref="IConsoleSetting"/>.
    /// <para></para>
    /// The fallback values are read from a class implementing <see cref="IMenuBehavior"/>, if:
    /// <br></br>- a value of the height or width is &lt;= 0
    /// </summary>
    /// <param name="consoleSetting">A class implementing <see cref="IConsoleSetting"/>.</param>
    public PaperDeliveryClientMenu(IConsoleSetting consoleSetting)
    {
        IMenuContent content = new PaperDeliveryClientMenuContent();
        CaptionItems = content.CaptionItems;
        MenuItems = content.MenuItems;
        StatusItems = content.StatusItems;

        IMenuBehavior behavior = new PaperDeliveryClientMenuBehavior();
        if (consoleSetting.HeightMaximum > 0 && consoleSetting.HeightMinimum > 0)
        {
            ConsoleHeightMaximum = consoleSetting.HeightMaximum;
            ConsoleHeightMinimum = consoleSetting.HeightMinimum;
        }
        else
        {
            ConsoleHeightMaximum = behavior.ConsoleHeightMaximum;
            ConsoleHeightMinimum = behavior.ConsoleHeightMinimum;
        }

        if (consoleSetting.WidthMaximum > 0 && consoleSetting.WidthMinimum > 0)
        {
            ConsoleWidthMaximum = consoleSetting.WidthMaximum;
            ConsoleWidthMinimum = consoleSetting.WidthMinimum;
        }
        else
        {
            ConsoleWidthMaximum = behavior.ConsoleWidthMaximum;
            ConsoleWidthMinimum = behavior.ConsoleWidthMinimum;
        }
    }
}
