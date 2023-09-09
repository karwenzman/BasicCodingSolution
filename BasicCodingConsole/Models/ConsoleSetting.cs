namespace BasicCodingConsole.Models;

public sealed class ConsoleSetting : IConsoleSetting
{
    public ConsoleColor BackgroundColor { get; set; }
    public ConsoleColor ForegroundColor { get; set; }
    public int HeightMaximum { get; set; }
    public int HeightMinimum { get; set; }
    public int WidthMaximum { get; set; }
    public int WidthMinimum { get; set; }
}
