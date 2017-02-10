using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var DetailViewModel = new DetailsViewModel();
            DetailViewModel.Customer = customer;
            DetailViewModel.MembershipType = customer.MembershipType;

            return View(DetailViewModel);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerFormViewModel();
            newCustomerViewModel.MembershipTypes = membershipTypes;

            return View("CustomerForm", newCustomerViewModel);
        }


        [HttpPost]
        //public ActionResult Create(NewCustomerViewModel newCustomerViewModel) 
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                
            }
            else
            {
                // different between Single and SingleOrDefault is when do not find, Single raise exception 
                // SingleOrDefault will not
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // TryUpdateModel(customerInDb);  // method 1, it will update ALL properties, not flexiable
                // method 2
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscriberToNewsLetter = customer.IsSubscriberToNewsLetter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers"); ;
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var customerViewModel = new CustomerFormViewModel();
            customerViewModel.Customer = customer;
            customerViewModel.MembershipTypes = _context.MembershipTypes.ToList();

            //"New" will point this action from action name "Edit" view to "New" view
            return View("CustomerForm", customerViewModel);
        }
    }
}