using CsvHelper.Configuration;
using System.Globalization;

namespace PaperDeliveryLibrary.Models;

/// <summary>
/// This a helper class to read/write a csv file with a specific column order.
/// <para></para>
/// This class is using the NuGet package <see cref="CsvHelper"/>.
/// </summary>
public sealed class PaperDeliveryClientMap : ClassMap<PaperDeliveryClient>
{
    public PaperDeliveryClientMap()
    {
        AutoMap(CultureInfo.CurrentCulture);
        Map(m => m.Id).Index(0);
        Map(m => m.TradeName).Index(1);
        Map(m => m.TradeNameAdditionalInformation).Index(2);
    }
}
