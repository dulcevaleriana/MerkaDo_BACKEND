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
    [RoutePrefix("API/logActionUsuario")]
    public class LOG_ACTION_USUARIOController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: LOG_ACTION_USUARIO
        public async Task<ActionResult> Index()
        {
            var lOG_ACTION_USUARIO = db.LOG_ACTION_USUARIO.Include(l => l.ROL_USUARIO).Include(l => l.TIPO_ESTADISTICAS_).Include(l => l.TIPO_NOTIFICACION_).Include(l => l.USUARIO__);
            return View(await lOG_ACTION_USUARIO.ToListAsync());
        }

        // GET: LOG_ACTION_USUARIO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION_USUARIO lOG_ACTION_USUARIO = await db.LOG_ACTION_USUARIO.FindAsync(id);
            if (lOG_ACTION_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(lOG_ACTION_USUARIO);
        }

        // GET: LOG_ACTION_USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol");
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas");
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: LOG_ACTION_USUARIO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LogId,tipoNotificacionId,tipoEstadisticasId,usuarioId,rolId,fechaEjecución")] LOG_ACTION_USUARIO lOG_ACTION_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.LOG_ACTION_USUARIO.Add(lOG_ACTION_USUARIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", lOG_ACTION_USUARIO.rolId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION_USUARIO.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION_USUARIO.tipoNotificacionId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", lOG_ACTION_USUARIO.usuarioId);
            return View(lOG_ACTION_USUARIO);
        }

        // GET: LOG_ACTION_USUARIO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION_USUARIO lOG_ACTION_USUARIO = await db.LOG_ACTION_USUARIO.FindAsync(id);
            if (lOG_ACTION_USUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", lOG_ACTION_USUARIO.rolId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION_USUARIO.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION_USUARIO.tipoNotificacionId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", lOG_ACTION_USUARIO.usuarioId);
            return View(lOG_ACTION_USUARIO);
        }

        // POST: LOG_ACTION_USUARIO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LogId,tipoNotificacionId,tipoEstadisticasId,usuarioId,rolId,fechaEjecución")] LOG_ACTION_USUARIO lOG_ACTION_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOG_ACTION_USUARIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", lOG_ACTION_USUARIO.rolId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION_USUARIO.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION_USUARIO.tipoNotificacionId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", lOG_ACTION_USUARIO.usuarioId);
            return View(lOG_ACTION_USUARIO);
        }

        // GET: LOG_ACTION_USUARIO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION_USUARIO lOG_ACTION_USUARIO = await db.LOG_ACTION_USUARIO.FindAsync(id);
            if (lOG_ACTION_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(lOG_ACTION_USUARIO);
        }

        // POST: LOG_ACTION_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LOG_ACTION_USUARIO lOG_ACTION_USUARIO = await db.LOG_ACTION_USUARIO.FindAsync(id);
            db.LOG_ACTION_USUARIO.Remove(lOG_ACTION_USUARIO);
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
