using CsvHelper.Configuration;
using System.Globalization;

namespace PaperDeliveryLibrary.Models;

public sealed class PaperDeliveryContractorMap : ClassMap<PaperDeliveryContractor>
{
    /// <summary>
    /// This a helper class to read/write a csv file with a specific column order.
    /// <para></para>
    /// This class is using the NuGet package <see cref="CsvHelper"/>.
    /// </summary>
    public PaperDeliveryContractorMap()
    {
        AutoMap(CultureInfo.CurrentCulture);
        Map(m => m.Id).Index(0);
        Map(m => m.FirstName).Index(1);
        Map(m => m.LastName).Index(2);
        Map(m => m.Site).Index(3);
    }
}
