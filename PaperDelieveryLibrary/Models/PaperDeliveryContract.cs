namespace PaperDeliveryLibrary.Models;

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
            var resultWageHour = HourlyWageRate * StandardizedWorkingHours.Hour;
            var resultWageMinute = HourlyWageRate * StandardizedWorkingHours.Minute * 1 / 60;
            var resultWageSecond = HourlyWageRate * StandardizedWorkingHours.Second * 1 / 3600;
            var output = resultWageHour + resultWageMinute + resultWageSecond;
            return output;
        }
    }
}
