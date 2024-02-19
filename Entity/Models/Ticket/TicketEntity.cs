using Core.Abstracts;
using Core.Web.Enum;
using Entity.Models.User;

namespace Entity.Models.Ticket
{
    public class TicketEntity : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Subject { get; set; }
        public ETicketStatus Status { get; set; }
        public int UserId { get; set; }

        // relations
        public virtual UserEntity User { get; set; }
        public virtual ICollection<TicketOperationLogEntity> TicketOperationLogs { get; set; }
    }
}
