namespace PaperDelieveryLibrary.Models;

public class PaperDeliveryContract : IPaperDeliveryContract
{
    public string ContractID { get; set; } = "default";
    public double HourlyWageRate { get; set; }
    public int NumberOfPapers { get; set; }
    public string Region { get; set; } = "default";
    public string Route { get; set; } = "default";
    public string Site { get; set; } = "default";
    public TimeOnly StandardizedWorkingHours { get; set; }
    public double Wage
    {
        get
        {
            double output = HourlyWageRate * StandardizedWorkingHours.Hour;
            output += HourlyWageRate * StandardizedWorkingHours.Minute;
            return output;
        }
    }
}
