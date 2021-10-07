using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mlmanagment1.Data;
using mlmanagment1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mlmanagment1.Models;


namespace mlmanagment.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

     //   GET: CustomerController
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.OffertType).ToList();
            return View(customers);
        }

        //     GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            var offetType = _context.OffertTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                OffertType = offetType,
                Customer = new Customer()
            };
            return View(viewModel);
        }
     

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new NewCustomerViewModel
                    {

                        Customer = customer,                        
                        OffertType = _context.OffertTypes.ToList()

                    };
                    return View("Create", viewModel);
                }
                if (customer.Id == 0)
                {
                    customer.RegistrationDate = DateTime.Now;
                    
                    _context.Customers.Add(customer);
                }                   
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                    customerInDb.FirstName = customer.FirstName;
                    customerInDb.LastName = customer.LastName;
                    customerInDb.MiddleName = customer.MiddleName;
                    customerInDb.Birthdate = customer.Birthdate;
                    customerInDb.OffertTypeId = customer.OffertTypeId;
                    
                    customerInDb.RegistrationDate = DateTime.Now;
                    customerInDb.Comment = customer.Comment;
                    customerInDb.DocumentIsComplete = customer.DocumentIsComplete;
                }
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            string faillure = "an Error occured:  this customer does'n have a Id in the Database or the Id has been deleted";
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customer == null)
            {
                return View(faillure);
            };
                

            var viewmodel = new NewCustomerViewModel
            {
                Customer = customer,
                OffertType = _context.OffertTypes.ToList()
            };
            return View("Create" , viewmodel);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        ////public ActionResult Edit(int id, Customer customer)
        //{
            //try
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        var viewModel = new NewCustomerViewModel
            //        {

            //            Customer = customer,
            //            OffertTypes = _context.OffertTypes.ToList()

            //        };
            //        return View("Create", viewModel);
            //    }
            //    if (customer.Id != 0)
            //    {
            //        var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            //        customer.FirstName = customer.FirstName;
            //        customer.LastName = customer.LastName;
            //        customer.MiddleName = customer.MiddleName;
            //        customer.Birthdate = customer.Birthdate;
            //        customer.OffertType = customer.OffertType;
            //        customer.RegistrationDate = DateTime.Now;
            //        customer.Comment = customer.Comment;
            //        customer.DocumentIsComplete = customer.DocumentIsComplete;
            //        //  Save Changes
            //        _context.SaveChanges();

            //    }
            //    else
            //    {
                  
            //    }
                

            //    return RedirectToAction(nameof(Index));
            //}
            //catch (Exception ex)
            //{
            //    return View(ex);
            //}
        //}

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
