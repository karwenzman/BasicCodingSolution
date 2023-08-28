namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public class ApplicationSetting
{
    /// <summary>
    /// Not used, yet. Testing only.
    /// </summary>
    public string LastLogin { get; set; } = "default";
    /// <summary>
    /// Not used, yet. Testing only.
    /// </summary>
    public string Language { get; set; } = "default";
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
