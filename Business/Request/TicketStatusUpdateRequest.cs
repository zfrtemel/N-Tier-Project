﻿using Core.Web.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request
{
    public class TicketStatusUpdateRequest
    {
        public ETicketStatus Status { get; set; }
    }
}
