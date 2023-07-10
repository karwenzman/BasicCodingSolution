using System.Runtime.Versioning;

namespace BasicCodingConsole.ConsoleDisplays;

[SupportedOSPlatform("windows")]
public class ResizingApp : IResizing
{
    public void Resize(int consoleWidth, int consoleHeight)
    {
        Console.WriteLine($"Calling {nameof(ResizingApp)}. Press ENTER to simulate resizing the console...");
        Console.ReadLine();
        //Console.SetWindowSize(consoleWidth, consoleHeight);
    }
}
