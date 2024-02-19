using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Interfaces.Models;

public interface ISoftDelete
{
    public DateTime? DeletedAt { get; set; }

    [NotMapped]
    public bool BypassSoftDelete { get; set; }
}
