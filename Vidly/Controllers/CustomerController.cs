using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()//we have created viewmodel to bind two models
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]//this is to submit data to a specified resource
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel//added a validation to customer
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
                if (customer.Id == 0)//new customer
                _context.Customers.Add(customer); //now saved to memory
                else//already existing; update
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Mapper.Map(customer, customerInDb); another way to the same thing below

                customerInDb.Name = customer.Name;
                customerInDb.bDay = customer.bDay;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();//saved to the DB

            return RedirectToAction("Index", "Customers"); //redirected to the Index page 
        }

        public ViewResult Index()//viewresult is a subtype of actionresult this method uses polymorp
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();//get all the customers from the database

            return View(customers);//its a deferred execution if tolist is not included

        }   

        public ActionResult Details(int id)//kullanıcı url'ye id girdi onu aldı enum zaten onu sıraladı int'e göre
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);//executed immedi. bcoz of single or def.

            if (customer == null)
            {
                return HttpNotFound();//if there is no customer than return 404 not found X_X
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);//checks the id

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
          
            return View("CustomerForm", viewModel);

        }
        /*private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1,Name="John Smith"},
                new Customer{Id=2,Name="Mary Willams"}
            };
        }*/
    }
} 