using BasicCodingConsole.Providers;

namespace BasicCodingConsole.Models;

/// <summary>
/// This interface is providing members to start an application.
/// </summary>
public interface IStartup
{
    /// <summary>
    /// A value used to store the setting loaded from 'appsettings.json'.
    /// <para></para>
    /// The content is provided by <see cref="AppSettingProvider.GetAppSetting()"/>.
    /// </summary>
    AppSetting AppSetting { get; set; }

    /// <summary>
    /// A method used to run <see cref="Startup"/>.
    /// </summary>
    void Run();

    /// <summary>
    /// A method used to write the content of <see cref="AppSetting"/> to a console.
    /// </summary>
    void WriteAppSettingToConsole();
}
