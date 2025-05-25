
using System.ComponentModel.DataAnnotations;

namespace WeatherApi.Domain.Common;

public abstract class BaseEntity : IComparable<BaseEntity>
{
    [Key]
    public long Id { get; set; }
    public bool IsDeleted { get; protected set; } =false;
    public DateTime? DeleteTime { get; protected set; } = null;
    public int CompareTo(BaseEntity? other)
    {
        if (Id == other.Id) return 0;
        else if (Id > other.Id) return 1;
        return -1;
    }
}
