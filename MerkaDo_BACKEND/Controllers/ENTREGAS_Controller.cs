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
    [RoutePrefix("Api/Entregas")]
    public class ENTREGAS_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: ENTREGAS_
        public async Task<ActionResult> Index()
        {
            var eNTREGAS_ = db.ENTREGAS_.Include(e => e.COMPRA__).Include(e => e.TIPO_STATUS_COMPRA).Include(e => e.USUARIO__).Include(e => e.USUARIO__1);
            return View(await eNTREGAS_.ToListAsync());
        }

        // GET: ENTREGAS_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENTREGAS_ eNTREGAS_ = await db.ENTREGAS_.FindAsync(id);
            if (eNTREGAS_ == null)
            {
                return HttpNotFound();
            }
            return View(eNTREGAS_);
        }

        // GET: ENTREGAS_/Create
        public ActionResult Create()
        {
            ViewBag.comprasId = new SelectList(db.COMPRA__, "comprasId", "direccion");
            ViewBag.statusTipoCompraId = new SelectList(db.TIPO_STATUS_COMPRA, "statusTipoCompraId", "nombreStatusTipoCompra");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: ENTREGAS_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "entregaId,comprasId,usuarioId,mensajeroEncargadoId,ubicacionActualEntrega,ubicacionDestinoEntrega,statusTipoCompraId,firmaClientePaqueteCompra,statusFirmaEntregaPaqueteCompra")] ENTREGAS_ eNTREGAS_)
        {
            if (ModelState.IsValid)
            {
                db.ENTREGAS_.Add(eNTREGAS_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.comprasId = new SelectList(db.COMPRA__, "comprasId", "direccion", eNTREGAS_.comprasId);
            ViewBag.statusTipoCompraId = new SelectList(db.TIPO_STATUS_COMPRA, "statusTipoCompraId", "nombreStatusTipoCompra", eNTREGAS_.statusTipoCompraId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", eNTREGAS_.usuarioId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", eNTREGAS_.usuarioId);
            return View(eNTREGAS_);
        }

        // GET: ENTREGAS_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENTREGAS_ eNTREGAS_ = await db.ENTREGAS_.FindAsync(id);
            if (eNTREGAS_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.comprasId = new SelectList(db.COMPRA__, "comprasId", "direccion", eNTREGAS_.comprasId);
            ViewBag.statusTipoCompraId = new SelectList(db.TIPO_STATUS_COMPRA, "statusTipoCompraId", "nombreStatusTipoCompra", eNTREGAS_.statusTipoCompraId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", eNTREGAS_.usuarioId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", eNTREGAS_.usuarioId);
            return View(eNTREGAS_);
        }

        // POST: ENTREGAS_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "entregaId,comprasId,usuarioId,mensajeroEncargadoId,ubicacionActualEntrega,ubicacionDestinoEntrega,statusTipoCompraId,firmaClientePaqueteCompra,statusFirmaEntregaPaqueteCompra")] ENTREGAS_ eNTREGAS_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNTREGAS_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.comprasId = new SelectList(db.COMPRA__, "comprasId", "direccion", eNTREGAS_.comprasId);
            ViewBag.statusTipoCompraId = new SelectList(db.TIPO_STATUS_COMPRA, "statusTipoCompraId", "nombreStatusTipoCompra", eNTREGAS_.statusTipoCompraId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", eNTREGAS_.usuarioId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", eNTREGAS_.usuarioId);
            return View(eNTREGAS_);
        }

        // GET: ENTREGAS_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENTREGAS_ eNTREGAS_ = await db.ENTREGAS_.FindAsync(id);
            if (eNTREGAS_ == null)
            {
                return HttpNotFound();
            }
            return View(eNTREGAS_);
        }

        // POST: ENTREGAS_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ENTREGAS_ eNTREGAS_ = await db.ENTREGAS_.FindAsync(id);
            db.ENTREGAS_.Remove(eNTREGAS_);
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
