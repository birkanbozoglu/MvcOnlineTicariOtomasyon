using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            var list = new List<Department>();
            using (var ctx = new Context())
            {
                list = ctx.Departments.Where(ss => ss.IsActive == true).ToList();
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Department data)
        {
            using (var ctx = new Context())
            {
                data.IsActive = true;
                ctx.Departments.Add(data);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Departments.Find(id);
                entity.IsActive = false;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Update(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Departments.Find(id);
                return View("Update", entity);
            }
        }

        [HttpPost]
        public ActionResult Update(Department data)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Departments.Find(data.Id);
                entity.Name = data.Name;
                entity.IsActive = data.IsActive;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Personels(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Personels.Where(ss => ss.DepartmentId == id).ToList();
                var departmentName = ctx.Departments.FirstOrDefault(ss => ss.Id == id).Name;
                ViewBag.DepartmentName = departmentName;
                return View("Personels", entity);
            }
        }
    }
}