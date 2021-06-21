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
    [RoutePrefix("API/listaProducto")]
    public class LISTA_PRODUCTO_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: LISTA_PRODUCTO_
        public async Task<ActionResult> Index()
        {
            var lISTA_PRODUCTO_ = db.LISTA_PRODUCTO_.Include(l => l.PRODUCTO__);
            return View(await lISTA_PRODUCTO_.ToListAsync());
        }

        // GET: LISTA_PRODUCTO_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTA_PRODUCTO_ lISTA_PRODUCTO_ = await db.LISTA_PRODUCTO_.FindAsync(id);
            if (lISTA_PRODUCTO_ == null)
            {
                return HttpNotFound();
            }
            return View(lISTA_PRODUCTO_);
        }

        // GET: LISTA_PRODUCTO_/Create
        public ActionResult Create()
        {
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto");
            return View();
        }

        // POST: LISTA_PRODUCTO_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "listaProductosId,productoId,precioProducto,totalPago")] LISTA_PRODUCTO_ lISTA_PRODUCTO_)
        {
            if (ModelState.IsValid)
            {
                db.LISTA_PRODUCTO_.Add(lISTA_PRODUCTO_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", lISTA_PRODUCTO_.productoId);
            return View(lISTA_PRODUCTO_);
        }

        // GET: LISTA_PRODUCTO_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTA_PRODUCTO_ lISTA_PRODUCTO_ = await db.LISTA_PRODUCTO_.FindAsync(id);
            if (lISTA_PRODUCTO_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", lISTA_PRODUCTO_.productoId);
            return View(lISTA_PRODUCTO_);
        }

        // POST: LISTA_PRODUCTO_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "listaProductosId,productoId,precioProducto,totalPago")] LISTA_PRODUCTO_ lISTA_PRODUCTO_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lISTA_PRODUCTO_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", lISTA_PRODUCTO_.productoId);
            return View(lISTA_PRODUCTO_);
        }

        // GET: LISTA_PRODUCTO_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LISTA_PRODUCTO_ lISTA_PRODUCTO_ = await db.LISTA_PRODUCTO_.FindAsync(id);
            if (lISTA_PRODUCTO_ == null)
            {
                return HttpNotFound();
            }
            return View(lISTA_PRODUCTO_);
        }

        // POST: LISTA_PRODUCTO_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LISTA_PRODUCTO_ lISTA_PRODUCTO_ = await db.LISTA_PRODUCTO_.FindAsync(id);
            db.LISTA_PRODUCTO_.Remove(lISTA_PRODUCTO_);
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
