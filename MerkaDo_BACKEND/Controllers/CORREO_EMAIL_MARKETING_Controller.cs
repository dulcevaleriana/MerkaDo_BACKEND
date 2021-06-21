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
    [RoutePrefix("API/correoEmailMarketing")]
    public class CORREO_EMAIL_MARKETING_Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: CORREO_EMAIL_MARKETING_
        public async Task<ActionResult> Index()
        {
            return View(await db.CORREO_EMAIL_MARKETING_.ToListAsync());
        }

        // GET: CORREO_EMAIL_MARKETING_/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORREO_EMAIL_MARKETING_ cORREO_EMAIL_MARKETING_ = await db.CORREO_EMAIL_MARKETING_.FindAsync(id);
            if (cORREO_EMAIL_MARKETING_ == null)
            {
                return HttpNotFound();
            }
            return View(cORREO_EMAIL_MARKETING_);
        }

        // GET: CORREO_EMAIL_MARKETING_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CORREO_EMAIL_MARKETING_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "correoEmailMarketingId,tituloMensaje,imagenCorreoEmailMarketing,contenidoCorreoEmailMarketing,fechaCreacionCorreoEmailMarketing")] CORREO_EMAIL_MARKETING_ cORREO_EMAIL_MARKETING_)
        {
            if (ModelState.IsValid)
            {
                db.CORREO_EMAIL_MARKETING_.Add(cORREO_EMAIL_MARKETING_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cORREO_EMAIL_MARKETING_);
        }

        // GET: CORREO_EMAIL_MARKETING_/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORREO_EMAIL_MARKETING_ cORREO_EMAIL_MARKETING_ = await db.CORREO_EMAIL_MARKETING_.FindAsync(id);
            if (cORREO_EMAIL_MARKETING_ == null)
            {
                return HttpNotFound();
            }
            return View(cORREO_EMAIL_MARKETING_);
        }

        // POST: CORREO_EMAIL_MARKETING_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "correoEmailMarketingId,tituloMensaje,imagenCorreoEmailMarketing,contenidoCorreoEmailMarketing,fechaCreacionCorreoEmailMarketing")] CORREO_EMAIL_MARKETING_ cORREO_EMAIL_MARKETING_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cORREO_EMAIL_MARKETING_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cORREO_EMAIL_MARKETING_);
        }

        // GET: CORREO_EMAIL_MARKETING_/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORREO_EMAIL_MARKETING_ cORREO_EMAIL_MARKETING_ = await db.CORREO_EMAIL_MARKETING_.FindAsync(id);
            if (cORREO_EMAIL_MARKETING_ == null)
            {
                return HttpNotFound();
            }
            return View(cORREO_EMAIL_MARKETING_);
        }

        // POST: CORREO_EMAIL_MARKETING_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CORREO_EMAIL_MARKETING_ cORREO_EMAIL_MARKETING_ = await db.CORREO_EMAIL_MARKETING_.FindAsync(id);
            db.CORREO_EMAIL_MARKETING_.Remove(cORREO_EMAIL_MARKETING_);
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
