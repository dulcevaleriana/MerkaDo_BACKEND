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
    [RoutePrefix("Api/TipoDocumento")]
    public class TIPO_DOCUMENTOController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: TIPO_DOCUMENTO
        public async Task<ActionResult> Index()
        {
            return View(await db.TIPO_DOCUMENTO.ToListAsync());
        }

        // GET: TIPO_DOCUMENTO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTO tIPO_DOCUMENTO = await db.TIPO_DOCUMENTO.FindAsync(id);
            if (tIPO_DOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTO);
        }

        // GET: TIPO_DOCUMENTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_DOCUMENTO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "tipoDocumentoId,nombreTipoDocumento")] TIPO_DOCUMENTO tIPO_DOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_DOCUMENTO.Add(tIPO_DOCUMENTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tIPO_DOCUMENTO);
        }

        // GET: TIPO_DOCUMENTO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTO tIPO_DOCUMENTO = await db.TIPO_DOCUMENTO.FindAsync(id);
            if (tIPO_DOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTO);
        }

        // POST: TIPO_DOCUMENTO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "tipoDocumentoId,nombreTipoDocumento")] TIPO_DOCUMENTO tIPO_DOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_DOCUMENTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tIPO_DOCUMENTO);
        }

        // GET: TIPO_DOCUMENTO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTO tIPO_DOCUMENTO = await db.TIPO_DOCUMENTO.FindAsync(id);
            if (tIPO_DOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTO);
        }

        // POST: TIPO_DOCUMENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TIPO_DOCUMENTO tIPO_DOCUMENTO = await db.TIPO_DOCUMENTO.FindAsync(id);
            db.TIPO_DOCUMENTO.Remove(tIPO_DOCUMENTO);
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
