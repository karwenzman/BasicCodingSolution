Application:	BasicCodingConsole
Framework:      .Net 7.0
Developer:      karwenzman
File:           readme.txt

Configuration
=============
There are several ways to configure the application. The program is using the featured configuration by C#.
- file appsettings.json
- file appsettings.Production.json
- file launchSettings.json (to be accessed via 'Properties')
- file secrets.json (to be accessed via 'Geheime Benutzerschlüssel verwalten')
- 'args' read from command line or launchSettings.json

Through these featured configuration the user can alter the applictation's behavior without the need to 
re-compile the project. Thus, the program can be configured to apply to the user's needs.
There are several sections implemented in the base configuration file appsettings.json.
- UserSetting
- ConsoleSetting
- PaperDeliverySetting

If the configuration files are missing, a fallback behavior is implemented. In such a case hard coded
values are read from classes.

Solutionfolder
==============
The solution is consisting of several single projects.
The frontend applications:
- BasicCodingConsole
- BasicCodingWpf
The backend libraries:
- BasicCodingLibrary
- PaperDeliveryLibrary
The testing environment:
- BasicCodingTest

Information
===========
Right now, I am just working on the ConsoleApp on the frontend side.
I am focusing on the mechanics of configuration and on the PaperDeliveryLibrary.
My goal is to design the library in such a way that the WpfApp can use it without any change.

History
=======
Version 1.0.0.0
Basic setup of directories, assemblies, dependencies and files.
Basic setup of methods to publish the app.
