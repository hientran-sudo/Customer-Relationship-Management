using HMT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Controllers
{
    public class PhotoController : Controller
    {
        private HMTContext context { get; set; }

        public PhotoController(HMTContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string id)
        {
            var filters = new PhotoFilter(id);
            ViewBag.Filters = filters;
            ViewBag.PStores = context.PStores.OrderBy(s => s.Name).ToList();
            ViewBag.PDivs = context.PDivs.OrderBy(d => d.Name).ToList();
            IQueryable<PItem> query = context.PItems.Include(s=>s.PStore).Include(d=>d.PDiv);
            if (filters.HasStore)
            {
                query = query.Where(s => s.PStoreID == filters.PStoreID);
            }
            if (filters.HasDiv)
            {
                query = query.Where(d => d.PDivID == filters.PDivID);
            }

            var items = query.OrderBy(i=>i.PDivID).ToList();

            return View(items);
        }

        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }
    }
}
