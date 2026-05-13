using EventManagement.Data;
using EventManagement.Repos;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Entities;
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

        public IActionResult Detail(int dataId)
        {
            if(dataId == -1)
            {
                return View(new EventType());
            }

            var result = eventTypeRepo.GetById(dataId);
            if (result.HasError || result.Data == null)
            {
                TempData["Error"] = result.Message ?? "Event type not found.";
                return RedirectToAction("Index");
            }
            if (result.HasError)
            {
                TempData["Error"] = result.Message;
                    return RedirectToAction("Index");
            }
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult Detail(EventType model)
        {
            ModelState.Remove("UpdatedAt");
            ModelState.Remove("UpdatedBy");
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            else
            {
                var result = eventTypeRepo.Save(model);
                if (result.HasError)
                {
                    TempData["Error"] = result.Message;
                }
                else
                {
                    TempData["Success"] = $"Data #{result.Data} saved successfully.";
                    return RedirectToAction("Index");
                }
                return View(result.Data);
                
            }
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