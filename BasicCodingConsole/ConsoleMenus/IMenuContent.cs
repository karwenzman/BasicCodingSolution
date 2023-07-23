namespace BasicCodingConsole.ConsoleMenus;

/// <summary>
/// This interface is providing members to setup the menu's content.
/// </summary>
public interface IMenuContent
{
    /// <summary>
    /// A value used to control the menu's caption items.
    /// </summary>
    string[]? CaptionItems { get; set; }
    /// <summary>
    /// A value used to control the menu's menu items.
    /// </summary>
    string[]? MenuItems { get; set; }
    /// <summary>
    /// A value used to control the menu's status items.
    /// </summary>
    string[]? StatusItems { get; set; }
}
