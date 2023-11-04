using CommunityToolkit.Mvvm.ComponentModel;

namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public partial class ConnectionStrings : ModelBase
{
    [ObservableProperty]
    private string _Default;
    [ObservableProperty]
    private string _RootDirectory;

    public ConnectionStrings()
    {
        Default = "Default Value";
        RootDirectory = Environment.CurrentDirectory;
    }
}
