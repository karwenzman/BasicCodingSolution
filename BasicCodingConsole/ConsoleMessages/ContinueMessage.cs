using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCodingConsole.ConsoleMessages;

public class ContinueMessage : IMessaging
{
    public string CallingClass => "not set";

    public void Show()
    {
        Console.WriteLine($"\nPress ENTER to continue...");
        Console.ReadLine();
    }
}
