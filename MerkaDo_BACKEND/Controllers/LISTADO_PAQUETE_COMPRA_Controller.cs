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
    [RoutePrefix("API/listadoPaqueteCompra")]
    public class LISTADO_PAQUETE_COMPRA_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: LISTADO_PAQUETE_COMPRA_
        public async Task<ActionResult> Index()
        {
            var lISTADO_PAQUETE_COMPRA_ = db.LISTADO_PAQUETE_COMPRA_.Include(l => l.CARRITO_COMPRAS_).Include(l => l.CLIENTES__);
            return View(await lISTADO_PAQUETE_COMPRA_.ToListAsync());
        }

        // GET: LISTADO_PAQUETE_COMPRA_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTADO_PAQUETE_COMPRA_ lISTADO_PAQUETE_COMPRA_ = await db.LISTADO_PAQUETE_COMPRA_.FindAsync(id);
            if (lISTADO_PAQUETE_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            return View(lISTADO_PAQUETE_COMPRA_);
        }

        // GET: LISTADO_PAQUETE_COMPRA_/Create
        public ActionResult Create()
        {
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId");
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            return View();
        }

        // POST: LISTADO_PAQUETE_COMPRA_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "listadoPaqueteCompraId,ClienteId,nombreCliente,razonSocialEmpresa,carritoComprasId,totalPago,estadoListadoPaqueteCompra,fechaCreacionPaqueteCompra,errorReportado,mensajePaqueteCompra,statusFirmaEntregaPaqueteCompra,firmaClientePaqueteCompra,ubicacionActualPaqueteCompra,ubicacionDestinoPaqueteCompra")] LISTADO_PAQUETE_COMPRA_ lISTADO_PAQUETE_COMPRA_)
        {
            if (ModelState.IsValid)
            {
                db.LISTADO_PAQUETE_COMPRA_.Add(lISTADO_PAQUETE_COMPRA_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", lISTADO_PAQUETE_COMPRA_.carritoComprasId);
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", lISTADO_PAQUETE_COMPRA_.ClienteId);
            return View(lISTADO_PAQUETE_COMPRA_);
        }

        // GET: LISTADO_PAQUETE_COMPRA_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTADO_PAQUETE_COMPRA_ lISTADO_PAQUETE_COMPRA_ = await db.LISTADO_PAQUETE_COMPRA_.FindAsync(id);
            if (lISTADO_PAQUETE_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", lISTADO_PAQUETE_COMPRA_.carritoComprasId);
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", lISTADO_PAQUETE_COMPRA_.ClienteId);
            return View(lISTADO_PAQUETE_COMPRA_);
        }

        // POST: LISTADO_PAQUETE_COMPRA_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "listadoPaqueteCompraId,ClienteId,nombreCliente,razonSocialEmpresa,carritoComprasId,totalPago,estadoListadoPaqueteCompra,fechaCreacionPaqueteCompra,errorReportado,mensajePaqueteCompra,statusFirmaEntregaPaqueteCompra,firmaClientePaqueteCompra,ubicacionActualPaqueteCompra,ubicacionDestinoPaqueteCompra")] LISTADO_PAQUETE_COMPRA_ lISTADO_PAQUETE_COMPRA_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lISTADO_PAQUETE_COMPRA_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", lISTADO_PAQUETE_COMPRA_.carritoComprasId);
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", lISTADO_PAQUETE_COMPRA_.ClienteId);
            return View(lISTADO_PAQUETE_COMPRA_);
        }

        // GET: LISTADO_PAQUETE_COMPRA_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTADO_PAQUETE_COMPRA_ lISTADO_PAQUETE_COMPRA_ = await db.LISTADO_PAQUETE_COMPRA_.FindAsync(id);
            if (lISTADO_PAQUETE_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            return View(lISTADO_PAQUETE_COMPRA_);
        }

        // POST: LISTADO_PAQUETE_COMPRA_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LISTADO_PAQUETE_COMPRA_ lISTADO_PAQUETE_COMPRA_ = await db.LISTADO_PAQUETE_COMPRA_.FindAsync(id);
            db.LISTADO_PAQUETE_COMPRA_.Remove(lISTADO_PAQUETE_COMPRA_);
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
