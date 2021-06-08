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
    [RoutePrefix("Api/TipoMensaje")]
    public class TIPO_MENSAJE__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TIPO_MENSAJE__
        public async Task<ActionResult> Index()
        {
            return View(await db.TIPO_MENSAJE__.ToListAsync());
        }

        // GET: TIPO_MENSAJE__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_MENSAJE__ tIPO_MENSAJE__ = await db.TIPO_MENSAJE__.FindAsync(id);
            if (tIPO_MENSAJE__ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_MENSAJE__);
        }

        // GET: TIPO_MENSAJE__/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_MENSAJE__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tipoMensajeId,NombreTipoMensaje")] TIPO_MENSAJE__ tIPO_MENSAJE__)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_MENSAJE__.Add(tIPO_MENSAJE__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tIPO_MENSAJE__);
        }

        // GET: TIPO_MENSAJE__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_MENSAJE__ tIPO_MENSAJE__ = await db.TIPO_MENSAJE__.FindAsync(id);
            if (tIPO_MENSAJE__ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_MENSAJE__);
        }

        // POST: TIPO_MENSAJE__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tipoMensajeId,NombreTipoMensaje")] TIPO_MENSAJE__ tIPO_MENSAJE__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_MENSAJE__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tIPO_MENSAJE__);
        }

        // GET: TIPO_MENSAJE__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_MENSAJE__ tIPO_MENSAJE__ = await db.TIPO_MENSAJE__.FindAsync(id);
            if (tIPO_MENSAJE__ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_MENSAJE__);
        }

        // POST: TIPO_MENSAJE__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TIPO_MENSAJE__ tIPO_MENSAJE__ = await db.TIPO_MENSAJE__.FindAsync(id);
            db.TIPO_MENSAJE__.Remove(tIPO_MENSAJE__);
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
