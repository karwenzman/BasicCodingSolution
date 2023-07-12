using BasicCodingConsole.ConsoleMenus;
using System.Runtime.InteropServices;
using System.Text;

namespace BasicCodingConsole.Views;

public abstract class ViewBase
{
    /// <summary>
    /// This const stores the height's minimum value of the menu's frame.
    /// </summary>
    internal const int frameHeightMinimum = 20;
    /// <summary>
    /// This const stores the width's minimum value of the menu's frame.
    /// </summary>
    internal const int frameWidthMinimum = 80;
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
        ResizeConsoleIfNeededAndClearIt();

        if (menu.CaptionItems != null || menu.MenuItems != null || menu.StatusItems != null)
        {
            WriteHorizontalFrame();
        }

        WriteItems(menu.CaptionItems, frameCharacter);
        WriteItems(menu.MenuItems, frameCharacter);
        WriteItems(menu.StatusItems, frameCharacter);

        // TODO: sometimes the width is one character to wide;
        // is this depending on debug, production or on the kind of distribution?
        //Console.WriteLine($"Height - Console:{Console.WindowHeight,3} | Frame:{frameHeight,3}");
        //Console.WriteLine($"Width  - Console:{Console.WindowWidth,3} | Frame:{frameWidth,3}");
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
    protected void ResizeConsoleIfNeededAndClearIt()
    {
        if (IsViewResizingNeeded())
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.SetWindowSize(frameWidthMinimum, frameHeightMinimum);
            }
            else
            {
                // TODO: how can I make this available on all OS? not only windows?
                Console.WriteLine("Sorry, resizing is not implemented for your OS.");
            }
        }
        Console.Clear();
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
    /// This method is checking if the current console is size below a defined value 
    /// that is stored in <see cref="frameHeightMinimum"/> and <see cref="frameWidthMinimum"/>.
    /// </summary>
    /// <returns>True, if resize is necessary.</returns>
    private bool IsViewResizingNeeded()
    {
        bool isResize = false;
        if (Console.WindowHeight < frameHeightMinimum)
        {
            isResize = true;
        }

        if (Console.WindowWidth < frameWidthMinimum)
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
