using CommunityToolkit.Mvvm.ComponentModel;

namespace BasicCodingLibrary.Models;

/// <summary>
/// This class is providing a section of the <b>appsettings.json</b> file.
/// </summary>
public partial class UserSetting : ModelBase
{
    [ObservableProperty]
    private string _NickName;
    [ObservableProperty]
    private UserDetails _UserDetails;

    public UserSetting()
    {
        NickName = "default";
        UserDetails = new UserDetails();
    }
}
