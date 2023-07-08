namespace BasicCodingConsole.Views;

public class ViewBase
{
    #region ***** Const *****
    /// <summary>
    /// This property stores the height's minimum value of the menu's frame.
    /// </summary>
    internal const int frameHeightMinimum = 20;
    /// <summary>
    /// This property stores the width's minimum value of the menu's frame.
    /// </summary>
    internal const int frameWidthMinimum = 80;
    #endregion

    #region ***** Field *****
    /// <summary>
    /// This property stores the messages to be written into the caption section.
    /// </summary>
    public string[]? captionMessages;
    /// <summary>
    /// This property stores the messages to be written into the menu section.
    /// </summary>
    public string[]? menuMessages;
    /// <summary>
    /// This property stores the messages to be written into the status section.
    /// </summary>
    public string[]? statusMessages;
    /// <summary>
    /// This property stores the character used for writing the menu's frame.
    /// </summary>
    public char frameCharacter;
    /// <summary>
    /// This property stores the height of the menu's frame.
    /// </summary>
    public int frameHeight;
    /// <summary>
    /// This property stores the width of the menu's frame.
    /// </summary>
    public int frameWidth;
    #endregion

    #region ***** Protected Member *****
    /// <summary>
    /// This method is drawing the complete menu.
    /// The menu's look is depending on the provided arguments.
    /// </summary>
    /// <param name="caption">The header of the menu.</param>
    /// <param name="menu">The body of the menu.</param>
    /// <param name="status">The footer of the menu.</param>
    /// <param name="frame">Character used to draw the frame. This is an optional argument.</param>
    protected void DrawHeader(string[]? caption, string[]? menu, string[]? status, char frame = '*')
    {
        captionMessages = caption;
        menuMessages = menu;
        statusMessages = status;
        frameCharacter = frame;

        CheckWindowSize();
        Console.CursorVisible = false;

        GetFrameWidth();
        if (caption != null | menu != null | status != null)
        {
            DrawHorizontalFrame();
        }
        DrawCaptionMessages();
        DrawMenuMessages();
        DrawStatusMessage();

        // TODO:
        Console.WriteLine($"Height - Console:{Console.WindowHeight,3} | Frame:{frameHeight,3}");
        Console.WriteLine($"Width  - Console:{Console.WindowWidth,3} | Frame:{frameWidth,3}");
    }

    public void CheckWindowSize()
    {
        Console.Clear();
        GetFrameWidth();
    }
    #endregion

    #region ***** Private Member *****
    /// <summary>
    /// This method is drawing the content of the caption section.
    /// <para>
    /// Depending on the property <see cref="captionMessages"/> the content is drawn on screen.
    /// If the property is <see href="Null"/>, there is no output on the screen.
    /// </para>
    /// </summary>
    private void DrawCaptionMessages()
    {
        if (captionMessages == null)
        {
            return;
        }

        for (int i = 0; i < captionMessages.Length; i++)
        {
            string message = Convert.ToString(frameCharacter).PadRight(2);
            message += captionMessages[i].PadRight(frameWidth - 4);
            message += Convert.ToString(frameCharacter).PadLeft(2);

            Console.WriteLine(message);
        }

        DrawHorizontalFrame();
    }

    /// <summary>
    /// This method is drawing the content of the menu section.
    /// <para>
    /// Depending on the property <see cref="menuMessages"/> the content is drawn on screen.
    /// If the property is <see href="Null"/>, there is no output on the screen.
    /// </para>
    /// </summary>
    private void DrawMenuMessages()
    {
        if (menuMessages == null)
        {
            return;
        }

        for (int i = 0; i < menuMessages.Length; i++)
        {
            string message = Convert.ToString(frameCharacter).PadRight(2);
            message += menuMessages[i].PadRight(frameWidth - 4);
            message += Convert.ToString(frameCharacter).PadLeft(2);

            Console.WriteLine(message);

        }

        DrawHorizontalFrame();
    }

    /// <summary>
    /// This method is drawing the content of the status section.
    /// <para>
    /// Depending on the property <see cref="statusMessages"/> the content is drawn on screen.
    /// If the property is <see href="Null"/>, there is no output on the screen.
    /// </para>
    /// </summary>
    private void DrawStatusMessage()
    {
        if (statusMessages == null)
        {
            return;
        }

        for (int i = 0; i < statusMessages.Length; i++)
        {
            string message = Convert.ToString(frameCharacter).PadRight(2);
            message += statusMessages[i].PadRight(frameWidth - 4);
            message += Convert.ToString(frameCharacter).PadLeft(2);

            Console.WriteLine(message);
        }

        DrawHorizontalFrame();
    }

    /// <summary>
    /// This method is drawing a single horizontal frame.
    /// <para>
    /// Depending on the properties <see cref="frameCharacter"/>
    /// and <see cref="frameWidth"/> the appearence will be adapted.
    /// </para>
    /// </summary>
    private void DrawHorizontalFrame()
    {
        Console.WriteLine(frameCharacter.ToString().PadLeft(frameWidth, frameCharacter));
    }

    /// <summary>
    /// This method is evaluating the menu width
    /// by inspecting <see cref="menuMessages"/> members.
    /// </summary>
    /// <returns></returns>
    private void GetFrameWidth()
    {
        bool isResize = false;
        frameHeight = Console.WindowHeight;
        frameWidth = Console.WindowWidth; // when published the behaviour is different to debug mode

        if (frameHeight < frameHeightMinimum)
        {
            frameHeight = frameHeightMinimum;
            isResize = true;
        }

        if (frameWidth < frameWidthMinimum)
        {
            frameWidth = frameWidthMinimum;
            isResize = true;
        }

        try
        {
            if (isResize)
            {
                Console.SetWindowSize(frameWidth, frameHeight);
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine(e.ToString());
            Console.WriteLine("An exception was raised! Press ENTER to continue.");
            Console.ReadLine();
        }
    }
    #endregion
}
