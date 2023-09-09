namespace BasicCodingConsole.Models
{
    public interface IConsoleSetting
    {
        ConsoleColor BackgroundColor { get; set; }
        ConsoleColor ForegroundColor { get; set; }
        int HeightMaximum { get; set; }
        int HeightMinimum { get; set; }
        int WidthMaximum { get; set; }
        int WidthMinimum { get; set; }
    }
}