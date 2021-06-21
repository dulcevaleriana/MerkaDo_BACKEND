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
    public class MENSAJE__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: MENSAJE__
        public async Task<ActionResult> Index()
        {
            var mENSAJE__ = db.MENSAJE__.Include(m => m.CLIENTES__).Include(m => m.SALA__).Include(m => m.TIPO_MENSAJE__).Include(m => m.TIPO_SALA__).Include(m => m.USUARIO__);
            return View(await mENSAJE__.ToListAsync());
        }

        // GET: MENSAJE__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENSAJE__ mENSAJE__ = await db.MENSAJE__.FindAsync(id);
            if (mENSAJE__ == null)
            {
                return HttpNotFound();
            }
            return View(mENSAJE__);
        }

        // GET: MENSAJE__/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            ViewBag.salaId = new SelectList(db.SALA__, "salaId", "salaId");
            ViewBag.tipoMensajeId = new SelectList(db.TIPO_MENSAJE__, "tipoMensajeId", "NombreTipoMensaje");
            ViewBag.tipoSalaId = new SelectList(db.TIPO_SALA__, "tipoSalaId", "nombreSala");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: MENSAJE__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "mensajeId,usuarioId,ClienteId,salaId,mensaje,fecha,tipoMensajeId,tipoSalaId,url_link")] MENSAJE__ mENSAJE__)
        {
            if (ModelState.IsValid)
            {
                db.MENSAJE__.Add(mENSAJE__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", mENSAJE__.ClienteId);
            ViewBag.salaId = new SelectList(db.SALA__, "salaId", "salaId", mENSAJE__.salaId);
            ViewBag.tipoMensajeId = new SelectList(db.TIPO_MENSAJE__, "tipoMensajeId", "NombreTipoMensaje", mENSAJE__.tipoMensajeId);
            ViewBag.tipoSalaId = new SelectList(db.TIPO_SALA__, "tipoSalaId", "nombreSala", mENSAJE__.tipoSalaId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", mENSAJE__.usuarioId);
            return View(mENSAJE__);
        }

        // GET: MENSAJE__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENSAJE__ mENSAJE__ = await db.MENSAJE__.FindAsync(id);
            if (mENSAJE__ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", mENSAJE__.ClienteId);
            ViewBag.salaId = new SelectList(db.SALA__, "salaId", "salaId", mENSAJE__.salaId);
            ViewBag.tipoMensajeId = new SelectList(db.TIPO_MENSAJE__, "tipoMensajeId", "NombreTipoMensaje", mENSAJE__.tipoMensajeId);
            ViewBag.tipoSalaId = new SelectList(db.TIPO_SALA__, "tipoSalaId", "nombreSala", mENSAJE__.tipoSalaId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", mENSAJE__.usuarioId);
            return View(mENSAJE__);
        }

        // POST: MENSAJE__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "mensajeId,usuarioId,ClienteId,salaId,mensaje,fecha,tipoMensajeId,tipoSalaId,url_link")] MENSAJE__ mENSAJE__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mENSAJE__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", mENSAJE__.ClienteId);
            ViewBag.salaId = new SelectList(db.SALA__, "salaId", "salaId", mENSAJE__.salaId);
            ViewBag.tipoMensajeId = new SelectList(db.TIPO_MENSAJE__, "tipoMensajeId", "NombreTipoMensaje", mENSAJE__.tipoMensajeId);
            ViewBag.tipoSalaId = new SelectList(db.TIPO_SALA__, "tipoSalaId", "nombreSala", mENSAJE__.tipoSalaId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", mENSAJE__.usuarioId);
            return View(mENSAJE__);
        }

        // GET: MENSAJE__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENSAJE__ mENSAJE__ = await db.MENSAJE__.FindAsync(id);
            if (mENSAJE__ == null)
            {
                return HttpNotFound();
            }
            return View(mENSAJE__);
        }

        // POST: MENSAJE__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MENSAJE__ mENSAJE__ = await db.MENSAJE__.FindAsync(id);
            db.MENSAJE__.Remove(mENSAJE__);
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
