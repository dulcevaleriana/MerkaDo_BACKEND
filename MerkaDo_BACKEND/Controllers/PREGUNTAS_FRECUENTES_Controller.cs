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
    [RoutePrefix("API/preguntasFreuentes")]
    public class PREGUNTAS_FRECUENTES_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: PREGUNTAS_FRECUENTES_
        public async Task<ActionResult> Index()
        {
            return View(await db.PREGUNTAS_FRECUENTES_.ToListAsync());
        }

        // GET: PREGUNTAS_FRECUENTES_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTAS_FRECUENTES_ pREGUNTAS_FRECUENTES_ = await db.PREGUNTAS_FRECUENTES_.FindAsync(id);
            if (pREGUNTAS_FRECUENTES_ == null)
            {
                return HttpNotFound();
            }
            return View(pREGUNTAS_FRECUENTES_);
        }

        // GET: PREGUNTAS_FRECUENTES_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PREGUNTAS_FRECUENTES_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "preguntasFrecuentesId,preguntaPreguntasFrecuentes,respuestaPreguntasFrecuentes")] PREGUNTAS_FRECUENTES_ pREGUNTAS_FRECUENTES_)
        {
            if (ModelState.IsValid)
            {
                db.PREGUNTAS_FRECUENTES_.Add(pREGUNTAS_FRECUENTES_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pREGUNTAS_FRECUENTES_);
        }

        // GET: PREGUNTAS_FRECUENTES_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTAS_FRECUENTES_ pREGUNTAS_FRECUENTES_ = await db.PREGUNTAS_FRECUENTES_.FindAsync(id);
            if (pREGUNTAS_FRECUENTES_ == null)
            {
                return HttpNotFound();
            }
            return View(pREGUNTAS_FRECUENTES_);
        }

        // POST: PREGUNTAS_FRECUENTES_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "preguntasFrecuentesId,preguntaPreguntasFrecuentes,respuestaPreguntasFrecuentes")] PREGUNTAS_FRECUENTES_ pREGUNTAS_FRECUENTES_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pREGUNTAS_FRECUENTES_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pREGUNTAS_FRECUENTES_);
        }

        // GET: PREGUNTAS_FRECUENTES_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTAS_FRECUENTES_ pREGUNTAS_FRECUENTES_ = await db.PREGUNTAS_FRECUENTES_.FindAsync(id);
            if (pREGUNTAS_FRECUENTES_ == null)
            {
                return HttpNotFound();
            }
            return View(pREGUNTAS_FRECUENTES_);
        }

        // POST: PREGUNTAS_FRECUENTES_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PREGUNTAS_FRECUENTES_ pREGUNTAS_FRECUENTES_ = await db.PREGUNTAS_FRECUENTES_.FindAsync(id);
            db.PREGUNTAS_FRECUENTES_.Remove(pREGUNTAS_FRECUENTES_);
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
