using EventManagement.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Web.Controllers
{
    public class EventTypeController(EmDbContext context) : Controller
    {
        public IActionResult Index()
        {
            return Content(context.EventTypes.ToList().Count.ToString());
        }
    }
}
