using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            var list = new List<Company>();
            using (var ctx = new Context())
            {
                list = ctx.Companies.Where(x => x.IsActive == true).ToList();
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Company data)
        {
            using (var ctx = new Context())
            {
                data.IsActive = true;
                ctx.Companies.Add(data);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Companies.Find(id);
                entity.IsActive = false;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Update(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Companies.Find(id);
                return View("Update", entity);
            }
        }

        [HttpPost]
        public ActionResult Update(Company data)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Companies.Find(data.Id);
                entity.FirstName = data.FirstName;
                entity.LastName = data.LastName;
                entity.TaxNumber = data.TaxNumber;
                entity.TaxOffice = data.TaxOffice;
                entity.City = data.City;
                entity.Email = data.Email;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}