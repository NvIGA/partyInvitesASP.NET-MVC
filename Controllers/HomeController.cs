using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;
using System;


namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            
            return View("MyView");
        }   
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            return View();
        }

        public ViewResult ListResponces()
        {
            return View(Repository.Responces.Where(r => r.WillAttend == true));
        }
    }
}
