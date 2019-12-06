using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.DAO
{
    public class DAOCapacity
    {
        sql s = new sql();
        public IEnumerable<Capacity_provider> Get()
        {
            return s.Capacity_provider.ToList();
        }
        public Capacity_provider Get(int id)
        {
            return s.Capacity_provider.SingleOrDefault(x => x.id == id);
        }
        public void Post(Capacity_provider capacity_Provider)
        {
            s.Capacity_provider.Add(capacity_Provider);
            s.SaveChanges();
        }
        public void Put(int id, Capacity_provider capacity_Provider)
        {
            if (id == capacity_Provider.id)
            {
                Capacity_provider capacity_ProviderFromDatabase = s.Capacity_provider.Single(x => x.id == id);
                capacity_ProviderFromDatabase.name = capacity_Provider.name;
                capacity_ProviderFromDatabase.city = capacity_Provider.city;
                capacity_ProviderFromDatabase.phone = capacity_Provider.phone;
                capacity_ProviderFromDatabase.email = capacity_Provider.email;
                capacity_ProviderFromDatabase.contract_number = capacity_Provider.contract_number;
                s.SaveChanges();
            }
        }
        public void Delete(int id)
        {

            s.Capacity_provider.Remove(s.Capacity_provider.Single(x => x.id == id));
            s.SaveChanges();
        }
    }
}
