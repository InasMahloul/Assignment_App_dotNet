using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_App.Domain.Events
{
    
        public record TaskCreatedEvent(Guid TaskId);
    
}
