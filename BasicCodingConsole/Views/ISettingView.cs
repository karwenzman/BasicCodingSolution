using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingConsole.Models;

namespace BasicCodingConsole.Views;

public interface ISettingView
{
    /// <summary>
    /// A value used to store the configuration information.
    /// </summary>
    IAppSettingModel AppSettingModel { get; set; }
    /// <summary>
    /// A value used to control the menu's behavior.
    /// </summary>
    IMenu Menu { get; set; }
    /// <summary>
    /// A value used to control the message's behavior.
    /// </summary>
    IMessage Message { get; set; }

    /// <summary>
    /// A method used to run the view.
    /// </summary>
    void Run();
}
