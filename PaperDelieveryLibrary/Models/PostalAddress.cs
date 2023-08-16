namespace PaperDeliveryLibrary.Models;

public class PostalAddress
{
    public string Street { get; set; } = "default";

    public string StreetAdditionalInformation { get; set; } = "default";

    public string PostalCode { get; set; } = "default";

    public string City { get; set; } = "default";

    public string Country { get; set; } = "default";
}
