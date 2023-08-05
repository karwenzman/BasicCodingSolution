using BasicCodingLibrary.Enums;

namespace PaperDelieveryLibrary.Models;

public class PaperDelieveryFulfillment : IPaperDelieveryFulfillment
{
    public IPaperDeliveryContract Contract { get; set; } = new PaperDeliveryContract();
    public IPaperDeliveryContractor Contractor { get; set; } = new PaperDeliveryContractor();
    public Fulfillment Fulfillment { get; set; } = Fulfillment.None;
    public DateTime WorkingHours { get; set; }
}
