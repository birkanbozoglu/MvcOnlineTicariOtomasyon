﻿using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var list = new List<Category>();
            using (var ctx = new Context())
            {
                list = ctx.Categories.Where(x => x.IsActive == true).ToList();
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Category data)
        {
            if (!ModelState.IsValid)
            {
                return View("Insert");
            }

            using (var ctx = new Context())
            {
                data.IsActive = true;
                ctx.Categories.Add(data);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Categories.Find(id);
                entity.IsActive = false;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Update(int id)
        {
            using (var ctx = new Context())
            {
                var entity = ctx.Categories.Find(id);
                return View("Update", entity);
            }
        }

        [HttpPost]
        public ActionResult Update(Category data)
        {
            if (!ModelState.IsValid)
            {
                return View("Update");
            }

            using (var ctx = new Context())
            {
                var entity = ctx.Categories.Find(data.Id);
                entity.Name = data.Name;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}