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
    public class HISTORIAL_COMPRA_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: HISTORIAL_COMPRA_
        public async Task<ActionResult> Index()
        {
            var hISTORIAL_COMPRA_ = db.HISTORIAL_COMPRA_.Include(h => h.CARRITO_COMPRAS_).Include(h => h.USUARIO__);
            return View(await hISTORIAL_COMPRA_.ToListAsync());
        }

        // GET: HISTORIAL_COMPRA_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_COMPRA_ hISTORIAL_COMPRA_ = await db.HISTORIAL_COMPRA_.FindAsync(id);
            if (hISTORIAL_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL_COMPRA_);
        }

        // GET: HISTORIAL_COMPRA_/Create
        public ActionResult Create()
        {
            ViewBag.carritoCompraId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId");
            ViewBag.historialCompraId = new SelectList(db.HISTORIAL_COMPRA_, "historialCompraId", "nombreCliente");
            ViewBag.historialCompraId = new SelectList(db.HISTORIAL_COMPRA_, "historialCompraId", "nombreCliente");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: HISTORIAL_COMPRA_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "historialCompraId,usuarioId,nombreCliente,razonSocialEmpresa,carritoCompraId,fechaEnvio,estadoTipoHistorialCompra,totalPago")] HISTORIAL_COMPRA_ hISTORIAL_COMPRA_)
        {
            if (ModelState.IsValid)
            {
                db.HISTORIAL_COMPRA_.Add(hISTORIAL_COMPRA_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.carritoCompraId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", hISTORIAL_COMPRA_.carritoCompraId);
            ViewBag.historialCompraId = new SelectList(db.HISTORIAL_COMPRA_, "historialCompraId", "nombreCliente", hISTORIAL_COMPRA_.historialCompraId);
            ViewBag.historialCompraId = new SelectList(db.HISTORIAL_COMPRA_, "historialCompraId", "nombreCliente", hISTORIAL_COMPRA_.historialCompraId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", hISTORIAL_COMPRA_.usuarioId);
            return View(hISTORIAL_COMPRA_);
        }

        // GET: HISTORIAL_COMPRA_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_COMPRA_ hISTORIAL_COMPRA_ = await db.HISTORIAL_COMPRA_.FindAsync(id);
            if (hISTORIAL_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.carritoCompraId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", hISTORIAL_COMPRA_.carritoCompraId);
            ViewBag.historialCompraId = new SelectList(db.HISTORIAL_COMPRA_, "historialCompraId", "nombreCliente", hISTORIAL_COMPRA_.historialCompraId);
            ViewBag.historialCompraId = new SelectList(db.HISTORIAL_COMPRA_, "historialCompraId", "nombreCliente", hISTORIAL_COMPRA_.historialCompraId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", hISTORIAL_COMPRA_.usuarioId);
            return View(hISTORIAL_COMPRA_);
        }

        // POST: HISTORIAL_COMPRA_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "historialCompraId,usuarioId,nombreCliente,razonSocialEmpresa,carritoCompraId,fechaEnvio,estadoTipoHistorialCompra,totalPago")] HISTORIAL_COMPRA_ hISTORIAL_COMPRA_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hISTORIAL_COMPRA_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.carritoCompraId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", hISTORIAL_COMPRA_.carritoCompraId);
            ViewBag.historialCompraId = new SelectList(db.HISTORIAL_COMPRA_, "historialCompraId", "nombreCliente", hISTORIAL_COMPRA_.historialCompraId);
            ViewBag.historialCompraId = new SelectList(db.HISTORIAL_COMPRA_, "historialCompraId", "nombreCliente", hISTORIAL_COMPRA_.historialCompraId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", hISTORIAL_COMPRA_.usuarioId);
            return View(hISTORIAL_COMPRA_);
        }

        // GET: HISTORIAL_COMPRA_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_COMPRA_ hISTORIAL_COMPRA_ = await db.HISTORIAL_COMPRA_.FindAsync(id);
            if (hISTORIAL_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL_COMPRA_);
        }

        // POST: HISTORIAL_COMPRA_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HISTORIAL_COMPRA_ hISTORIAL_COMPRA_ = await db.HISTORIAL_COMPRA_.FindAsync(id);
            db.HISTORIAL_COMPRA_.Remove(hISTORIAL_COMPRA_);
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
