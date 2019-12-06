using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacityController : ControllerBase
    {
        DAOCapacity daocapacity = new DAOCapacity();
        // GET: api/Capacity
        [HttpGet]
        public IEnumerable<Capacity_provider> Get()
        {
            return daocapacity.Get();
        }

        // GET: api/Capacity/5
        [HttpGet("{id}", Name = "Get")]
        public Capacity_provider Get(int id)
        {
            return daocapacity.Get(id);
        }

        // POST: api/Capacity
        [HttpPost]
        public void Post([FromBody] Capacity_provider capacity_Provider)
        {
            daocapacity.Post(capacity_Provider);
        }

        // PUT: api/Capacity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Capacity_provider capacity_Provider)
        {
            daocapacity.Put(id, capacity_Provider);
        }

        // DELETE: api/Capacity/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            daocapacity.Delete(id);
        }
    }
}
