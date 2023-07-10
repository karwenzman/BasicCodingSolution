namespace BasicCodingConsole.ConsoleDisplays;

public class ClearingView : IClearing
{
    public void Clear()
    {
        Console.WriteLine($"Calling {nameof(ClearingView)}. Press ENTER to clear the Console...");
        Console.ReadLine();
        Console.Clear();
    }
}
