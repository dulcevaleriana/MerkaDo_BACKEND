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
    public class CATEGORIA_PRODUCTOController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: CATEGORIA_PRODUCTO
        public async Task<ActionResult> Index()
        {
            return View(await db.CATEGORIA_PRODUCTO.ToListAsync());
        }

        // GET: CATEGORIA_PRODUCTO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO = await db.CATEGORIA_PRODUCTO.FindAsync(id);
            if (cATEGORIA_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_PRODUCTO);
        }

        // GET: CATEGORIA_PRODUCTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIA_PRODUCTO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "categoriaProductoId,nombrecategoriaProducto")] CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIA_PRODUCTO.Add(cATEGORIA_PRODUCTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cATEGORIA_PRODUCTO);
        }

        // GET: CATEGORIA_PRODUCTO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO = await db.CATEGORIA_PRODUCTO.FindAsync(id);
            if (cATEGORIA_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_PRODUCTO);
        }

        // POST: CATEGORIA_PRODUCTO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "categoriaProductoId,nombrecategoriaProducto")] CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIA_PRODUCTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cATEGORIA_PRODUCTO);
        }

        // GET: CATEGORIA_PRODUCTO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO = await db.CATEGORIA_PRODUCTO.FindAsync(id);
            if (cATEGORIA_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_PRODUCTO);
        }

        // POST: CATEGORIA_PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO = await db.CATEGORIA_PRODUCTO.FindAsync(id);
            db.CATEGORIA_PRODUCTO.Remove(cATEGORIA_PRODUCTO);
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
