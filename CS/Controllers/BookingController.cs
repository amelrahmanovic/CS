using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        sql s = new sql();
        // GET: api/Booking
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return s.Booking.ToList();
        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "BookingGet")]
        public Booking Get(int id)
        {
            return s.Booking.SingleOrDefault(x => x.id == id);
        }

        // POST: api/Booking
        [HttpPost]
        public void Post([FromBody] Booking booking)
        {
            s.Booking.Add(booking);
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Booking booking)
        {
            if (id == booking.id)
            {
                Booking bookingFromDatabase = s.Booking.Single(x => x.id == id);
                bookingFromDatabase.object_name = booking.object_name;
                bookingFromDatabase.capacity_provider_id = booking.capacity_provider_id;
                bookingFromDatabase.date_from = booking.date_from;
                bookingFromDatabase.date_to = booking.date_to;
                bookingFromDatabase.is_active = booking.is_active;
                bookingFromDatabase.amount = booking.amount;
                bookingFromDatabase.currency = booking.currency;
                bookingFromDatabase.comment = booking.comment;
                s.SaveChanges();
            }
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            s.Booking.Remove(s.Booking.Single(x => x.id == id));
        }
    }
}