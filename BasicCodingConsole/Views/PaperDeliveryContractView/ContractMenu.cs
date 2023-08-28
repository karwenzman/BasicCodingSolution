using BasicCodingConsole.ConsoleMenus;
using BasicCodingLibrary.Models;

namespace BasicCodingConsole.Views.PaperDeliveryContractView;

public class ContractMenu : IMenu
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
    public ContractMenu()
    {
        IMenuContent content = new ContractMenuContent();
        CaptionItems = content.CaptionItems;
        MenuItems = content.MenuItems;
        StatusItems = content.StatusItems;

        IMenuBehavior behavior = new ContractMenuBehavior();
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
    /// <br></br>- the instance of <see cref="IAppSettingModel"/> is null
    /// <br></br>- a value of the height or width is &lt;= 0
    /// </summary>
    /// <param name="appSettingModel"></param>
    public ContractMenu(IAppSettingModel appSettingModel)
    {
        IMenuContent content = new ContractMenuContent();
        CaptionItems = content.CaptionItems;
        MenuItems = content.MenuItems;
        StatusItems = content.StatusItems;

        IMenuBehavior behavior = new ContractMenuBehavior();
        ConsoleHeightMaximum = behavior.ConsoleHeightMaximum;
        ConsoleHeightMinimum = behavior.ConsoleHeightMinimum;
        ConsoleWidthMaximum = behavior.ConsoleWidthMaximum;
        ConsoleWidthMinimum = behavior.ConsoleWidthMinimum;

        if (appSettingModel != null)
        {
            if (appSettingModel.ApplicationSetting.ConsoleHeightMaximum > 0)
            {
                ConsoleHeightMaximum = appSettingModel.ApplicationSetting.ConsoleHeightMaximum;
            }
            if (appSettingModel.ApplicationSetting.ConsoleHeightMinimum > 0)
            {
                ConsoleHeightMinimum = appSettingModel.ApplicationSetting.ConsoleHeightMinimum;
            }
            if (appSettingModel.ApplicationSetting.ConsoleWidthMaximum > 0)
            {
                ConsoleWidthMaximum = appSettingModel.ApplicationSetting.ConsoleWidthMaximum;
            }
            if (appSettingModel.ApplicationSetting.ConsoleWidthMinimum > 0)
            {
                ConsoleWidthMinimum = appSettingModel.ApplicationSetting.ConsoleWidthMinimum;
            }
        }
    }

}
