using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS_MVC.DAO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CS_MVC.Controllers
{
    public class ProviderController : Controller
    {
        DAOProvider dao = new DAOProvider();
        public IActionResult Index()
        {
            ViewData["Provider"] = new Capacity_provider();
            return View("Index", dao.Get());
        }
        public IActionResult Save(int id, string Name, string City, string Phone, string Email, string Contact)
        {
            Capacity_provider capacity = new Capacity_provider();
            capacity.id = id;
            capacity.city = City;
            capacity.contract_number = Contact;
            capacity.email = Email;
            capacity.name = Name;
            capacity.phone = Phone;
            if (id == 0)
                dao.Post(capacity);
            else
                dao.Put(capacity);
            return Redirect("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewData["Provider"] = dao.Get(id);
            return View("Edit");
        }
        public IActionResult Delete(int id)
        {
            dao.Delete(id);
            return RedirectToAction("Index");
        }
    }
}