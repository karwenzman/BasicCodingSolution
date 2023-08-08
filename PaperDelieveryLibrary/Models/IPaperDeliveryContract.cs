namespace PaperDeliveryLibrary.Models;

public interface IPaperDeliveryContract
{
    string ContractID { get; set; }
    double HourlyWageRate { get; set; }
    int NumberOfPapers { get; set; }
    string Region { get; set; }
    string Route { get; set; }
    string Site { get; set; }
    TimeOnly StandardizedWorkingHours { get; set; }
    double Wage { get; }
}