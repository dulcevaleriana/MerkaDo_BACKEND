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
    [RoutePrefix("Api/Sucursal")]
    public class SUCURSAL_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: SUCURSAL_
        public async Task<ActionResult> Index()
        {
            var sUCURSAL_ = db.SUCURSAL_.Include(s => s.USUARIO__).Include(s => s.SUPERMERCADO_);
            return View(await sUCURSAL_.ToListAsync());
        }

        // GET: SUCURSAL_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL_ sUCURSAL_ = await db.SUCURSAL_.FindAsync(id);
            if (sUCURSAL_ == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSAL_);
        }

        // GET: SUCURSAL_/Create
        public ActionResult Create()
        {
            ViewBag.encargadoSucursal = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado");
            return View();
        }

        // POST: SUCURSAL_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "sucursalId,nombreSucursal,direccionSucursal,encargadoSucursal,supermercadoId,horarioApertura,horarioCierre,diaFeriado,horarioAperturaSabado,horarioCierreSabado,horarioAperturaDomingo,horarioCierreDomingo")] SUCURSAL_ sUCURSAL_)
        {
            if (ModelState.IsValid)
            {
                db.SUCURSAL_.Add(sUCURSAL_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.encargadoSucursal = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", sUCURSAL_.encargadoSucursal);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", sUCURSAL_.supermercadoId);
            return View(sUCURSAL_);
        }

        // GET: SUCURSAL_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL_ sUCURSAL_ = await db.SUCURSAL_.FindAsync(id);
            if (sUCURSAL_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.encargadoSucursal = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", sUCURSAL_.encargadoSucursal);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", sUCURSAL_.supermercadoId);
            return View(sUCURSAL_);
        }

        // POST: SUCURSAL_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "sucursalId,nombreSucursal,direccionSucursal,encargadoSucursal,supermercadoId,horarioApertura,horarioCierre,diaFeriado,horarioAperturaSabado,horarioCierreSabado,horarioAperturaDomingo,horarioCierreDomingo")] SUCURSAL_ sUCURSAL_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUCURSAL_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.encargadoSucursal = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", sUCURSAL_.encargadoSucursal);
            ViewBag.supermercadoId = new SelectList(db.SUPERMERCADO_, "supermercadoId", "nombreSupermercado", sUCURSAL_.supermercadoId);
            return View(sUCURSAL_);
        }

        // GET: SUCURSAL_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUCURSAL_ sUCURSAL_ = await db.SUCURSAL_.FindAsync(id);
            if (sUCURSAL_ == null)
            {
                return HttpNotFound();
            }
            return View(sUCURSAL_);
        }

        // POST: SUCURSAL_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SUCURSAL_ sUCURSAL_ = await db.SUCURSAL_.FindAsync(id);
            db.SUCURSAL_.Remove(sUCURSAL_);
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
