using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.DTO;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PricesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prices
        public ActionResult Index()
        {
            return View(db.PriceDtoes.ToList());
        }

        // GET: Prices/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceDto priceDto = db.PriceDtoes.Find(id);
            if (priceDto == null)
            {
                return HttpNotFound();
            }
            return View(priceDto);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Value")] PriceDto priceDto)
        {
            if (ModelState.IsValid)
            {
                db.PriceDtoes.Add(priceDto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priceDto);
        }

        // GET: Prices/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceDto priceDto = db.PriceDtoes.Find(id);
            if (priceDto == null)
            {
                return HttpNotFound();
            }
            return View(priceDto);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Value")] PriceDto priceDto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceDto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priceDto);
        }

        // GET: Prices/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceDto priceDto = db.PriceDtoes.Find(id);
            if (priceDto == null)
            {
                return HttpNotFound();
            }
            return View(priceDto);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PriceDto priceDto = db.PriceDtoes.Find(id);
            db.PriceDtoes.Remove(priceDto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}