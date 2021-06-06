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
    [RoutePrefix("Api/Cliente")]
    public class CLIENTES__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: CLIENTES__
        public async Task<ActionResult> Index()
        {
            var cLIENTES__ = db.CLIENTES__.Include(c => c.GENERO).Include(c => c.TIPO_DOCUMENTO);
            return View(await cLIENTES__.ToListAsync());
        }

        // GET: CLIENTES__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES__ cLIENTES__ = await db.CLIENTES__.FindAsync(id);
            if (cLIENTES__ == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTES__);
        }

        // GET: CLIENTES__/Create
        public ActionResult Create()
        {
            ViewBag.generoId = new SelectList(db.GENEROes, "generoId", "nombreGenero");
            ViewBag.tipoDocumentoId = new SelectList(db.TIPO_DOCUMENTO, "tipoDocumentoId", "nombreTipoDocumento");
            return View();
        }

        // POST: CLIENTES__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UsuarioId,nombreCliente,apellidoCliente,imagenCliente,teléfonoCliente,códigoPostalCliente,fechaNacimientoCliente,generoId,tipoDocumentoId,numeroDocumentoCliente,correoCliente,contraseñaCliente,estado,emailMarketing")] CLIENTES__ cLIENTES__)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTES__.Add(cLIENTES__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.generoId = new SelectList(db.GENEROes, "generoId", "nombreGenero", cLIENTES__.generoId);
            ViewBag.tipoDocumentoId = new SelectList(db.TIPO_DOCUMENTO, "tipoDocumentoId", "nombreTipoDocumento", cLIENTES__.tipoDocumentoId);
            return View(cLIENTES__);
        }

        // GET: CLIENTES__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES__ cLIENTES__ = await db.CLIENTES__.FindAsync(id);
            if (cLIENTES__ == null)
            {
                return HttpNotFound();
            }
            ViewBag.generoId = new SelectList(db.GENEROes, "generoId", "nombreGenero", cLIENTES__.generoId);
            ViewBag.tipoDocumentoId = new SelectList(db.TIPO_DOCUMENTO, "tipoDocumentoId", "nombreTipoDocumento", cLIENTES__.tipoDocumentoId);
            return View(cLIENTES__);
        }

        // POST: CLIENTES__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UsuarioId,nombreCliente,apellidoCliente,imagenCliente,teléfonoCliente,códigoPostalCliente,fechaNacimientoCliente,generoId,tipoDocumentoId,numeroDocumentoCliente,correoCliente,contraseñaCliente,estado,emailMarketing")] CLIENTES__ cLIENTES__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTES__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.generoId = new SelectList(db.GENEROes, "generoId", "nombreGenero", cLIENTES__.generoId);
            ViewBag.tipoDocumentoId = new SelectList(db.TIPO_DOCUMENTO, "tipoDocumentoId", "nombreTipoDocumento", cLIENTES__.tipoDocumentoId);
            return View(cLIENTES__);
        }

        // GET: CLIENTES__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES__ cLIENTES__ = await db.CLIENTES__.FindAsync(id);
            if (cLIENTES__ == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTES__);
        }

        // POST: CLIENTES__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CLIENTES__ cLIENTES__ = await db.CLIENTES__.FindAsync(id);
            db.CLIENTES__.Remove(cLIENTES__);
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
