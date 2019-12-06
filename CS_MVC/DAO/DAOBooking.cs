using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CS_MVC.DAO
{
    public class DAOBooking
    {
        HttpClient client = new HttpClient();
        string Uri = "http://localhost:63510";

        public List<Booking> Get()
        {
            client.DefaultRequestHeaders.Add("api-version", "1.0");

            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.GetAsync("api/Booking").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<List<Booking>>().Result;
            return new List<Booking>();
        }
        public Booking Get(int id)
        {
            client.DefaultRequestHeaders.Add("api-version", "1.0");

            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.GetAsync("api/Booking" + "/" + id).Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<Booking>().Result;
            return new Booking();
        }
        public void Post(Booking booking)
        {
            client.DefaultRequestHeaders.Add("api-version", "1.0");

            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.PostAsJsonAsync("api/Booking", booking).Result;
        }
        public void Put(Booking booking)
        {
            client.DefaultRequestHeaders.Add("api-version", "1.0");

            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.PutAsJsonAsync("api/Booking" + "/" + booking.id, booking).Result;
        }
        public void Delete(int id)
        {
            client.DefaultRequestHeaders.Add("api-version", "1.0");

            client.BaseAddress = new Uri(Uri);
            HttpResponseMessage response = client.DeleteAsync("api/Booking" + "/" + id).Result;
        }
    }
}
