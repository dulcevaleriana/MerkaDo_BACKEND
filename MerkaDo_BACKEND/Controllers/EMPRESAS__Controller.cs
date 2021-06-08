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
    [RoutePrefix("Api/Empresa")]
    public class EMPRESAS__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: EMPRESAS__
        public async Task<ActionResult> Index()
        {
            return View(await db.EMPRESAS__.ToListAsync());
        }

        // GET: EMPRESAS__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESAS__ eMPRESAS__ = await db.EMPRESAS__.FindAsync(id);
            if (eMPRESAS__ == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESAS__);
        }

        // GET: EMPRESAS__/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPRESAS__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "usuarioId,razonSocialEmpresa,telefonoEmpresa,imagenEmpresa,codigoPostalEmpresa,RNC,correoEmpresa,contraseñaEmpresa,estado,emailMarketing")] EMPRESAS__ eMPRESAS__)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESAS__.Add(eMPRESAS__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eMPRESAS__);
        }

        // GET: EMPRESAS__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESAS__ eMPRESAS__ = await db.EMPRESAS__.FindAsync(id);
            if (eMPRESAS__ == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESAS__);
        }

        // POST: EMPRESAS__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "usuarioId,razonSocialEmpresa,telefonoEmpresa,imagenEmpresa,codigoPostalEmpresa,RNC,correoEmpresa,contraseñaEmpresa,estado,emailMarketing")] EMPRESAS__ eMPRESAS__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPRESAS__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eMPRESAS__);
        }

        // GET: EMPRESAS__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESAS__ eMPRESAS__ = await db.EMPRESAS__.FindAsync(id);
            if (eMPRESAS__ == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESAS__);
        }

        // POST: EMPRESAS__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EMPRESAS__ eMPRESAS__ = await db.EMPRESAS__.FindAsync(id);
            db.EMPRESAS__.Remove(eMPRESAS__);
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
