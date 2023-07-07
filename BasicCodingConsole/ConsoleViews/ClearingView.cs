namespace BasicCodingConsole.ConsoleViews;

public class ClearingView : IClearing
{
    public void Clear()
    {
        Console.WriteLine($"Calling {nameof(ClearingView)}. Press ENTER to clear the view ...");
        Console.ReadLine();
        Console.Clear();
    }
}
