using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.WebUI.Controllers
{
    public class SKUController : Controller
    {
        // GET: SKU
        public ActionResult Index()
        {
            return View();
        }

        // GET: SKU/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SKU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SKU/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SKU/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SKU/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SKU/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SKU/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
