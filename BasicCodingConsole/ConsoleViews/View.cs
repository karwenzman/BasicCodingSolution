namespace BasicCodingConsole.ConsoleViews;

public class View : IView
{
    public void Clear()
    {
        IClearing clearingView = new ClearingView();
        clearingView.Clear();
    }

    public void Resize(int consoleWidth, int consoleHeight)
    {
        IResizing resizeView = new ResizingView();
        resizeView.Resize(consoleWidth, consoleHeight);
    }
}
