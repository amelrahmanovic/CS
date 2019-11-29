using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CS
{
    public class sql :DbContext
    {
        public sql() : base(@"Data Source=DESKTOP-UQGU5VO\SQLEXPRESS;Initial Catalog=CS;Integrated Security=True") { }
        public DbSet<Capacity_provider> Capacity_provider { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}
