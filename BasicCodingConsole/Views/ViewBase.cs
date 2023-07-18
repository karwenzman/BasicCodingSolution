using BasicCodingConsole.ConsoleMenus;
using System.Runtime.InteropServices;
using System.Text;

namespace BasicCodingConsole.Views;

public abstract class ViewBase
{
    /// <summary>
    /// This const stores the padding character needed to write the menu items.
    /// </summary>
    internal const char framePadding = ' ';

    /// <summary>
    /// This method is writing the complete menu.
    /// The menu's look is depending on the provided arguments.
    /// <para></para>
    /// Before writing the menu 
    /// <br></br>- a check of the console's size is performed
    /// <br></br>- the console is cleared
    /// </summary>
    /// <param name="menu">The menu's content.</param>
    /// <param name="frameCharacter">Character used to draw the frame. This is an optional argument.</param>
    protected void WriteMenu(IMenu menu, char frameCharacter = '*')
    {
        ResizeConsoleIfNeededAndClearIt(menu);

        if (menu.CaptionItems != null || menu.MenuItems != null || menu.StatusItems != null)
        {
            WriteHorizontalFrame();
        }

        WriteItems(menu.CaptionItems, frameCharacter);
        WriteItems(menu.MenuItems, frameCharacter);
        WriteItems(menu.StatusItems, frameCharacter);

        // TODO: sometimes the width is one character to wide;
        // is this depending on debug, production or on the kind of distribution?
        // if resizing to full screen, the app is minimizing the console, but the screen stays in full screen
        Console.WriteLine($"Height - Console:{Console.WindowHeight,3}");
        Console.WriteLine($"Width  - Console:{Console.WindowWidth,3}");
    }

    /// <summary>
    /// This method is checking, if the console needs to be resized.
    /// If true, the console is resized to the minimum size it should have.
    /// Finally the console is cleared.
    /// <br></br>
    /// Currently resizing is supported for WindowsOS, only.
    /// <para></para>
    /// Resize may be necessary, if the user has manually altered the console size below
    /// a defined value that is stored in <see cref="frameHeightMinimum"/> and
    /// <see cref="frameWidthMinimum"/>.
    /// </summary>
    protected void ResizeConsoleIfNeededAndClearIt(IMenu menu)
    {
        if (IsConsoleSizeSmallerThenMinimum(menu))
        {
            ResizeConsole(menu.ConsoleWidthMinimum, menu.ConsoleHeightMinimum);
        }
        else if (IsConsoleSizeBiggerThenMaximum(menu))
        {
            ResizeConsole(menu.ConsoleWidthMaximum, menu.ConsoleHeightMaximum);
        }
        Console.Clear();
    }

    /// <summary>
    /// This method is actually performing the resizing of the console.
    /// </summary>
    /// <param name="consoleWidth"></param>
    /// <param name="consoleHeight"></param>
    private void ResizeConsole(int consoleWidth, int consoleHeight)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.SetWindowSize(consoleWidth, consoleHeight);
        }
        else
        {
            // TODO: how can I make this available on all OS? not only windows?
            Console.WriteLine("Sorry, resizing is not implemented for your OS.");
        }
    }

    /// <summary>
    /// This method is drawing a single horizontal frame.
    /// </summary>
    /// <param name="frameCharacter">Setting the frame's appearance.</param>
    private void WriteHorizontalFrame(char frameCharacter = '*')
    {
        Console.WriteLine("".PadLeft(Console.WindowWidth, frameCharacter));
    }

    /// <summary>
    /// This method is checking if the current console is smaller then a defined value 
    /// that is stored in <see cref="IMenuBehavior.ConsoleHeightMinimum"/> and <see cref="IMenuBehavior.ConsoleWidthMinimum"/>.
    /// </summary>
    /// <returns>True, if resize is necessary.</returns>
    private bool IsConsoleSizeSmallerThenMinimum(IMenu menu)
    {
        bool isResize = false;
        if (Console.WindowHeight < menu.ConsoleHeightMinimum)
        {
            isResize = true;
        }

        if (Console.WindowWidth < menu.ConsoleWidthMinimum)
        {
            isResize = true;
        }
        return isResize;
    }

    /// <summary>
    /// This method is checking if the current console is size bigger then a defined value 
    /// that is stored in <see cref="IMenuBehavior.ConsoleHeightMaximum"/> and <see cref="IMenuBehavior.ConsoleWidthMaximum"/>.
    /// </summary>
    /// <returns>True, if resize is necessary.</returns>
    private bool IsConsoleSizeBiggerThenMaximum(IMenu menu)
    {
        bool isResize = false;
        if (Console.WindowHeight > menu.ConsoleHeightMaximum)
        {
            isResize = true;
        }

        if (Console.WindowWidth > menu.ConsoleWidthMaximum)
        {
            isResize = true;
        }
        return isResize;
    }

    /// <summary>
    /// This method is writing the items appending the menu.
    /// <para></para>
    /// If there are items to be written to the console,
    /// then a horizontal frame will be appended.
    /// </summary>
    /// <param name="items"></param>
    /// <param name="frameCharacter"></param>
    private void WriteItems(string[]? items, char frameCharacter = '*')
    {
        if (items == null)
        {
            return;
        }

        StringBuilder sb = new StringBuilder();
        foreach (var message in items)
        {
            sb.Append(frameCharacter)
              .Append(framePadding)
              .Append(message.PadRight(Console.WindowWidth - 4))
              .Append(framePadding)
              .Append(frameCharacter)
              .AppendLine();
        }
        Console.Write(sb);

        WriteHorizontalFrame();
    }
}
