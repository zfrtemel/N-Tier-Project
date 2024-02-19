using Business.Interfaces;
using Business.Request;
using Core.Enum;
using Core.Web.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Ticket
{
    [Route("admin/ticket"), Authorize(Roles = nameof(EUserRole.Admin))]
    public class AdminTicketController : APIControllerBase
    {
        private readonly ITicketService _ticketService;
        public AdminTicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        /// <summary>
        /// Ticket Fetch All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return ApiResult("Tickets fetched", true, _ticketService.GetTickets());
        }

        /// <summary>
        /// Ticket Fetch By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiResult("Ticket fetched", true, _ticketService.GetTicket(id));
        }

        /// <summary>
        /// Ticket Update For Status 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TicketStatusUpdateRequest request)
        {
            return ApiResult("Ticket updated", true, _ticketService.UpdateStatus(id, request.Status));
        }
    }
}
