using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CS_MVC.DAO
{
    public class DAOProvider
    {
        HttpClient client = new HttpClient();
        string Uri = "http://localhost:63510";
        
        public List<Capacity_provider> Get()
        {
            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.GetAsync("api/Capacity").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<List<Capacity_provider>>().Result;
            return new List<Capacity_provider>();
        }
        public Capacity_provider Get(int id)
        {
            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.GetAsync("api/Capacity"+"/"+id).Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Capacity_provider>().Result;
            return new Capacity_provider();
        }
        public void Post(Capacity_provider capacity_Provider)
        {
            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.PostAsJsonAsync("api/Capacity", capacity_Provider).Result;
        }
        public void Put(Capacity_provider capacity_Provider)
        {
            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.PutAsJsonAsync("api/Capacity"+"/"+ capacity_Provider.id, capacity_Provider).Result;
        }
        public void Delete(int id)
        {
            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.DeleteAsync("api/Capacity" + "/" + id).Result;
        }
    }
}
