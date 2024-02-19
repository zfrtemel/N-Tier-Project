using Business.Repositories.Abstract;
using DataAccess.Implements;
using Entity.Models.Ticket;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.Concrete;
public class TicketRepository : Repository<TicketEntity>, ITicketRepository
{
    public TicketRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
