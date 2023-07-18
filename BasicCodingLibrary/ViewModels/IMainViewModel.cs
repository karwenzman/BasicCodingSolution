using BasicCodingLibrary.Models;

namespace BasicCodingLibrary.ViewModels;

/// <summary>
/// This interface is providing the access to the class <see cref="AppSettings"/>.
/// </summary>
public interface IMainViewModel
{
    string DefaultMessage { get; set; }
    string ClassName { get; set; }
    AppSettingModel AppSetting { get; set; }

    /// <summary>
    /// This method is getting the current values of <see cref="MainViewModel"/>.
    /// <para>
    /// A new snapshot of the file 'appsettings.json' should be implemented from derived classes.
    /// </para>
    /// </summary>
    /// <returns>An instance of class <see cref="MainViewModel"/>.</returns>
    MainViewModel Get();
}
