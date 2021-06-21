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
    [RoutePrefix("API/supermercado")]
    public class SUPERMERCADO_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: SUPERMERCADO_
        public async Task<ActionResult> Index()
        {
            return View(await db.SUPERMERCADO_.ToListAsync());
        }

        // GET: SUPERMERCADO_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPERMERCADO_ sUPERMERCADO_ = await db.SUPERMERCADO_.FindAsync(id);
            if (sUPERMERCADO_ == null)
            {
                return HttpNotFound();
            }
            return View(sUPERMERCADO_);
        }

        // GET: SUPERMERCADO_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUPERMERCADO_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "supermercadoId,nombreSupermercado,direccionSupermercado,horarioApertura,horarioCierre,diaFeriado,horarioAperturaSabado,horarioCierreSabado,horarioAperturaDomingo,horarioCierreDomingo")] SUPERMERCADO_ sUPERMERCADO_)
        {
            if (ModelState.IsValid)
            {
                db.SUPERMERCADO_.Add(sUPERMERCADO_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sUPERMERCADO_);
        }

        // GET: SUPERMERCADO_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPERMERCADO_ sUPERMERCADO_ = await db.SUPERMERCADO_.FindAsync(id);
            if (sUPERMERCADO_ == null)
            {
                return HttpNotFound();
            }
            return View(sUPERMERCADO_);
        }

        // POST: SUPERMERCADO_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "supermercadoId,nombreSupermercado,direccionSupermercado,horarioApertura,horarioCierre,diaFeriado,horarioAperturaSabado,horarioCierreSabado,horarioAperturaDomingo,horarioCierreDomingo")] SUPERMERCADO_ sUPERMERCADO_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUPERMERCADO_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sUPERMERCADO_);
        }

        // GET: SUPERMERCADO_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUPERMERCADO_ sUPERMERCADO_ = await db.SUPERMERCADO_.FindAsync(id);
            if (sUPERMERCADO_ == null)
            {
                return HttpNotFound();
            }
            return View(sUPERMERCADO_);
        }

        // POST: SUPERMERCADO_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SUPERMERCADO_ sUPERMERCADO_ = await db.SUPERMERCADO_.FindAsync(id);
            db.SUPERMERCADO_.Remove(sUPERMERCADO_);
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
