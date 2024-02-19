using DataAccess.Interfaces;
using Entity.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.Abstract;
public interface ITicketRepository : IRepository<TicketEntity>
{

}
