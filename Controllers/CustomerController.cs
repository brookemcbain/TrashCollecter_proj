using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollecter.Data;
using TrashCollecter.Models;

namespace TrashCollecter.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customers.Where(m => m.IdentityUserId == userId).SingleOrDefault();

            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Customer/Create

        public ActionResult Create()
        {
            
            return View(); 
           
        
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId; 
                _db.Customers.Add(customer);
                _db.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer editCustomer = _db.Customers.Find(id);
            return View(editCustomer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                _db.Customers.Update(customer);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFee(int id, int? fee)
        {
            try
            {
                int custFee = 0;
                if(fee.HasValue)
                {
                    custFee = fee.Value;
                }
                else
                {
                    custFee = 20;
                }
                var customer = _db.Customers.Where(w => w.Id == id).SingleOrDefault();
                customer.AmountOwed += custFee;
                _db.Customers.Update(customer);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index), "Employees");
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer deleteCustomer = _db.Customers.Find(id); 
            return View(deleteCustomer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                Customer deleteCustomer = _db.Customers.Find(id);
                _db.Customers.Remove(deleteCustomer);
                _db.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
