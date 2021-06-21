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
    [RoutePrefix("API/facturas")]
    public class FACTURAsController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: FACTURAs
        public async Task<ActionResult> Index()
        {
            var fACTURAs = db.FACTURAs.Include(f => f.CARRITO_COMPRAS_).Include(f => f.CLIENTES__).Include(f => f.COMPRA__).Include(f => f.SUPERMERCADO_);
            return View(await fACTURAs.ToListAsync());
        }

        // GET: FACTURAs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = await db.FACTURAs.FindAsync(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // GET: FACTURAs/Create
        public ActionResult Create()
        {
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId");
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            ViewBag.comprasId = new SelectList(db.COMPRA__, "comprasId", "direccion");
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado");
            return View();
        }

        // POST: FACTURAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "factura1,supermercadoId,ClienteId,comprasId,carritoComprasId,fecha,statusTarjetaCredito,comprobanteFiscal,comprobanteFiscalId")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.FACTURAs.Add(fACTURA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", fACTURA.carritoComprasId);
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", fACTURA.ClienteId);
            ViewBag.comprasId = new SelectList(db.COMPRA__, "comprasId", "direccion", fACTURA.comprasId);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", fACTURA.supermercadoId);
            return View(fACTURA);
        }

        // GET: FACTURAs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = await db.FACTURAs.FindAsync(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", fACTURA.carritoComprasId);
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", fACTURA.ClienteId);
            ViewBag.comprasId = new SelectList(db.COMPRA__, "comprasId", "direccion", fACTURA.comprasId);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", fACTURA.supermercadoId);
            return View(fACTURA);
        }

        // POST: FACTURAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "factura1,supermercadoId,ClienteId,comprasId,carritoComprasId,fecha,statusTarjetaCredito,comprobanteFiscal,comprobanteFiscalId")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", fACTURA.carritoComprasId);
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", fACTURA.ClienteId);
            ViewBag.comprasId = new SelectList(db.COMPRA__, "comprasId", "direccion", fACTURA.comprasId);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", fACTURA.supermercadoId);
            return View(fACTURA);
        }

        // GET: FACTURAs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = await db.FACTURAs.FindAsync(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // POST: FACTURAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FACTURA fACTURA = await db.FACTURAs.FindAsync(id);
            db.FACTURAs.Remove(fACTURA);
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
