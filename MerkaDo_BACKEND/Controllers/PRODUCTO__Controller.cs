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
    [RoutePrefix("API/producto")]
    public class PRODUCTO__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: PRODUCTO__
        public async Task<ActionResult> Index()
        {
            var pRODUCTO__ = db.PRODUCTO__.Include(p => p.CATEGORIA_PRODUCTO).Include(p => p.DESCUENTOS_1).Include(p => p.SUCURSAL_).Include(p => p.SUPERMERCADO_);
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
            ViewBag.descuentoId = new SelectList(db.DESCUENTOS_, "descuentoId", "descuentoId");
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal");
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado");
            return View();
        }

        //GET: CONDITIONAL TABLA NUTRICIONAL

        public async Task<ActionResult> ActiveNutricionalTable(CATEGORIA_PRODUCTO GetIdCategoriaProducto)
        {
            List<CATEGORIA_PRODUCTO> li = (List<CATEGORIA_PRODUCTO>)Session["CategoriaProducto"];
            if (GetIdCategoriaProducto.categoriaProductoId == 1 || GetIdCategoriaProducto.categoriaProductoId == 1002 || GetIdCategoriaProducto.categoriaProductoId == 1003 || GetIdCategoriaProducto.categoriaProductoId == 2 || GetIdCategoriaProducto.categoriaProductoId == 3)
            {
                Console.Write("ENTRO");
            }
            else
            {
                Console.Write("ERROR");
            }
            return RedirectToAction("Create");
        }

        // POST: PRODUCTO__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "productoId,nombreProducto,imagenProducto,cantidadProducto,sucursalId,supermercadoId,precioProducto,descuentoId,precioAnterior,categoriaProductoId,descripcionProducto,tablaNutricionalProductoIMG")] PRODUCTO__ pRODUCTO__)
        {
            //GET: CONDITIONAL TABLA NUTRICIONAL
            if (pRODUCTO__.categoriaProductoId == 1 || pRODUCTO__.categoriaProductoId == 2 || pRODUCTO__.categoriaProductoId == 3 || pRODUCTO__.categoriaProductoId == 1002 || pRODUCTO__.categoriaProductoId == 1003)
            {
                Response.Write("<script>alert('ENTRO')</script>");
            }
            else
            {
                Response.Write("<script>alert('ERROR')</script>");
            }
            if (ModelState.IsValid)
            {
                db.PRODUCTO__.Add(pRODUCTO__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto", pRODUCTO__.categoriaProductoId);
            ViewBag.descuentoId = new SelectList(db.DESCUENTOS_, "descuentoId", "descuentoId", pRODUCTO__.descuentoId);
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
            ViewBag.descuentoId = new SelectList(db.DESCUENTOS_, "descuentoId", "descuentoId", pRODUCTO__.descuentoId);
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal", pRODUCTO__.sucursalId);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", pRODUCTO__.supermercadoId);
            return View(pRODUCTO__);
        }

        // POST: PRODUCTO__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "productoId,nombreProducto,imagenProducto,cantidadProducto,sucursalId,supermercadoId,precioProducto,descuentoId,precioAnterior,categoriaProductoId,descripcionProducto,tablaNutricionalProductoIMG")] PRODUCTO__ pRODUCTO__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.categoriaProductoId = new SelectList(db.CATEGORIA_PRODUCTO, "categoriaProductoId", "nombrecategoriaProducto", pRODUCTO__.categoriaProductoId);
            ViewBag.descuentoId = new SelectList(db.DESCUENTOS_, "descuentoId", "descuentoId", pRODUCTO__.descuentoId);
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
