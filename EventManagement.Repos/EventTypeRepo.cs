using EventManagement.Data;
using EventManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Repos
{
    public class EventTypeRepo(EmDbContext context)
    {
        public List<EventType> GetAll()
        {
            return context.EventTypes.ToList();
        }

    }
}
