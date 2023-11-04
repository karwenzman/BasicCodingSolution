using CommunityToolkit.Mvvm.ComponentModel;

namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public partial class ApplicationSetting : ModelBase
{
    [ObservableProperty]
    private string _LastLogin;
    [ObservableProperty]
    private string _Language;

    public ApplicationSetting()
    {
        LastLogin = "default";
        Language = "default";
    }
}
