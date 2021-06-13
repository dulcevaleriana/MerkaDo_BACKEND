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
    [RoutePrefix("Api/TarjetaCredito")]
    public class TARJETA_CREDITO_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TARJETA_CREDITO_
        public async Task<ActionResult> Index()
        {
            var tARJETA_CREDITO_ = db.TARJETA_CREDITO_.Include(t => t.USUARIO__);
            return View(await tARJETA_CREDITO_.ToListAsync());
        }

        // GET: TARJETA_CREDITO_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_CREDITO_ tARJETA_CREDITO_ = await db.TARJETA_CREDITO_.FindAsync(id);
            if (tARJETA_CREDITO_ == null)
            {
                return HttpNotFound();
            }
            return View(tARJETA_CREDITO_);
        }

        // GET: TARJETA_CREDITO_/Create
        public ActionResult Create()
        {
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: TARJETA_CREDITO_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tarjetaCreditoId,usuarioId,NombreTarjeta,NumeroTarjeta,FechaVencimientoTarjeta,CVV")] TARJETA_CREDITO_ tARJETA_CREDITO_)
        {
            if (ModelState.IsValid)
            {
                db.TARJETA_CREDITO_.Add(tARJETA_CREDITO_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", tARJETA_CREDITO_.usuarioId);
            return View(tARJETA_CREDITO_);
        }

        // GET: TARJETA_CREDITO_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_CREDITO_ tARJETA_CREDITO_ = await db.TARJETA_CREDITO_.FindAsync(id);
            if (tARJETA_CREDITO_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", tARJETA_CREDITO_.usuarioId);
            return View(tARJETA_CREDITO_);
        }

        // POST: TARJETA_CREDITO_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tarjetaCreditoId,usuarioId,NombreTarjeta,NumeroTarjeta,FechaVencimientoTarjeta,CVV")] TARJETA_CREDITO_ tARJETA_CREDITO_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tARJETA_CREDITO_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", tARJETA_CREDITO_.usuarioId);
            return View(tARJETA_CREDITO_);
        }

        // GET: TARJETA_CREDITO_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_CREDITO_ tARJETA_CREDITO_ = await db.TARJETA_CREDITO_.FindAsync(id);
            if (tARJETA_CREDITO_ == null)
            {
                return HttpNotFound();
            }
            return View(tARJETA_CREDITO_);
        }

        // POST: TARJETA_CREDITO_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TARJETA_CREDITO_ tARJETA_CREDITO_ = await db.TARJETA_CREDITO_.FindAsync(id);
            db.TARJETA_CREDITO_.Remove(tARJETA_CREDITO_);
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
