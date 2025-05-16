using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var list = new List<Product>();
            using (var ctx = new Context())
            {
                list = ctx.Products.Where(x => x.IsActive == true)
                                   .Include(x => x.Category).ToList();
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            var categories = new List<SelectListItem>();
            using (var ctx = new Context())
            {
                categories = ctx.Categories.Where(ss => ss.IsActive == true)
                                           .Select(ss => new SelectListItem
                                           {
                                               Text = ss.Name,
                                               Value = ss.Id.ToString()
                                           }).ToList();
            }
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Product data)
        {
            using (var ctx = new Context())
            {
                data.IsActive = true;
                ctx.Products.Add(data);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Products.Find(id);
                entity.IsActive = false;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Update(int id)
        {
            var categories = new List<SelectListItem>();

            using (var ctx = new Context())
            {
                categories = ctx.Categories.Where(ss => ss.IsActive == true)
                                           .Select(ss => new SelectListItem
                                           {
                                               Text = ss.Name,
                                               Value = ss.Id.ToString()
                                           }).ToList();

                ViewBag.Categories = categories;

                var entity = ctx.Products.Find(id);
                return View("Update", entity);
            }
        }

        [HttpPost]
        public ActionResult Update(Product data)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Products.Find(data.Id);
                entity.Name = data.Name;
                entity.IsActive = data.IsActive;
                entity.Brand = data.Brand;
                entity.SalePrice = data.SalePrice;
                entity.CategoryId = data.CategoryId;
                entity.Stock = data.Stock;
                entity.PruchasePrice = data.PruchasePrice;
                entity.Image = data.Image;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}