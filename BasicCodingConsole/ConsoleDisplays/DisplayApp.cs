namespace BasicCodingConsole.ConsoleDisplays;

public class DisplayApp : IDisplay
{
    public void Clear()
    {
        IClearing clearingView = new ClearingApp();
        clearingView.Clear();
    }

    public void Resize(int consoleWidth, int consoleHeight)
    {
        IResizing resizeView = new ResizingApp();
        resizeView.Resize(consoleWidth, consoleHeight);
    }
}
