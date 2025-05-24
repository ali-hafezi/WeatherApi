
using System.ComponentModel.DataAnnotations;

namespace WeatherApi.Domain.Common;

public class BaseEntity : IComparable<BaseEntity>
{
    [Key]
    public long Id { get; set; }
    public int CompareTo(BaseEntity? other)
    {
        if (Id == other.Id) return 0;
        else if (Id > other.Id) return 1;
        return -1;
    }
}
