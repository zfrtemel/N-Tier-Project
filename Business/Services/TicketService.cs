using Business.Interfaces;
using Business.Repositories.Abstract;
using Business.Request;
using Core.Enum;
using Core.Exceptions;
using Core.Web.Enum;
using DataAccess.Interfaces;
using Entity.Models.Ticket;

namespace Business.Services;
public class TicketService : ITicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly ITicketRepository _ticketRepository;
    public TicketService(IUnitOfWork unitOfWork, IAuthService authService, ITicketRepository ticketRepository)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
        _ticketRepository = ticketRepository;
    }
    public bool CreateTicket(CreateTicketRequest request)
    {
        var customer = _authService.GetAuthUser();
        if (customer.Role != nameof(EUserRole.CUSTOMER)) throw new Exception("unauthorizedAccess");

        _unitOfWork.Add(new TicketEntity
        {
            Title = request.Title,
            Subject = request.Subject,
            Status = ETicketStatus.Open,
            UserId = customer.Id
        });
        _unitOfWork.Commit();
        return true;
    }

    public TicketEntity GetTicket(int id)
    {
        var ticket = _ticketRepository.Get(id);
        if (ticket == null) throw new BaseException("ticketNotFound");
        return ticket;
    }

    public ICollection<TicketEntity> GetTickets()
    {
        return _ticketRepository.Get().ToList();
    }

    public bool UpdateStatus(int id, ETicketStatus status)
    {
        var adminUser = _authService.GetAuthUser();
        if (adminUser.Role != nameof(EUserRole.ADMIN)) throw new Exception("unauthorizedAccess");
        var ticket = GetTicket(id);
        ticket.Status = status;
        ticket.TicketOperationLogs.Add(new TicketOperationLogEntity
        {
            OperationStatus = status,
            OperationUserId = adminUser.Id
        });
        _unitOfWork.Update(ticket);
        _unitOfWork.Commit();
        return true;
    }
}
