using Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.Ticket
{
    public class TicketOperationLogEntity : BaseEntity<int>
    {
        public int TicketId { get; set; }
        public string OperationUserId { get; set; }
        public string OperationStatus { get; set; }

        // relationships
        public virtual TicketEntity Ticket { get; set; }
    }
}
