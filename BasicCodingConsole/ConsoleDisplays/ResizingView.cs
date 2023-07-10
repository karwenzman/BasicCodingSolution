using System.Runtime.Versioning;

namespace BasicCodingConsole.ConsoleDisplays;

[SupportedOSPlatform("windows")]
public class ResizingView : IResizing
{
    public void Resize(int consoleWidth, int consoleHeight)
    {
        Console.WriteLine($"Calling {nameof(ResizingView)}. Press ENTER to simulate resizing the console...");
        Console.ReadLine();
        //Console.SetWindowSize(consoleWidth, consoleHeight);
    }
}
