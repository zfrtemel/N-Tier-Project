using Core.Abstracts;
using Core.Enum;
using Entity.Models.Ticket;

namespace Entity.Models.User
{
    public class UserEntity : BaseEntity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public EUserRole Role { get; set; }


        // relationships
        public virtual ICollection<TicketEntity> Tickets { get; set; }
    }
}
