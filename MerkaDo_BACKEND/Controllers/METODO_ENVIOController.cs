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
    public class METODO_ENVIOController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: METODO_ENVIO
        public async Task<ActionResult> Index()
        {
            return View(await db.METODO_ENVIO.ToListAsync());
        }

        // GET: METODO_ENVIO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METODO_ENVIO mETODO_ENVIO = await db.METODO_ENVIO.FindAsync(id);
            if (mETODO_ENVIO == null)
            {
                return HttpNotFound();
            }
            return View(mETODO_ENVIO);
        }

        // GET: METODO_ENVIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: METODO_ENVIO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "metodoEnvioId,nombreMetodoEnvio,descripcionMetodoEnvio")] METODO_ENVIO mETODO_ENVIO)
        {
            if (ModelState.IsValid)
            {
                db.METODO_ENVIO.Add(mETODO_ENVIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mETODO_ENVIO);
        }

        // GET: METODO_ENVIO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METODO_ENVIO mETODO_ENVIO = await db.METODO_ENVIO.FindAsync(id);
            if (mETODO_ENVIO == null)
            {
                return HttpNotFound();
            }
            return View(mETODO_ENVIO);
        }

        // POST: METODO_ENVIO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "metodoEnvioId,nombreMetodoEnvio,descripcionMetodoEnvio")] METODO_ENVIO mETODO_ENVIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mETODO_ENVIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mETODO_ENVIO);
        }

        // GET: METODO_ENVIO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METODO_ENVIO mETODO_ENVIO = await db.METODO_ENVIO.FindAsync(id);
            if (mETODO_ENVIO == null)
            {
                return HttpNotFound();
            }
            return View(mETODO_ENVIO);
        }

        // POST: METODO_ENVIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            METODO_ENVIO mETODO_ENVIO = await db.METODO_ENVIO.FindAsync(id);
            db.METODO_ENVIO.Remove(mETODO_ENVIO);
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
