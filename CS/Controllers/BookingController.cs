using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.DAO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CS.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        DAOBooking daobooking = new DAOBooking();
        // GET: api/Booking
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return daobooking.Get();
        }

        // GET: api/Booking/5
        [HttpGet("{id}", Name = "BookingGet")]
        public Booking Get(int id)
        {
            return daobooking.Get(id);
        }

        // POST: api/Booking
        [HttpPost]
        public void Post([FromBody] Booking booking)
        {
            daobooking.Post(booking);
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Booking booking)
        {
            daobooking.Put(id, booking);
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            daobooking.Delete(id);
        }
    }
}