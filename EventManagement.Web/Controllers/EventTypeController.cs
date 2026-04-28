using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Web.Controllers
{
    public class EventTypeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Event Type Index");
        }
    }
}
