using CommunityToolkit.Mvvm.ComponentModel;

namespace PaperDeliveryLibrary.Models;

public partial class PaperDeliverySetting : ModelBase
{
    [ObservableProperty]
    private string _ContractFile;
    [ObservableProperty]
    private string _ContractorFile;
    [ObservableProperty]
    private string _ClientFile;
    [ObservableProperty]
    private string _FulfillmentFile;
    [ObservableProperty]
    private string _PaperDeliveryDirectory;

    public PaperDeliverySetting()
    {
        ContractFile = "default";
        ContractorFile = "default";
        ClientFile = "default";
        FulfillmentFile = "default";
        PaperDeliveryDirectory = "default";
    }
}
