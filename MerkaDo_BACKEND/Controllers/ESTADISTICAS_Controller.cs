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
    public class ESTADISTICAS_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: ESTADISTICAS_
        public async Task<ActionResult> Index()
        {
            var eSTADISTICAS_ = db.ESTADISTICAS_.Include(e => e.TIPO_ESTADISTICAS_);
            return View(await eSTADISTICAS_.ToListAsync());
        }

        // GET: ESTADISTICAS_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADISTICAS_ eSTADISTICAS_ = await db.ESTADISTICAS_.FindAsync(id);
            if (eSTADISTICAS_ == null)
            {
                return HttpNotFound();
            }
            return View(eSTADISTICAS_);
        }

        // GET: ESTADISTICAS_/Create
        public ActionResult Create()
        {
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas");
            return View();
        }

        // POST: ESTADISTICAS_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "estadisticasId,tipoEstadisticasId,fechaCreacion,documentoEstadisticas")] ESTADISTICAS_ eSTADISTICAS_)
        {
            if (ModelState.IsValid)
            {
                db.ESTADISTICAS_.Add(eSTADISTICAS_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", eSTADISTICAS_.tipoEstadisticasId);
            return View(eSTADISTICAS_);
        }

        // GET: ESTADISTICAS_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADISTICAS_ eSTADISTICAS_ = await db.ESTADISTICAS_.FindAsync(id);
            if (eSTADISTICAS_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", eSTADISTICAS_.tipoEstadisticasId);
            return View(eSTADISTICAS_);
        }

        // POST: ESTADISTICAS_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "estadisticasId,tipoEstadisticasId,fechaCreacion,documentoEstadisticas")] ESTADISTICAS_ eSTADISTICAS_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADISTICAS_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", eSTADISTICAS_.tipoEstadisticasId);
            return View(eSTADISTICAS_);
        }

        // GET: ESTADISTICAS_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADISTICAS_ eSTADISTICAS_ = await db.ESTADISTICAS_.FindAsync(id);
            if (eSTADISTICAS_ == null)
            {
                return HttpNotFound();
            }
            return View(eSTADISTICAS_);
        }

        // POST: ESTADISTICAS_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ESTADISTICAS_ eSTADISTICAS_ = await db.ESTADISTICAS_.FindAsync(id);
            db.ESTADISTICAS_.Remove(eSTADISTICAS_);
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
