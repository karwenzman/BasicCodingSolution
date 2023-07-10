namespace BasicCodingConsole.ConsoleDisplays;

public class ClearingApp : IClearing
{
    public void Clear()
    {
        Console.WriteLine($"Calling {nameof(ClearingApp)}. Press ENTER to clear the console...");
        Console.ReadLine();
        Console.Clear();
    }
}
