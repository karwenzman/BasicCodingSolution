namespace BasicCodingConsole.ConsoleMenus;

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
