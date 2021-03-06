﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollecter.Data;
using TrashCollecter.Models;

namespace TrashCollecter.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;  

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        // GET: Employees


        public async Task<IActionResult> Index()
        {
            EmployeeIndexViewModel employeeView = new EmployeeIndexViewModel();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var CurrentEmployee = _context.Employees.Where(w => w.IdentityUserId == userId).SingleOrDefault();

            if (CurrentEmployee == null)
            {
                return RedirectToAction("Create");
            }
            ViewData["RequestedDayOfWeek"] = new SelectList(_context.Users, "Id", "RequestedDayOfWeek");

            // we want to include people who have a one time pickup for todays date and are in the employees zipcode
            // want to NOT include people who are within their selected suspension dates
            string dayOfWeek = DateTime.Today.DayOfWeek.ToString();
             
            employeeView.Customers = await _context.Customers.Where(a => a.ZipCode == CurrentEmployee.ZipCode && a.RequestedDayEachWeek == dayOfWeek).ToListAsync();
            return View(employeeView);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(EmployeeIndexViewModel employeeIndexViewModel)
        {
        

            EmployeeIndexViewModel employeeView = new EmployeeIndexViewModel();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var CurrentEmployee = _context.Employees.Where(w => w.IdentityUserId == userId).SingleOrDefault();

            // we want to include people who have a one time pickup for todays date and are in the employees zipcode
            // want to NOT include people who are within their selected suspension dates
            employeeView.Customers = _context.Customers.Where(a => a.ZipCode == CurrentEmployee.ZipCode && a.RequestedDayEachWeek == employeeIndexViewModel.RequestedFilterDay).ToList();
          

            return View(employeeView);
        }


        // GET: Employees/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }
        // WHEN AN EMPLOYEE HITS SUBMIT THEN A CHARGE IS APPLIED TO CUSTOMER 
        // Employee needs a 'charge' button 
        // Customer needs a $20 charge added to their account 
        
        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(bool? AmountOwed)
        {
            if (AmountOwed == true)
            {
                return RedirectToAction(nameof(Edit)); 
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var insertValue = _context.Customers.Where(w => w.IdentityUserId == userId); 
            
            var employee = await _context.Employees.FindAsync(AmountOwed); 
;
            if (employee == null)
            {
                return NotFound(); 
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "FirstName", "LastName", "AmountOwed");
            return View(employee); 
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
          

            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Employees.Update(employee); 
                    await _context.SaveChangesAsync();
                    
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); 
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
