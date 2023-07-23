using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;
using BasicCodingLibrary.Models;

namespace BasicCodingConsole.Views.SettingView;

/// <summary>
/// This interface is providing members to write the configuration information to a console.
/// </summary>
public interface ISettingViewVersion2
{
    /// <summary>
    /// A value used to store the configuration information.
    /// </summary>
    IAppSettingModel AppSettingModel { get; set; }
    /// <summary>
    /// A value used to control the display's behavior.
    /// </summary>
    IDisplay Display { get; set; }
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
