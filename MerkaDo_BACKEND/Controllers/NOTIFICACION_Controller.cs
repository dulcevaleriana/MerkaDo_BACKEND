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
    public class NOTIFICACION_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: NOTIFICACION_
        public async Task<ActionResult> Index()
        {
            var nOTIFICACION_ = db.NOTIFICACION_.Include(n => n.CLIENTES__).Include(n => n.ROL_USUARIO).Include(n => n.TIPO_NOTIFICACION_);
            return View(await nOTIFICACION_.ToListAsync());
        }

        // GET: NOTIFICACION_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTIFICACION_ nOTIFICACION_ = await db.NOTIFICACION_.FindAsync(id);
            if (nOTIFICACION_ == null)
            {
                return HttpNotFound();
            }
            return View(nOTIFICACION_);
        }

        // GET: NOTIFICACION_/Create
        public ActionResult Create()
        {
            ViewBag.usuarioReceptorId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol");
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion");
            return View();
        }

        // POST: NOTIFICACION_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "notificacionId,rolId,tipoNotificacionId,usuarioReceptorId,mensajeNotificacion,fechaNotificacion")] NOTIFICACION_ nOTIFICACION_)
        {
            if (ModelState.IsValid)
            {
                db.NOTIFICACION_.Add(nOTIFICACION_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.usuarioReceptorId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", nOTIFICACION_.usuarioReceptorId);
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", nOTIFICACION_.rolId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", nOTIFICACION_.tipoNotificacionId);
            return View(nOTIFICACION_);
        }

        // GET: NOTIFICACION_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTIFICACION_ nOTIFICACION_ = await db.NOTIFICACION_.FindAsync(id);
            if (nOTIFICACION_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuarioReceptorId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", nOTIFICACION_.usuarioReceptorId);
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", nOTIFICACION_.rolId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", nOTIFICACION_.tipoNotificacionId);
            return View(nOTIFICACION_);
        }

        // POST: NOTIFICACION_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "notificacionId,rolId,tipoNotificacionId,usuarioReceptorId,mensajeNotificacion,fechaNotificacion")] NOTIFICACION_ nOTIFICACION_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOTIFICACION_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioReceptorId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", nOTIFICACION_.usuarioReceptorId);
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", nOTIFICACION_.rolId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", nOTIFICACION_.tipoNotificacionId);
            return View(nOTIFICACION_);
        }

        // GET: NOTIFICACION_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTIFICACION_ nOTIFICACION_ = await db.NOTIFICACION_.FindAsync(id);
            if (nOTIFICACION_ == null)
            {
                return HttpNotFound();
            }
            return View(nOTIFICACION_);
        }

        // POST: NOTIFICACION_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NOTIFICACION_ nOTIFICACION_ = await db.NOTIFICACION_.FindAsync(id);
            db.NOTIFICACION_.Remove(nOTIFICACION_);
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
