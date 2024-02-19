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
        public IActionResult Post([FromBody] CreateTicketRequest request)
        {

            return ApiResult("ticketCreated", true, _ticketService.CreateTicket(request));
        }
    }
}
