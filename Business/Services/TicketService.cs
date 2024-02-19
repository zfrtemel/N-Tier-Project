using Business.Interfaces;
using Core.Web.Enum;
using Entity.Models.Ticket;

namespace Business.Services;
public class TicketService : ITicketService
{
    public bool CreateTicket(TicketEntity ticket)
    {
        throw new NotImplementedException();
    }

    public TicketEntity GetTicket(int id)
    {
        throw new NotImplementedException();
    }

    public ICollection<TicketEntity> GetTickets()
    {
        throw new NotImplementedException();
    }

    public bool UpdateStatus(int id, ETicketStatus status)
    {
        throw new NotImplementedException();
    }
}
