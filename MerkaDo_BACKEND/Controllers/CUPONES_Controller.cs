using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MerkaDo_BACKEND.Models;

namespace MerkaDo_BACKEND.Controllers
{
    public class CUPONES_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: CUPONES_
        public async Task<ActionResult> Index()
        {
            return View(await db.CUPONES_.ToListAsync());
        }

        // GET: CUPONES_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUPONES_ cUPONES_ = await db.CUPONES_.FindAsync(id);
            if (cUPONES_ == null)
            {
                return HttpNotFound();
            }
            return View(cUPONES_);
        }

        // GET: CUPONES_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUPONES_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cuponesId,nombreCupones,descuentoCupones,precioDescontar,fechaVencimiento,codigoCupones,imagenCupones")] CUPONES_ cUPONES_)
        {
            if (ModelState.IsValid)
            {
                db.CUPONES_.Add(cUPONES_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cUPONES_);
        }

        // GET: CUPONES_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUPONES_ cUPONES_ = await db.CUPONES_.FindAsync(id);
            if (cUPONES_ == null)
            {
                return HttpNotFound();
            }
            return View(cUPONES_);
        }

        // POST: CUPONES_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cuponesId,nombreCupones,descuentoCupones,precioDescontar,fechaVencimiento,codigoCupones,imagenCupones")] CUPONES_ cUPONES_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUPONES_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cUPONES_);
        }

        // GET: CUPONES_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUPONES_ cUPONES_ = await db.CUPONES_.FindAsync(id);
            if (cUPONES_ == null)
            {
                return HttpNotFound();
            }
            return View(cUPONES_);
        }

        // POST: CUPONES_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CUPONES_ cUPONES_ = await db.CUPONES_.FindAsync(id);
            db.CUPONES_.Remove(cUPONES_);
            await db.SaveChangesAsync();
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
