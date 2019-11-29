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
    public class CapacityController : ControllerBase
    {
        sql s = new sql();
        // GET: api/Capacity
        [HttpGet]
        public IEnumerable<Capacity_provider> Get()
        {
            return s.Capacity_provider.ToList();
        }

        // GET: api/Capacity/5
        [HttpGet("{id}", Name = "Get")]
        public Capacity_provider Get(int id)
        {
            return s.Capacity_provider.SingleOrDefault(x => x.id == id);
        }

        // POST: api/Capacity
        [HttpPost]
        public void Post([FromBody] Capacity_provider capacity_Provider)
        {
            s.Capacity_provider.Add(capacity_Provider);
            s.SaveChanges();
        }

        // PUT: api/Capacity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Capacity_provider capacity_Provider)
        {
            if (id==capacity_Provider.id)
            {
                Capacity_provider capacity_ProviderFromDatabase = s.Capacity_provider.Single(x=>x.id==id);
                capacity_ProviderFromDatabase.name = capacity_Provider.name;
                capacity_ProviderFromDatabase.city = capacity_Provider.city;
                capacity_ProviderFromDatabase.phone = capacity_Provider.phone;
                capacity_ProviderFromDatabase.email = capacity_Provider.email;
                capacity_ProviderFromDatabase.contract_number = capacity_Provider.contract_number;
                s.SaveChanges();
            }
        }

        // DELETE: api/Capacity/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            s.Capacity_provider.Remove(s.Capacity_provider.Single(x => x.id == id));
            s.SaveChanges();
        }
    }
}
