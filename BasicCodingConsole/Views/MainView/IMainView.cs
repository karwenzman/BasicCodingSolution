﻿using BasicCodingConsole.ConsoleDisplays;
using BasicCodingConsole.ConsoleMenus;
using BasicCodingConsole.ConsoleMessages;

namespace BasicCodingConsole.Views.MainView;

public interface IMainView
{
    IMenu Menu { get; }
    IMessageApp Message { get; }
    IDisplay Display { get; }
    void Run(string[] args);
}
