using EventManagement.Data;
using EventManagement.Repos;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Web.Controllers
{
    public class EventTypeController(EventTypeRepo eventTypeRepo) : Controller
    {
        public IActionResult Index()
        {
            return Json(eventTypeRepo.GetAll());
        }
    }
}