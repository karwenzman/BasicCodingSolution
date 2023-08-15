namespace PaperDeliveryLibrary.Models;

public class PostalAddress
{
    public string AdditionalInformation { get; set; } = "default";
    public string City { get; set; } = "default";
    public string Country { get; set; } = "default";
    public string PostalCode { get; set; } = "default";
    public string Street { get; set; } = "default";
}
