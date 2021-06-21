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
    [RoutePrefix("API/carritoCompras")]
    public class CARRITO_COMPRAS_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: CARRITO_COMPRAS_
        public async Task<ActionResult> Index()
        {
            var cARRITO_COMPRAS_ = db.CARRITO_COMPRAS_.Include(c => c.LISTA_PRODUCTO_);
            return View(await cARRITO_COMPRAS_.ToListAsync());
        }

        // GET: CARRITO_COMPRAS_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITO_COMPRAS_ cARRITO_COMPRAS_ = await db.CARRITO_COMPRAS_.FindAsync(id);
            if (cARRITO_COMPRAS_ == null)
            {
                return HttpNotFound();
            }
            return View(cARRITO_COMPRAS_);
        }

        // GET: CARRITO_COMPRAS_/Create
        public ActionResult Create()
        {
            ViewBag.listaProductosId = new SelectList(db.LISTA_PRODUCTO_, "listaProductosId", "listaProductosId");
            return View();
        }

        // POST: CARRITO_COMPRAS_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "carritoComprasId,listaProductosId,totalPago")] CARRITO_COMPRAS_ cARRITO_COMPRAS_)
        {
            if (ModelState.IsValid)
            {
                db.CARRITO_COMPRAS_.Add(cARRITO_COMPRAS_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.listaProductosId = new SelectList(db.LISTA_PRODUCTO_, "listaProductosId", "listaProductosId", cARRITO_COMPRAS_.listaProductosId);
            return View(cARRITO_COMPRAS_);
        }

        // GET: CARRITO_COMPRAS_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITO_COMPRAS_ cARRITO_COMPRAS_ = await db.CARRITO_COMPRAS_.FindAsync(id);
            if (cARRITO_COMPRAS_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.listaProductosId = new SelectList(db.LISTA_PRODUCTO_, "listaProductosId", "listaProductosId", cARRITO_COMPRAS_.listaProductosId);
            return View(cARRITO_COMPRAS_);
        }

        // POST: CARRITO_COMPRAS_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "carritoComprasId,listaProductosId,totalPago")] CARRITO_COMPRAS_ cARRITO_COMPRAS_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARRITO_COMPRAS_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.listaProductosId = new SelectList(db.LISTA_PRODUCTO_, "listaProductosId", "listaProductosId", cARRITO_COMPRAS_.listaProductosId);
            return View(cARRITO_COMPRAS_);
        }

        // GET: CARRITO_COMPRAS_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITO_COMPRAS_ cARRITO_COMPRAS_ = await db.CARRITO_COMPRAS_.FindAsync(id);
            if (cARRITO_COMPRAS_ == null)
            {
                return HttpNotFound();
            }
            return View(cARRITO_COMPRAS_);
        }

        // POST: CARRITO_COMPRAS_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CARRITO_COMPRAS_ cARRITO_COMPRAS_ = await db.CARRITO_COMPRAS_.FindAsync(id);
            db.CARRITO_COMPRAS_.Remove(cARRITO_COMPRAS_);
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
