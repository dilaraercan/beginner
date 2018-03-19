using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public ViewResult Index()//viewresult is a subtype of actionresult this method uses polymorp
        {
            var customers = GetCustomers();

            return View(customers);

        }
        public ActionResult Details(int id)//kullanıcı url'ye id girdi onu aldı enum zaten onu sıraladı int'e göre
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();//if there is no customer than return 404 not found X_X

            return View(customer);
        }
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1,Name="John Smith"},
                new Customer{Id=2,Name="Mary Willams"}
            };
        }
    }
} 