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
    [RoutePrefix("API/tarjetaMembresia")]
    public class TARJETA_MEMBRESIA_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TARJETA_MEMBRESIA_
        public async Task<ActionResult> Index()
        {
            var tARJETA_MEMBRESIA_ = db.TARJETA_MEMBRESIA_.Include(t => t.CLIENTES__);
            return View(await tARJETA_MEMBRESIA_.ToListAsync());
        }

        // GET: TARJETA_MEMBRESIA_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_MEMBRESIA_ tARJETA_MEMBRESIA_ = await db.TARJETA_MEMBRESIA_.FindAsync(id);
            if (tARJETA_MEMBRESIA_ == null)
            {
                return HttpNotFound();
            }
            return View(tARJETA_MEMBRESIA_);
        }

        // GET: TARJETA_MEMBRESIA_/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            return View();
        }

        // POST: TARJETA_MEMBRESIA_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tarjetaMembresiaId,ClienteId,nombreCliente,razonSocialEmpresa,puntosAcumuladosTarjetaMembresia,fechaVencimientoTarjetaMembresia")] TARJETA_MEMBRESIA_ tARJETA_MEMBRESIA_)
        {
            if (ModelState.IsValid)
            {
                db.TARJETA_MEMBRESIA_.Add(tARJETA_MEMBRESIA_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", tARJETA_MEMBRESIA_.ClienteId);
            return View(tARJETA_MEMBRESIA_);
        }

        // GET: TARJETA_MEMBRESIA_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_MEMBRESIA_ tARJETA_MEMBRESIA_ = await db.TARJETA_MEMBRESIA_.FindAsync(id);
            if (tARJETA_MEMBRESIA_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", tARJETA_MEMBRESIA_.ClienteId);
            return View(tARJETA_MEMBRESIA_);
        }

        // POST: TARJETA_MEMBRESIA_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tarjetaMembresiaId,ClienteId,nombreCliente,razonSocialEmpresa,puntosAcumuladosTarjetaMembresia,fechaVencimientoTarjetaMembresia")] TARJETA_MEMBRESIA_ tARJETA_MEMBRESIA_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tARJETA_MEMBRESIA_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", tARJETA_MEMBRESIA_.ClienteId);
            return View(tARJETA_MEMBRESIA_);
        }

        // GET: TARJETA_MEMBRESIA_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_MEMBRESIA_ tARJETA_MEMBRESIA_ = await db.TARJETA_MEMBRESIA_.FindAsync(id);
            if (tARJETA_MEMBRESIA_ == null)
            {
                return HttpNotFound();
            }
            return View(tARJETA_MEMBRESIA_);
        }

        // POST: TARJETA_MEMBRESIA_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TARJETA_MEMBRESIA_ tARJETA_MEMBRESIA_ = await db.TARJETA_MEMBRESIA_.FindAsync(id);
            db.TARJETA_MEMBRESIA_.Remove(tARJETA_MEMBRESIA_);
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
