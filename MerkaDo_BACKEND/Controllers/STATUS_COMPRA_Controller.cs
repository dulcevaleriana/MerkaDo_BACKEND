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
    public class STATUS_COMPRA_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: STATUS_COMPRA_
        public async Task<ActionResult> Index()
        {
            var sTATUS_COMPRA_ = db.STATUS_COMPRA_.Include(s => s.CLIENTES__).Include(s => s.TIPO_STATUS_COMPRA);
            return View(await sTATUS_COMPRA_.ToListAsync());
        }

        // GET: STATUS_COMPRA_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATUS_COMPRA_ sTATUS_COMPRA_ = await db.STATUS_COMPRA_.FindAsync(id);
            if (sTATUS_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            return View(sTATUS_COMPRA_);
        }

        // GET: STATUS_COMPRA_/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            ViewBag.statusTipoCompraId = new SelectList(db.TIPO_STATUS_COMPRA, "statusTipoCompraId", "nombreStatusTipoCompra");
            return View();
        }

        // POST: STATUS_COMPRA_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "statusCompraId,ClienteId,nombreCliente,razonSocialEmpresa,carritoComprasId,totalPago,statusTipoCompraId,mensajeroStatusCompra")] STATUS_COMPRA_ sTATUS_COMPRA_)
        {
            if (ModelState.IsValid)
            {
                db.STATUS_COMPRA_.Add(sTATUS_COMPRA_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", sTATUS_COMPRA_.ClienteId);
            ViewBag.statusTipoCompraId = new SelectList(db.TIPO_STATUS_COMPRA, "statusTipoCompraId", "nombreStatusTipoCompra", sTATUS_COMPRA_.statusTipoCompraId);
            return View(sTATUS_COMPRA_);
        }

        // GET: STATUS_COMPRA_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATUS_COMPRA_ sTATUS_COMPRA_ = await db.STATUS_COMPRA_.FindAsync(id);
            if (sTATUS_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", sTATUS_COMPRA_.ClienteId);
            ViewBag.statusTipoCompraId = new SelectList(db.TIPO_STATUS_COMPRA, "statusTipoCompraId", "nombreStatusTipoCompra", sTATUS_COMPRA_.statusTipoCompraId);
            return View(sTATUS_COMPRA_);
        }

        // POST: STATUS_COMPRA_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "statusCompraId,ClienteId,nombreCliente,razonSocialEmpresa,carritoComprasId,totalPago,statusTipoCompraId,mensajeroStatusCompra")] STATUS_COMPRA_ sTATUS_COMPRA_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTATUS_COMPRA_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", sTATUS_COMPRA_.ClienteId);
            ViewBag.statusTipoCompraId = new SelectList(db.TIPO_STATUS_COMPRA, "statusTipoCompraId", "nombreStatusTipoCompra", sTATUS_COMPRA_.statusTipoCompraId);
            return View(sTATUS_COMPRA_);
        }

        // GET: STATUS_COMPRA_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATUS_COMPRA_ sTATUS_COMPRA_ = await db.STATUS_COMPRA_.FindAsync(id);
            if (sTATUS_COMPRA_ == null)
            {
                return HttpNotFound();
            }
            return View(sTATUS_COMPRA_);
        }

        // POST: STATUS_COMPRA_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            STATUS_COMPRA_ sTATUS_COMPRA_ = await db.STATUS_COMPRA_.FindAsync(id);
            db.STATUS_COMPRA_.Remove(sTATUS_COMPRA_);
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
