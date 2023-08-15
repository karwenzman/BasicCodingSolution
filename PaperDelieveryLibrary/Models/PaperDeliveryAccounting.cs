using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperDeliveryLibrary.Models;

public class PaperDeliveryAccounting
{
    public string ContractId { get; set; } = "default";
    public string ContractorName { get; set; } = "default";
    public int NumberOfPapers { get; set; }
    public TimeOnly StandardizedWorkingHours { get; set; }
    public TimeOnly WorkingHours { get; set; }
    public double HourlyWageRate { get; set; }
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
