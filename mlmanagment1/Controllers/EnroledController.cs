using Microsoft.AspNetCore.Mvc;
using mlmanagment1.Data;
using mlmanagment1.Models;
using mlmanagment1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mlmanagment1.Controllers
{
    public class EnroledController : Controller
    {
        public IActionResult IndexPartial()
        {
            return View();
        }
        private ApplicationDbContext _context;

        public EnroledController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //Create : new customer for new entry
        public ActionResult EnrolPartial()
        {
            var offetType = _context.OffertTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                OffertType = offetType,
                Customer = new Customer()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnrolPartial(Customer customer)
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
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
