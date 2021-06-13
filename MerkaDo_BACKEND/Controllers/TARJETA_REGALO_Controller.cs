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
    [RoutePrefix("Api/TarjetaRegalo")]
    public class TARJETA_REGALO_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TARJETA_REGALO_
        public async Task<ActionResult> Index()
        {
            var tARJETA_REGALO_ = db.TARJETA_REGALO_.Include(t => t.USUARIO__);
            return View(await tARJETA_REGALO_.ToListAsync());
        }

        // GET: TARJETA_REGALO_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_REGALO_ tARJETA_REGALO_ = await db.TARJETA_REGALO_.FindAsync(id);
            if (tARJETA_REGALO_ == null)
            {
                return HttpNotFound();
            }
            return View(tARJETA_REGALO_);
        }

        // GET: TARJETA_REGALO_/Create
        public ActionResult Create()
        {
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: TARJETA_REGALO_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tarjetaRegaloId,usuarioId,nombreCliente,razonSocialEmpresa,valorAcreditarTarjetaRegalo,fechaVencimiento")] TARJETA_REGALO_ tARJETA_REGALO_)
        {
            if (ModelState.IsValid)
            {
                db.TARJETA_REGALO_.Add(tARJETA_REGALO_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", tARJETA_REGALO_.usuarioId);
            return View(tARJETA_REGALO_);
        }

        // GET: TARJETA_REGALO_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_REGALO_ tARJETA_REGALO_ = await db.TARJETA_REGALO_.FindAsync(id);
            if (tARJETA_REGALO_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", tARJETA_REGALO_.usuarioId);
            return View(tARJETA_REGALO_);
        }

        // POST: TARJETA_REGALO_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tarjetaRegaloId,usuarioId,nombreCliente,razonSocialEmpresa,valorAcreditarTarjetaRegalo,fechaVencimiento")] TARJETA_REGALO_ tARJETA_REGALO_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tARJETA_REGALO_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", tARJETA_REGALO_.usuarioId);
            return View(tARJETA_REGALO_);
        }

        // GET: TARJETA_REGALO_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TARJETA_REGALO_ tARJETA_REGALO_ = await db.TARJETA_REGALO_.FindAsync(id);
            if (tARJETA_REGALO_ == null)
            {
                return HttpNotFound();
            }
            return View(tARJETA_REGALO_);
        }

        // POST: TARJETA_REGALO_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TARJETA_REGALO_ tARJETA_REGALO_ = await db.TARJETA_REGALO_.FindAsync(id);
            db.TARJETA_REGALO_.Remove(tARJETA_REGALO_);
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
