using Business.Request;
using Core.Web.Enum;
using Entity.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces;
public interface ITicketService
{
    public ICollection<TicketEntity> GetTickets();
    public TicketEntity GetTicket(int id);
    public bool CreateTicket(CreateTicketRequest request);
    public bool UpdateStatus(int id, ETicketStatus status);
}
