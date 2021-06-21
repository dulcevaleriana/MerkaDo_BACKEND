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
    public class DESCUENTOS_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: DESCUENTOS_
        public async Task<ActionResult> Index()
        {
            var dESCUENTOS_ = db.DESCUENTOS_.Include(d => d.CATEGORIA_PRODUCTO).Include(d => d.PRODUCTO__).Include(d => d.USUARIO__);
            return View(await dESCUENTOS_.ToListAsync());
        }

        // GET: DESCUENTOS_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESCUENTOS_ dESCUENTOS_ = await db.DESCUENTOS_.FindAsync(id);
            if (dESCUENTOS_ == null)
            {
                return HttpNotFound();
            }
            return View(dESCUENTOS_);
        }

        // GET: DESCUENTOS_/Create
        public ActionResult Create()
        {
            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto");
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: DESCUENTOS_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "descuentoId,productoId,categoriaProductoId,usuarioId,descuentoAplicar,fechaExpiracionDescuento")] DESCUENTOS_ dESCUENTOS_)
        {
            if (ModelState.IsValid)
            {
                db.DESCUENTOS_.Add(dESCUENTOS_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto", dESCUENTOS_.categoriaProductoId);
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", dESCUENTOS_.productoId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", dESCUENTOS_.usuarioId);
            return View(dESCUENTOS_);
        }

        // GET: DESCUENTOS_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESCUENTOS_ dESCUENTOS_ = await db.DESCUENTOS_.FindAsync(id);
            if (dESCUENTOS_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto", dESCUENTOS_.categoriaProductoId);
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", dESCUENTOS_.productoId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", dESCUENTOS_.usuarioId);
            return View(dESCUENTOS_);
        }

        // POST: DESCUENTOS_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "descuentoId,productoId,categoriaProductoId,usuarioId,descuentoAplicar,fechaExpiracionDescuento")] DESCUENTOS_ dESCUENTOS_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dESCUENTOS_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto", dESCUENTOS_.categoriaProductoId);
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", dESCUENTOS_.productoId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", dESCUENTOS_.usuarioId);
            return View(dESCUENTOS_);
        }

        // GET: DESCUENTOS_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESCUENTOS_ dESCUENTOS_ = await db.DESCUENTOS_.FindAsync(id);
            if (dESCUENTOS_ == null)
            {
                return HttpNotFound();
            }
            return View(dESCUENTOS_);
        }

        // POST: DESCUENTOS_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DESCUENTOS_ dESCUENTOS_ = await db.DESCUENTOS_.FindAsync(id);
            db.DESCUENTOS_.Remove(dESCUENTOS_);
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
