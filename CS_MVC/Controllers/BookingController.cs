using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_MVC.DAO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CS_MVC.Controllers
{
    public class BookingController : Controller
    {
        DAOProvider daop = new DAOProvider();
        DAOBooking daob = new DAOBooking();
        public IActionResult Index(int ?id)
        {
            ViewData["Booking"] = new Booking();
            if (id!=null)
            {
                ViewData["Provider"] = daop.Get().Single(x => x.id == id);
                ViewData["Bookings"] = daob.Get().Where(x => x.capacity_provider_id == id).ToList();
            }
            else
            {
                ViewData["Provider"] = new Capacity_provider();
                ViewData["Bookings"] = new List<Booking>();
            }
            
            return View();
        }
        public IActionResult Save(int id, int capacity_provider_id, string Object, DateTime From, DateTime To, float amount, string is_active, string currency, string comment)
        {
            Booking booking = new Booking();
            booking.id = id;
            booking.capacity_provider_id = capacity_provider_id;
            booking.object_name = Object;
            booking.date_from = From;
            booking.date_to = To;
            booking.amount = amount;
            if (is_active == "on")
                booking.is_active = true;
            else
                booking.is_active = false;
            booking.currency = currency;
            booking.comment = comment;

            if (id == 0)
                daob.Post(booking);
            else
                daob.Put(booking);

            return RedirectToAction("Index", new {id= capacity_provider_id });
        }
        public IActionResult Delete(int id, int cid)
        {
            daob.Delete(id);
            return RedirectToAction("Index", new { id = cid });
        }
        public IActionResult Edit(int id)
        {
            Booking booking = daob.Get().Single(x => x.id == id);
            Capacity_provider capacity_Provider = daop.Get().Single(x => x.id == booking.capacity_provider_id);
            ViewData["Provider"] = capacity_Provider;
            ViewData["Booking"] = booking;
            return View();
        }
    }
}