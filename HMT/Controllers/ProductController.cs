using HMT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Controllers
{
    public class ProductController : Controller
    {
        private HMTContext context { get; set; }

        public ProductController(HMTContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            ViewBag.Vendors = context.Vendors.OrderBy(v => v.Name).ToList();
            IQueryable<Product> query = context.Products.Include(c => c.Category).Include(v => v.Vendor);
            if (filters.HasCategory)
            {
                query = query.Where(c => c.CategoryID.ToString() == filters.CategoryID.ToString());
            }
            if (filters.HasVendor)
            {
                query = query.Where(v => v.VendorID.ToString() == filters.VendorID.ToString());
            }
           
            var products = query.OrderBy(p => p.ProductID).ToList();

            return View(products);
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Vendors = context.Vendors.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product p)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                ViewBag.Vendors = context.Vendors.ToList();
                return View(p);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Vendors = context.Vendors.ToList();
            var p = context.Products.Find(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(p);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                ViewBag.Vendors = context.Vendors.ToList();
                return View(p);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Vendors = context.Vendors.ToList();
            var p = context.Products.Find(id);
            return View(p);
        }
        [HttpPost]
        public IActionResult Delete (Product p)
        {
            context.Products.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Product p = context.Products.Find(id);

            string imageFilename = p.ProductID + ".jpg";
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Vendors = context.Vendors.ToList();
            ViewBag.ImageFilename = imageFilename;
            return View(p);
        }
    }
}
