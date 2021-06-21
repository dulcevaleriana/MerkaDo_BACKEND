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
    public class SOBRE_NOSOTROS_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: SOBRE_NOSOTROS_
        public async Task<ActionResult> Index()
        {
            return View(await db.SOBRE_NOSOTROS_.ToListAsync());
        }

        // GET: SOBRE_NOSOTROS_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOBRE_NOSOTROS_ sOBRE_NOSOTROS_ = await db.SOBRE_NOSOTROS_.FindAsync(id);
            if (sOBRE_NOSOTROS_ == null)
            {
                return HttpNotFound();
            }
            return View(sOBRE_NOSOTROS_);
        }

        // GET: SOBRE_NOSOTROS_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SOBRE_NOSOTROS_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "sobreNosotrosId,quienesSomosSobreNosotros,misionSobreNosotros,visionSobreNosotros,valoresSobreNosotros")] SOBRE_NOSOTROS_ sOBRE_NOSOTROS_)
        {
            if (ModelState.IsValid)
            {
                db.SOBRE_NOSOTROS_.Add(sOBRE_NOSOTROS_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sOBRE_NOSOTROS_);
        }

        // GET: SOBRE_NOSOTROS_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOBRE_NOSOTROS_ sOBRE_NOSOTROS_ = await db.SOBRE_NOSOTROS_.FindAsync(id);
            if (sOBRE_NOSOTROS_ == null)
            {
                return HttpNotFound();
            }
            return View(sOBRE_NOSOTROS_);
        }

        // POST: SOBRE_NOSOTROS_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "sobreNosotrosId,quienesSomosSobreNosotros,misionSobreNosotros,visionSobreNosotros,valoresSobreNosotros")] SOBRE_NOSOTROS_ sOBRE_NOSOTROS_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOBRE_NOSOTROS_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sOBRE_NOSOTROS_);
        }

        // GET: SOBRE_NOSOTROS_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOBRE_NOSOTROS_ sOBRE_NOSOTROS_ = await db.SOBRE_NOSOTROS_.FindAsync(id);
            if (sOBRE_NOSOTROS_ == null)
            {
                return HttpNotFound();
            }
            return View(sOBRE_NOSOTROS_);
        }

        // POST: SOBRE_NOSOTROS_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SOBRE_NOSOTROS_ sOBRE_NOSOTROS_ = await db.SOBRE_NOSOTROS_.FindAsync(id);
            db.SOBRE_NOSOTROS_.Remove(sOBRE_NOSOTROS_);
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
