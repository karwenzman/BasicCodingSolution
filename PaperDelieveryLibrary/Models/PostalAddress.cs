namespace PaperDeliveryLibrary.Models;

public class PostalAddress
{
    /// <summary>
    /// The contact's additional street information.
    /// </summary>
    public string AdditionalInformation { get; set; } = "default";
    /// <summary>
    /// The contact's city.
    /// </summary>
    public string City { get; set; } = "default";
    /// <summary>
    /// The contact's country.
    /// </summary>
    public string Country { get; set; } = "default";
    /// <summary>
    /// The contact's postal code.
    /// </summary>
    public string PostalCode { get; set; } = "default";
    /// <summary>
    /// The contact's street information.
    /// </summary>
    public string Street { get; set; } = "default";
}
