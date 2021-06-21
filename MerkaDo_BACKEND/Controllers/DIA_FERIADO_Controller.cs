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
    [RoutePrefix("API/diaFeriado")]
    public class DIA_FERIADO_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: DIA_FERIADO_
        public async Task<ActionResult> Index()
        {
            return View(await db.DIA_FERIADO_.ToListAsync());
        }

        // GET: DIA_FERIADO_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIA_FERIADO_ dIA_FERIADO_ = await db.DIA_FERIADO_.FindAsync(id);
            if (dIA_FERIADO_ == null)
            {
                return HttpNotFound();
            }
            return View(dIA_FERIADO_);
        }

        // GET: DIA_FERIADO_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DIA_FERIADO_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "diaFeriadoId,nombreDiaFeriado,fechaDiaFeriado,seLabora,horarioAperturaDiaFeriado,horarioCierreDiaFeriad")] DIA_FERIADO_ dIA_FERIADO_)
        {
            if (ModelState.IsValid)
            {
                db.DIA_FERIADO_.Add(dIA_FERIADO_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dIA_FERIADO_);
        }

        // GET: DIA_FERIADO_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIA_FERIADO_ dIA_FERIADO_ = await db.DIA_FERIADO_.FindAsync(id);
            if (dIA_FERIADO_ == null)
            {
                return HttpNotFound();
            }
            return View(dIA_FERIADO_);
        }

        // POST: DIA_FERIADO_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "diaFeriadoId,nombreDiaFeriado,fechaDiaFeriado,seLabora,horarioAperturaDiaFeriado,horarioCierreDiaFeriad")] DIA_FERIADO_ dIA_FERIADO_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIA_FERIADO_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dIA_FERIADO_);
        }

        // GET: DIA_FERIADO_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIA_FERIADO_ dIA_FERIADO_ = await db.DIA_FERIADO_.FindAsync(id);
            if (dIA_FERIADO_ == null)
            {
                return HttpNotFound();
            }
            return View(dIA_FERIADO_);
        }

        // POST: DIA_FERIADO_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DIA_FERIADO_ dIA_FERIADO_ = await db.DIA_FERIADO_.FindAsync(id);
            db.DIA_FERIADO_.Remove(dIA_FERIADO_);
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
