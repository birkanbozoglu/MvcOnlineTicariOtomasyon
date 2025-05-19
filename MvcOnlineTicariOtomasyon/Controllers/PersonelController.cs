using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        public ActionResult Index()
        {
            var list = new List<Personel>();
            using (var ctx = new Context())
            {
                list = ctx.Personels.Where(x => x.IsActive == true)
                                    .Include(x => x.Department).ToList();
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            var departments = new List<SelectListItem>();
            using (var ctx = new Context())
            {
                departments = ctx.Departments.Where(ss => ss.IsActive == true)
                                             .Select(ss => new SelectListItem
                                             {
                                                 Text = ss.Name,
                                                 Value = ss.Id.ToString()
                                             }).ToList();
            }
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Personel data)
        {
            using (var ctx = new Context())
            {
                data.IsActive = true;
                ctx.Personels.Add(data);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Personels.Find(id);
                entity.IsActive = false;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Update(int id)
        {
            var departments = new List<SelectListItem>();

            using (var ctx = new Context())
            {
                departments = ctx.Departments.Where(ss => ss.IsActive == true)
                                             .Select(ss => new SelectListItem
                                             {
                                                 Text = ss.Name,
                                                 Value = ss.Id.ToString()
                                             }).ToList();

                ViewBag.Departments = departments;

                var entity = ctx.Personels.Find(id);
                return View("Update", entity);
            }
        }

        [HttpPost]
        public ActionResult Update(Personel data)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Personels.Find(data.Id);
                entity.FirstName = data.FirstName;
                entity.LastName = data.LastName;
                entity.DepartmentId = data.DepartmentId;
                entity.Image = data.Image;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}