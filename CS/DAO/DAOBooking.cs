using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.DAO
{
    public class DAOBooking
    {
        sql s = new sql();
        public IEnumerable<Booking> Get()
        {
            return s.Booking.ToList();
        }
        public Booking Get(int id)
        {
            return s.Booking.SingleOrDefault(x => x.id == id);
        }
        public void Post(Booking booking)
        {
            s.Booking.Add(booking);
            s.SaveChanges();
        }
        public void Put(int id, Booking booking)
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
        public void Delete(int id)
        {
            s.Booking.Remove(s.Booking.Single(x => x.id == id));
            s.SaveChanges();
        }
    }
}
