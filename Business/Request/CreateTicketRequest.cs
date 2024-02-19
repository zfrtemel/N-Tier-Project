using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request;
public class CreateTicketRequest
{
    public string Title { get; set; }
    public string Subject { get; set; }
}
