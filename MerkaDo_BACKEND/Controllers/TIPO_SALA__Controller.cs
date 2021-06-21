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
    public class TIPO_SALA__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TIPO_SALA__
        public async Task<ActionResult> Index()
        {
            return View(await db.TIPO_SALA__.ToListAsync());
        }

        // GET: TIPO_SALA__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_SALA__ tIPO_SALA__ = await db.TIPO_SALA__.FindAsync(id);
            if (tIPO_SALA__ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_SALA__);
        }

        // GET: TIPO_SALA__/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_SALA__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tipoSalaId,nombreSala")] TIPO_SALA__ tIPO_SALA__)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_SALA__.Add(tIPO_SALA__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tIPO_SALA__);
        }

        // GET: TIPO_SALA__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_SALA__ tIPO_SALA__ = await db.TIPO_SALA__.FindAsync(id);
            if (tIPO_SALA__ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_SALA__);
        }

        // POST: TIPO_SALA__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tipoSalaId,nombreSala")] TIPO_SALA__ tIPO_SALA__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_SALA__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tIPO_SALA__);
        }

        // GET: TIPO_SALA__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_SALA__ tIPO_SALA__ = await db.TIPO_SALA__.FindAsync(id);
            if (tIPO_SALA__ == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_SALA__);
        }

        // POST: TIPO_SALA__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TIPO_SALA__ tIPO_SALA__ = await db.TIPO_SALA__.FindAsync(id);
            db.TIPO_SALA__.Remove(tIPO_SALA__);
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
