using HMT.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Controllers
{
    public class HomeController : Controller
    {
        private HMTContext context { get; set; }

        public HomeController(HMTContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.Vendors = context.Vendors.OrderBy(v => v.Name).ToList();
            ViewBag.Customers = context.Customers.OrderBy(c => c.Name).ToList();
            ViewBag.Stores = context.Stores.OrderBy(s => s.StoreID).ToList();
            mymodel.Solds = context.Solds.OrderBy(s => s.SaleID).ToList();
            mymodel.Products = context.Products.OrderBy(s => s.ProductID).ToList();
            mymodel.Sales = context.Sales.OrderBy(s => s.SaleID).ToList();
            return View(mymodel);
        }
        [HttpGet]
        public IActionResult Add ()
        {
            ViewBag.Products = context.Products.ToList();
            ViewBag.Sales = context.Sales.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add (Sold s)
        {
            if(ModelState.IsValid)
            {
                context.Solds.Add(s);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Products = context.Products.ToList();
                ViewBag.Sales = context.Sales.ToList();
                return View(s);
            }
        }      
    }
}
