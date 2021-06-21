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
    public class SALA__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: SALA__
        public async Task<ActionResult> Index()
        {
            var sALA__ = db.SALA__.Include(s => s.TIPO_SALA__);
            return View(await sALA__.ToListAsync());
        }

        // GET: SALA__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA__ sALA__ = await db.SALA__.FindAsync(id);
            if (sALA__ == null)
            {
                return HttpNotFound();
            }
            return View(sALA__);
        }

        // GET: SALA__/Create
        public ActionResult Create()
        {
            ViewBag.tipoSalaId = new SelectList(db.TIPO_SALA__, "tipoSalaId", "nombreSala");
            return View();
        }

        // POST: SALA__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "salaId,tipoSalaId,fecha")] SALA__ sALA__)
        {
            if (ModelState.IsValid)
            {
                db.SALA__.Add(sALA__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.tipoSalaId = new SelectList(db.TIPO_SALA__, "tipoSalaId", "nombreSala", sALA__.tipoSalaId);
            return View(sALA__);
        }

        // GET: SALA__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA__ sALA__ = await db.SALA__.FindAsync(id);
            if (sALA__ == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoSalaId = new SelectList(db.TIPO_SALA__, "tipoSalaId", "nombreSala", sALA__.tipoSalaId);
            return View(sALA__);
        }

        // POST: SALA__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "salaId,tipoSalaId,fecha")] SALA__ sALA__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALA__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.tipoSalaId = new SelectList(db.TIPO_SALA__, "tipoSalaId", "nombreSala", sALA__.tipoSalaId);
            return View(sALA__);
        }

        // GET: SALA__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA__ sALA__ = await db.SALA__.FindAsync(id);
            if (sALA__ == null)
            {
                return HttpNotFound();
            }
            return View(sALA__);
        }

        // POST: SALA__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SALA__ sALA__ = await db.SALA__.FindAsync(id);
            db.SALA__.Remove(sALA__);
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
