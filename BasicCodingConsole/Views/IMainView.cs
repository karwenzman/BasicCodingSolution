using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views;

public interface IMainView
{
    IMenu Menu { get; }
    IMessage Message { get; }
    void Run();
}
