using BasicCodingLibrary.Enums;

namespace PaperDeliveryLibrary.Models;

public interface IPaperDeliveryFulfillment
{
    IPaperDeliveryContract Contract { get; set; }
    IPaperDeliveryContractor Contractor { get; set; }
    Fulfillment Fulfillment { get; set; }
    DateTime WorkingHours { get; set; }
}