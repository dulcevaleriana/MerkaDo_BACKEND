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
    public class LOG_ACTION_CLIENTEController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: LOG_ACTION_CLIENTE
        public async Task<ActionResult> Index()
        {
            var lOG_ACTION_CLIENTE = db.LOG_ACTION_CLIENTE.Include(l => l.CLIENTES__).Include(l => l.TIPO_ESTADISTICAS_).Include(l => l.TIPO_NOTIFICACION_);
            return View(await lOG_ACTION_CLIENTE.ToListAsync());
        }

        // GET: LOG_ACTION_CLIENTE/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION_CLIENTE lOG_ACTION_CLIENTE = await db.LOG_ACTION_CLIENTE.FindAsync(id);
            if (lOG_ACTION_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(lOG_ACTION_CLIENTE);
        }

        // GET: LOG_ACTION_CLIENTE/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas");
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion");
            return View();
        }

        // POST: LOG_ACTION_CLIENTE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LogId,tipoNotificacionId,tipoEstadisticasId,ClienteId,fechaEjecución")] LOG_ACTION_CLIENTE lOG_ACTION_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.LOG_ACTION_CLIENTE.Add(lOG_ACTION_CLIENTE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", lOG_ACTION_CLIENTE.ClienteId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION_CLIENTE.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION_CLIENTE.tipoNotificacionId);
            return View(lOG_ACTION_CLIENTE);
        }

        // GET: LOG_ACTION_CLIENTE/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION_CLIENTE lOG_ACTION_CLIENTE = await db.LOG_ACTION_CLIENTE.FindAsync(id);
            if (lOG_ACTION_CLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", lOG_ACTION_CLIENTE.ClienteId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION_CLIENTE.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION_CLIENTE.tipoNotificacionId);
            return View(lOG_ACTION_CLIENTE);
        }

        // POST: LOG_ACTION_CLIENTE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LogId,tipoNotificacionId,tipoEstadisticasId,ClienteId,fechaEjecución")] LOG_ACTION_CLIENTE lOG_ACTION_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOG_ACTION_CLIENTE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", lOG_ACTION_CLIENTE.ClienteId);
            ViewBag.tipoEstadisticasId = new SelectList(db.TIPO_ESTADISTICAS_, "tipoEstadisticasId", "nombreTipoEstadisticas", lOG_ACTION_CLIENTE.tipoEstadisticasId);
            ViewBag.tipoNotificacionId = new SelectList(db.TIPO_NOTIFICACION_, "tipoNotificacionId", "nombreTipoNotificacion", lOG_ACTION_CLIENTE.tipoNotificacionId);
            return View(lOG_ACTION_CLIENTE);
        }

        // GET: LOG_ACTION_CLIENTE/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_ACTION_CLIENTE lOG_ACTION_CLIENTE = await db.LOG_ACTION_CLIENTE.FindAsync(id);
            if (lOG_ACTION_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(lOG_ACTION_CLIENTE);
        }

        // POST: LOG_ACTION_CLIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LOG_ACTION_CLIENTE lOG_ACTION_CLIENTE = await db.LOG_ACTION_CLIENTE.FindAsync(id);
            db.LOG_ACTION_CLIENTE.Remove(lOG_ACTION_CLIENTE);
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
