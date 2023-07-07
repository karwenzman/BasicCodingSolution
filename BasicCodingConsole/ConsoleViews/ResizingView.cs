﻿using System.Runtime.Versioning;

namespace BasicCodingConsole.ConsoleViews;

[SupportedOSPlatform("windows")]
public class ResizingView : IResizing
{
    public void Resize(int consoleWidth, int consoleHeight)
    {
        Console.WriteLine($"Calling {nameof(ResizingView)}. Press ENTER to simulate resizing the view ...");
        Console.ReadLine();
        //Console.SetWindowSize(consoleWidth, consoleHeight);
    }
}
