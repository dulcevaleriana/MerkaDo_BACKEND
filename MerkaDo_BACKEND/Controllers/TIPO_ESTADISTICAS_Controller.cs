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
    [RoutePrefix("Api/TipoEstadisticas")]
    public class TIPO_ESTADISTICAS_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TIPO_ESTADISTICAS_
        public async Task<ActionResult> Index()
        {
            return View(await db.TIPO_ESTADISTICAS_.ToListAsync());
        }

        // GET: TIPO_ESTADISTICAS_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_ESTADISTICAS_ tIPO_ESTADISTICAS_ = await db.TIPO_ESTADISTICAS_.FindAsync(id);
            if (tIPO_ESTADISTICAS_ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_ESTADISTICAS_);
        }

        // GET: TIPO_ESTADISTICAS_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_ESTADISTICAS_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tipoEstadisticasId,nombreTipoEstadisticas")] TIPO_ESTADISTICAS_ tIPO_ESTADISTICAS_)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_ESTADISTICAS_.Add(tIPO_ESTADISTICAS_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tIPO_ESTADISTICAS_);
        }

        // GET: TIPO_ESTADISTICAS_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_ESTADISTICAS_ tIPO_ESTADISTICAS_ = await db.TIPO_ESTADISTICAS_.FindAsync(id);
            if (tIPO_ESTADISTICAS_ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_ESTADISTICAS_);
        }

        // POST: TIPO_ESTADISTICAS_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tipoEstadisticasId,nombreTipoEstadisticas")] TIPO_ESTADISTICAS_ tIPO_ESTADISTICAS_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_ESTADISTICAS_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tIPO_ESTADISTICAS_);
        }

        // GET: TIPO_ESTADISTICAS_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_ESTADISTICAS_ tIPO_ESTADISTICAS_ = await db.TIPO_ESTADISTICAS_.FindAsync(id);
            if (tIPO_ESTADISTICAS_ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_ESTADISTICAS_);
        }

        // POST: TIPO_ESTADISTICAS_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TIPO_ESTADISTICAS_ tIPO_ESTADISTICAS_ = await db.TIPO_ESTADISTICAS_.FindAsync(id);
            db.TIPO_ESTADISTICAS_.Remove(tIPO_ESTADISTICAS_);
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
