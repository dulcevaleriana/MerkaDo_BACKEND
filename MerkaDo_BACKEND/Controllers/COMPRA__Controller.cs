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
    [RoutePrefix("API/compra")]
    public class COMPRA__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: COMPRA__
        public async Task<ActionResult> Index()
        {
            var cOMPRA__ = db.COMPRA__.Include(c => c.CARRITO_COMPRAS_).Include(c => c.CUPONES_).Include(c => c.DESCUENTOS_).Include(c => c.METODO_ENVIO);
            return View(await cOMPRA__.ToListAsync());
        }

        // GET: COMPRA__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA__ cOMPRA__ = await db.COMPRA__.FindAsync(id);
            if (cOMPRA__ == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA__);
        }

        // GET: COMPRA__/Create
        public ActionResult Create()
        {
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId");
            ViewBag.cuponesId = new SelectList(db.CUPONES_, "cuponesId", "nombreCupones");
            ViewBag.descuentoId = new SelectList(db.DESCUENTOS_, "descuentoId", "descuentoId");
            ViewBag.metodoEnvioId = new SelectList(db.METODO_ENVIO, "metodoEnvioId", "nombreMetodoEnvio");
            return View();
        }

        // POST: COMPRA__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "comprasId,carritoComprasId,precioInicialCompra,subTotalCompraITBIS,cuponesId,descuentoId,direccion,metodoEnvioId,totalPago,estado")] COMPRA__ cOMPRA__)
        {
            if (ModelState.IsValid)
            {
                db.COMPRA__.Add(cOMPRA__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", cOMPRA__.carritoComprasId);
            ViewBag.cuponesId = new SelectList(db.CUPONES_, "cuponesId", "nombreCupones", cOMPRA__.cuponesId);
            ViewBag.descuentoId = new SelectList(db.DESCUENTOS_, "descuentoId", "descuentoId", cOMPRA__.descuentoId);
            ViewBag.metodoEnvioId = new SelectList(db.METODO_ENVIO, "metodoEnvioId", "nombreMetodoEnvio", cOMPRA__.metodoEnvioId);
            return View(cOMPRA__);
        }

        // GET: COMPRA__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA__ cOMPRA__ = await db.COMPRA__.FindAsync(id);
            if (cOMPRA__ == null)
            {
                return HttpNotFound();
            }
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", cOMPRA__.carritoComprasId);
            ViewBag.cuponesId = new SelectList(db.CUPONES_, "cuponesId", "nombreCupones", cOMPRA__.cuponesId);
            ViewBag.descuentoId = new SelectList(db.DESCUENTOS_, "descuentoId", "descuentoId", cOMPRA__.descuentoId);
            ViewBag.metodoEnvioId = new SelectList(db.METODO_ENVIO, "metodoEnvioId", "nombreMetodoEnvio", cOMPRA__.metodoEnvioId);
            return View(cOMPRA__);
        }

        // POST: COMPRA__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "comprasId,carritoComprasId,precioInicialCompra,subTotalCompraITBIS,cuponesId,descuentoId,direccion,metodoEnvioId,totalPago,estado")] COMPRA__ cOMPRA__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPRA__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.carritoComprasId = new SelectList(db.CARRITO_COMPRAS_, "carritoComprasId", "carritoComprasId", cOMPRA__.carritoComprasId);
            ViewBag.cuponesId = new SelectList(db.CUPONES_, "cuponesId", "nombreCupones", cOMPRA__.cuponesId);
            ViewBag.descuentoId = new SelectList(db.DESCUENTOS_, "descuentoId", "descuentoId", cOMPRA__.descuentoId);
            ViewBag.metodoEnvioId = new SelectList(db.METODO_ENVIO, "metodoEnvioId", "nombreMetodoEnvio", cOMPRA__.metodoEnvioId);
            return View(cOMPRA__);
        }

        // GET: COMPRA__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA__ cOMPRA__ = await db.COMPRA__.FindAsync(id);
            if (cOMPRA__ == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA__);
        }

        // POST: COMPRA__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            COMPRA__ cOMPRA__ = await db.COMPRA__.FindAsync(id);
            db.COMPRA__.Remove(cOMPRA__);
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
