namespace PaperDeliveryLibrary.Models;

public class PaperDeliverySetting
{
    public string ContractFile { get; set; } = "default";
    public string ContractorFile { get; set; } = "default";
    public string ClientFile { get; set; } = "default";
    public string FulfillmentFile { get; set; } = "default";
    public string PaperDeliveryDirectory { get; set; } = "default";
}
