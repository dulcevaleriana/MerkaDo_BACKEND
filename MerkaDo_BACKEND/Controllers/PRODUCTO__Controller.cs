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
    [RoutePrefix("Api/Producto")]
    public class PRODUCTO__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: PRODUCTO__
        public async Task<ActionResult> Index()
        {
            var pRODUCTO__ = db.PRODUCTO__.Include(p => p.CATEGORIA_PRODUCTO).Include(p => p.SUCURSAL_).Include(p => p.SUPERMERCADO_);
            return View(await pRODUCTO__.ToListAsync());
        }

        // GET: PRODUCTO__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO__ pRODUCTO__ = await db.PRODUCTO__.FindAsync(id);
            if (pRODUCTO__ == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO__);
        }

        // GET: PRODUCTO__/Create
        public ActionResult Create()
        {
            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto");
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal");
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado");
            return View();
        }

        // POST: PRODUCTO__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "productoId,nombreProducto,imagenProducto,cantidadProducto,sucursalId,supermercadoId,precioProducto,categoriaProductoId,descripcionProducto,tablaNutricionalProductoIMG")] PRODUCTO__ pRODUCTO__)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO__.Add(pRODUCTO__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto", pRODUCTO__.categoriaProductoId);
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal", pRODUCTO__.sucursalId);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", pRODUCTO__.supermercadoId);
            return View(pRODUCTO__);
        }

        // GET: PRODUCTO__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO__ pRODUCTO__ = await db.PRODUCTO__.FindAsync(id);
            if (pRODUCTO__ == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto", pRODUCTO__.categoriaProductoId);
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal", pRODUCTO__.sucursalId);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", pRODUCTO__.supermercadoId);
            return View(pRODUCTO__);
        }

        // POST: PRODUCTO__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "productoId,nombreProducto,imagenProducto,cantidadProducto,sucursalId,supermercadoId,precioProducto,categoriaProductoId,descripcionProducto,tablaNutricionalProductoIMG")] PRODUCTO__ pRODUCTO__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto", pRODUCTO__.categoriaProductoId);
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal", pRODUCTO__.sucursalId);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", pRODUCTO__.supermercadoId);
            return View(pRODUCTO__);
        }

        // GET: PRODUCTO__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO__ pRODUCTO__ = await db.PRODUCTO__.FindAsync(id);
            if (pRODUCTO__ == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO__);
        }

        // POST: PRODUCTO__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PRODUCTO__ pRODUCTO__ = await db.PRODUCTO__.FindAsync(id);
            db.PRODUCTO__.Remove(pRODUCTO__);
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
