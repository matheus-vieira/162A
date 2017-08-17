using Models.Tables;
using Revisão.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Revisão.Controllers
{
    public class CategoriesController : Controller
    {
        private EFContext ctx = new EFContext();

        #region Actions

        // GET: Categories
        public ActionResult Index()
        {
            return View(ctx
                .Categories);
        }

        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                ctx.Categories.Add(category);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        #endregion

        #region Edit

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = ctx
                .Categories
                .Find(id);

            if (category == null)
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.NotFound);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category modified)
        {
            if (ModelState.IsValid)
            {
                ctx
                    .Entry(modified)
                    .State = EntityState.Modified;

                ctx.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(modified);
        }

        #endregion

        #region Details

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = ctx
                .Categories
                .Find(id);

            if (category == null)
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.NotFound);

            return View(category);
        }

        #endregion

        #region Delete

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = ctx
                .Categories
                .Find(id);

            if (category == null)
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.NotFound);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category toDelete)
        {
            if (toDelete.CategoryId < 1)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = ctx
                .Categories
                .Find(toDelete.CategoryId);

            if (category == null)
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.NotFound);

            ctx
                .Categories
                .Remove(category);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #endregion

    }
}