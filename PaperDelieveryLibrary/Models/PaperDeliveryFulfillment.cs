using PaperDeliveryLibrary.Enums;

namespace PaperDeliveryLibrary.Models;

public class PaperDeliveryFulfillment
{
    public PaperDeliveryContract Contract { get; set; } = new PaperDeliveryContract();
    public PaperDeliveryContractor Contractor { get; set; } = new PaperDeliveryContractor();
    public Fulfillment Fulfillment { get; set; } = Fulfillment.None;
    public TimeOnly WorkingHours { get; set; }
}
