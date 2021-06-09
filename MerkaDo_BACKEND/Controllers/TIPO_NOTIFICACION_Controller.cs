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
    [RoutePrefix("Api/TipoNotificacion")]
    public class TIPO_NOTIFICACION_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TIPO_NOTIFICACION_
        public async Task<ActionResult> Index()
        {
            return View(await db.TIPO_NOTIFICACION_.ToListAsync());
        }

        // GET: TIPO_NOTIFICACION_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_NOTIFICACION_ tIPO_NOTIFICACION_ = await db.TIPO_NOTIFICACION_.FindAsync(id);
            if (tIPO_NOTIFICACION_ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_NOTIFICACION_);
        }

        // GET: TIPO_NOTIFICACION_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_NOTIFICACION_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tipoNotificacionId,nombreTipoNotificacion")] TIPO_NOTIFICACION_ tIPO_NOTIFICACION_)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_NOTIFICACION_.Add(tIPO_NOTIFICACION_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tIPO_NOTIFICACION_);
        }

        // GET: TIPO_NOTIFICACION_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_NOTIFICACION_ tIPO_NOTIFICACION_ = await db.TIPO_NOTIFICACION_.FindAsync(id);
            if (tIPO_NOTIFICACION_ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_NOTIFICACION_);
        }

        // POST: TIPO_NOTIFICACION_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tipoNotificacionId,nombreTipoNotificacion")] TIPO_NOTIFICACION_ tIPO_NOTIFICACION_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_NOTIFICACION_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tIPO_NOTIFICACION_);
        }

        // GET: TIPO_NOTIFICACION_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_NOTIFICACION_ tIPO_NOTIFICACION_ = await db.TIPO_NOTIFICACION_.FindAsync(id);
            if (tIPO_NOTIFICACION_ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_NOTIFICACION_);
        }

        // POST: TIPO_NOTIFICACION_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TIPO_NOTIFICACION_ tIPO_NOTIFICACION_ = await db.TIPO_NOTIFICACION_.FindAsync(id);
            db.TIPO_NOTIFICACION_.Remove(tIPO_NOTIFICACION_);
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
