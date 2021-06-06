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
    [RoutePrefix("Api/Logaction")]
    public class LOG_ACTION__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: LOG_ACTION__
        public async Task<ActionResult> Index()
        {
            var lOG_ACTION__ = db.LOG_ACTION__.Include(l => l.ROL_USUARIO).Include(l => l.TIPO_ESTADISTICAS_).Include(l => l.TIPO_NOTIFICACION_).Include(l => l.USUARIO__);
            return View(await lOG_ACTION__.ToListAsync());
        }

        // GET: LOG_ACTION__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION__ lOG_ACTION__ = await db.LOG_ACTION__.FindAsync(id);
            if (lOG_ACTION__ == null)
            {
                return HttpNotFound();
            }
            return View(lOG_ACTION__);
        }

        // GET: LOG_ACTION__/Create
        public ActionResult Create()
        {
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol");
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas");
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: LOG_ACTION__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LogId,tipoNotificacionId,tipoEstadisticasId,usuarioId,rolId,fechaEjecución")] LOG_ACTION__ lOG_ACTION__)
        {
            if (ModelState.IsValid)
            {
                db.LOG_ACTION__.Add(lOG_ACTION__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", lOG_ACTION__.rolId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION__.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION__.tipoNotificacionId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", lOG_ACTION__.usuarioId);
            return View(lOG_ACTION__);
        }

        // GET: LOG_ACTION__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION__ lOG_ACTION__ = await db.LOG_ACTION__.FindAsync(id);
            if (lOG_ACTION__ == null)
            {
                return HttpNotFound();
            }
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", lOG_ACTION__.rolId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION__.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION__.tipoNotificacionId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", lOG_ACTION__.usuarioId);
            return View(lOG_ACTION__);
        }

        // POST: LOG_ACTION__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LogId,tipoNotificacionId,tipoEstadisticasId,usuarioId,rolId,fechaEjecución")] LOG_ACTION__ lOG_ACTION__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOG_ACTION__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", lOG_ACTION__.rolId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION__.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION__.tipoNotificacionId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", lOG_ACTION__.usuarioId);
            return View(lOG_ACTION__);
        }

        // GET: LOG_ACTION__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION__ lOG_ACTION__ = await db.LOG_ACTION__.FindAsync(id);
            if (lOG_ACTION__ == null)
            {
                return HttpNotFound();
            }
            return View(lOG_ACTION__);
        }

        // POST: LOG_ACTION__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LOG_ACTION__ lOG_ACTION__ = await db.LOG_ACTION__.FindAsync(id);
            db.LOG_ACTION__.Remove(lOG_ACTION__);
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
