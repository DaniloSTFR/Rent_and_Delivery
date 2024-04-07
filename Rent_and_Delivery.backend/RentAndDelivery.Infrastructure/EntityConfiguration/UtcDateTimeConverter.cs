using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RentAndDelivery.Infrastructure.EntityConfiguration
{
public class UtcDateTimeConverter : ValueConverter<DateTime?, DateTime?>
{
    public UtcDateTimeConverter()
        : base(
            d => !d.HasValue ? null : ConvertToUtc(d.Value),
            d => !d.HasValue ? null : SpecifyUtc(d.Value))
    {
    }

    private static DateTime ConvertToUtc(DateTime date)
    {
        switch (date.Kind)
        {
        case DateTimeKind.Utc:
            return date;
        case DateTimeKind.Local:
            return date.ToUniversalTime();
        default:
            throw new InvalidTimeZoneException($"Unsupported DateTimeKind: {date.Kind}");
        }
    }

    private static DateTime SpecifyUtc(DateTime date)
    {
        return DateTime.SpecifyKind(date, DateTimeKind.Utc);
    }
}
}