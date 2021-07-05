using HMT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Controllers
{
    public class CustomerController : Controller
    {
        private HMTContext context { get; set; }

        public CustomerController(HMTContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var customers = context.Customers.OrderBy(c => c.CustomerID).ToList();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Customer c)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Add(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }
        [HttpGet]
        public IActionResult Edit (int id)
        {
            var c = context.Customers.Find(id);
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit (Customer c)
        {
            if (ModelState.IsValid)
            {
                context.Customers.Update(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var c = context.Customers.Find(id);
            return View(c);
        }
        [HttpPost]
        public IActionResult Delete (Customer c)
        {
            context.Customers.Remove(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
