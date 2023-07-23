namespace BasicCodingConsole.ConsoleMenus;

/// <summary>
/// This interface is providing members to setup the menu's behavior.
/// </summary>
public interface IMenuBehavior
{
    /// <summary>
    /// A value used to control the console size.
    /// </summary>
    public int ConsoleHeightMaximum { get; set; }
    /// <summary>
    /// A value used to control the console size.
    /// </summary>
    public int ConsoleHeightMinimum { get; set; }
    /// <summary>
    /// A value used to control the console size.
    /// </summary>
    public int ConsoleWidthMaximum { get; set; }
    /// <summary>
    /// A value used to control the console size.
    /// </summary>
    public int ConsoleWidthMinimum { get; set; }
}
