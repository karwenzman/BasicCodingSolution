﻿using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.SettingView;

public interface ISettingView
{
    /// <summary>
    /// A value used to control the menu's behavior.
    /// </summary>
    IMenu Menu { get; set; }
    /// <summary>
    /// A value used to control the message's behavior.
    /// </summary>
    IMessage Message { get; set; }

    /// <summary>
    /// A method used to run the view.
    /// </summary>
    void Run();
}
