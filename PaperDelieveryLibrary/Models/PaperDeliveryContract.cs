namespace BasicCodingLibrary.Models;

public class PaperDeliveryContract : IPaperDeliveryContract
{
    public string ContractID { get; set; } = "default";
    public int HourlyWageRate { get; set; }
    public int NumberOfPapers { get; set; }
    public string Region { get; set; } = "default";
    public string Route { get; set; } = "default";
    public string Site { get; set; } = "default";
    public DateTime StandardizedWorkingHours { get; set; }
}
