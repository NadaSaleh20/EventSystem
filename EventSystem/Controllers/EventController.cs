using EventSystem.services;
using EventSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Threading.Tasks;

namespace EventSystem.Controllers
{
    public class EventController : Controller
    {
        public IEventRepostry _eventRepostry { get; }

        public EventController(IEventRepostry eventRepostry)
        {
            _eventRepostry = eventRepostry;
        }
        public async Task <IActionResult> Index()
        {
            var categories = await _eventRepostry.GetAllCateogry();
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEvents(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _eventRepostry.AddEventDB(model);
                return RedirectToAction("Index");
            }
            return View(nameof(MangeEvent));
        }

        public async Task<IActionResult> MangeEvent( string name = null, int CateogryId = 0)
        {
            var categories = await _eventRepostry.GetAllCateogry();
            ViewBag.Categories = categories;
            return View(await _eventRepostry.GetAllEvents( name, CateogryId));
        }

        public async Task<IActionResult> DeleteEvent(int EventId)
        {
           await _eventRepostry.deleteEvent(EventId);
            return Ok();
        }

    }
}
