using PaperDelieveryLibrary.Models;

namespace PaperDelieveryLibrary.Providers;

public class PaperDeliveryProvider
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
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230729KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 58, 00),
            },
            new PaperDeliveryContract
            {
                ContractID = "20230722KA",
                HourlyWageRate = 12.00,
                NumberOfPapers = 205,
                Region = "02166",
                Route = "KA09",
                Site = "809",
                StandardizedWorkingHours = new TimeOnly(01, 25, 00),
            }
        };

        return output;
    }
    public PaperDeliveryContractor GetContractor()
    {
        PaperDeliveryContractor output = new PaperDeliveryContractor();
        return output;
    }
    public PaperDeliveryFulfillment GetFulfillment()
    {
        PaperDeliveryFulfillment output = new PaperDeliveryFulfillment();

        return output;
    }
}
