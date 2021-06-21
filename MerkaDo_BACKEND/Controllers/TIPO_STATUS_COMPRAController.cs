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
    [RoutePrefix("API/tipoStatusCompra")]
    public class TIPO_STATUS_COMPRAController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TIPO_STATUS_COMPRA
        public async Task<ActionResult> Index()
        {
            return View(await db.TIPO_STATUS_COMPRA.ToListAsync());
        }

        // GET: TIPO_STATUS_COMPRA/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_STATUS_COMPRA tIPO_STATUS_COMPRA = await db.TIPO_STATUS_COMPRA.FindAsync(id);
            if (tIPO_STATUS_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_STATUS_COMPRA);
        }

        // GET: TIPO_STATUS_COMPRA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_STATUS_COMPRA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "statusTipoCompraId,nombreStatusTipoCompra")] TIPO_STATUS_COMPRA tIPO_STATUS_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_STATUS_COMPRA.Add(tIPO_STATUS_COMPRA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tIPO_STATUS_COMPRA);
        }

        // GET: TIPO_STATUS_COMPRA/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_STATUS_COMPRA tIPO_STATUS_COMPRA = await db.TIPO_STATUS_COMPRA.FindAsync(id);
            if (tIPO_STATUS_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_STATUS_COMPRA);
        }

        // POST: TIPO_STATUS_COMPRA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "statusTipoCompraId,nombreStatusTipoCompra")] TIPO_STATUS_COMPRA tIPO_STATUS_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_STATUS_COMPRA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tIPO_STATUS_COMPRA);
        }

        // GET: TIPO_STATUS_COMPRA/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_STATUS_COMPRA tIPO_STATUS_COMPRA = await db.TIPO_STATUS_COMPRA.FindAsync(id);
            if (tIPO_STATUS_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_STATUS_COMPRA);
        }

        // POST: TIPO_STATUS_COMPRA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TIPO_STATUS_COMPRA tIPO_STATUS_COMPRA = await db.TIPO_STATUS_COMPRA.FindAsync(id);
            db.TIPO_STATUS_COMPRA.Remove(tIPO_STATUS_COMPRA);
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
