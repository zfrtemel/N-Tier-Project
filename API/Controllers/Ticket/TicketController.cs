using Business.Interfaces;
using Business.Request;
using Core.Web.Abstracts;
using Entity.Models.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Ticket
{
    [Route("ticket")]
    public class TicketController : APIControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TicketEntity ticket)
        {
            _ticketService.CreateTicket(ticket);
            return ApiResult("Ticket created", true, true);
        }
    }
}
