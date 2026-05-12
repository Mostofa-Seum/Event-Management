using EventManagement.Data;
using EventManagement.Repos;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Web.Controllers
{
    public class EventTypeController(EventTypeRepo eventTypeRepo) : Controller
    {
        public IActionResult Index()
        {
            var result = eventTypeRepo.GetAll();
            if (result.HasError)
            {
                ViewBag.ErrorMessage = result.Message;
            }
            return View(result.Data);
        }

        public IActionResult Delete(int dataId)
        {
            var result = eventTypeRepo.Delete(dataId);
            if (result.HasError)
            {
               TempData["Error"] = result.Message;
            }
            else
            {
               TempData["Success"] = $"Data #{dataId} deleted successfully.";
            }
                return RedirectToAction("Index"); 
        }
    }
}