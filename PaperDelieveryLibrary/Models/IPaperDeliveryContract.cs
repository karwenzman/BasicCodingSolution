namespace BasicCodingLibrary.Models;

public interface IPaperDeliveryContract
{
    string ContractID { get; set; }
    int HourlyWageRate { get; set; }
    int NumberOfPapers { get; set; }
    string Region { get; set; }
    string Route { get; set; }
    string Site { get; set; }
    DateTime StandardizedWorkingHours { get; set; }
}