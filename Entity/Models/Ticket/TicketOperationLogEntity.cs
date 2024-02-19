using Core.Abstracts;
using Core.Web.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Ticket
{
    [Table("ticket_operation_logs")]
    public class TicketOperationLogEntity : BaseEntity<int>
    {
        public int TicketId { get; set; }
        public int OperationUserId { get; set; }
        public ETicketStatus OperationStatus { get; set; }

        // relationships
        public virtual TicketEntity Ticket { get; set; }
    }
}
