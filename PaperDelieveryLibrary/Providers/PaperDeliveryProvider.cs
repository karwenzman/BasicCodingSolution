using PaperDelieveryLibrary.Models;

namespace PaperDelieveryLibrary.Providers;

public class PaperDelieveryProvider
{
    public List<PaperDeliveryContract> GetContractList()
    {
        List<PaperDeliveryContract> output = new()
        {
            new PaperDeliveryContract
            {
                ContractID = "20230805KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(00, 01, 58),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230729KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(00, 01, 58),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230722KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(00, 01, 25),
            }
        };

        return output;
    }
    public PaperDeliveryContractor GetContractor()
    {
        PaperDeliveryContractor output = new PaperDeliveryContractor();
        return output;
    }
    public PaperDelieveryFulfillment GetFulfillment()
    {
        PaperDelieveryFulfillment output = new PaperDelieveryFulfillment();

        return output;
    }
}
