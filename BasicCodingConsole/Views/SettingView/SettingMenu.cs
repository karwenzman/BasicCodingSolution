using BasicCodingConsole.ConsoleMenus;
using BasicCodingLibrary.Models;

namespace BasicCodingConsole.Views.SettingView;

public class SettingMenu : IMenu
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

    /// <summary>
    /// This constructor with parameter reads the console size values
    /// from a class implementing <see cref="IAppSettingModel"/>.
    /// <para></para>
    /// The fallback values are read from a class implementing <see cref="IMenuBehavior"/>,
    /// <br></br>if:
    /// <br></br>- the instance of <see cref="AppSettingModel"/> is null
    /// <br></br>- a value of the height or width is &lt;= 0
    /// </summary>
    /// <param name="appSettingModel"></param>
    public SettingMenu(IAppSettingModel appSettingModel)
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

        if (appSettingModel != null)
        {
            if (appSettingModel.ApplicationInformation.ConsoleHeightMaximum > 0)
            {
                ConsoleHeightMaximum = appSettingModel.ApplicationInformation.ConsoleHeightMaximum;
            }
            if (appSettingModel.ApplicationInformation.ConsoleHeightMinimum > 0)
            {
                ConsoleHeightMinimum = appSettingModel.ApplicationInformation.ConsoleHeightMinimum;
            }
            if (appSettingModel.ApplicationInformation.ConsoleWidthMaximum > 0)
            {
                ConsoleWidthMaximum = appSettingModel.ApplicationInformation.ConsoleWidthMaximum;
            }
            if (appSettingModel.ApplicationInformation.ConsoleWidthMinimum > 0)
            {
                ConsoleWidthMinimum = appSettingModel.ApplicationInformation.ConsoleWidthMinimum;
            }
        }
    }
}
