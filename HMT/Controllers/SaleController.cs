using HMT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Controllers
{
    public class SaleController : Controller
    {
        private HMTContext context { get; set; }

        public SaleController(HMTContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index(string id)
        {
            var filters = new Filter(id);
            ViewBag.Filter = filters;
            ViewBag.Customers = context.Customers.OrderBy(c => c.Name).ToList();
            ViewBag.Stores = context.Stores.OrderBy(s => s.StoreID).ToList();
            IQueryable<Sale> query = context.Sales.Include(c => c.Customer).Include(s => s.Store);
            if (filters.HasCustomer)
            {
                query = query.Where(c => c.CustomerID.ToString() == filters.CustomerID.ToString());
            }
            if (filters.HasStore)
            {
                query = query.Where(s => s.StoreID.ToString() == filters.StoreID.ToString());
            }
            var sales = query.OrderBy(s => s.SaleID).ToList();
            return View(sales);
        }
        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Stores = context.Stores.ToList();
            var s = context.Sales.Find(id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Edit(Sale s)
        {
            if (ModelState.IsValid)
            {
                context.Sales.Update(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Customers = context.Customers.ToList();
                ViewBag.Stores = context.Stores.ToList();
                return View(s);
            }
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Stores = context.Stores.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add (Sale s)
        {
            if (ModelState.IsValid)
            {
                context.Sales.Add(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Customers = context.Customers.ToList();
                ViewBag.Stores = context.Stores.ToList();
                return View(s);
            }
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            ViewBag.Customers = context.Customers.ToList();
            ViewBag.Stores = context.Stores.ToList();
            var s = context.Sales.Find(id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Delete (Sale s)
        {
            if(ModelState.IsValid)
            {
                context.Sales.Remove(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Customers = context.Customers.ToList();
                ViewBag.Stores = context.Stores.ToList();
                return View(s);
            }
        }         
    }
}
