using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_Core_Project.Data.Config
{
    public class Converter : ValueConverter<DateOnly, DateTime>
    {
        public Converter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
        { 
        }
    }
}
