using Core.Abstracts;
using Core.Enum;
using Entity.Models.Ticket;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.User;

[Table("users")]
public class UserEntity : BaseEntity<int>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }


    // relationships
    public virtual ICollection<TicketEntity> Tickets { get; set; }
}
