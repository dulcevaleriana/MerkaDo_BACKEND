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
    [RoutePrefix("API/salaUsuario")]
    public class SALA_USUARIO__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: SALA_USUARIO__
        public async Task<ActionResult> Index()
        {
            var sALA_USUARIO__ = db.SALA_USUARIO__.Include(s => s.CLIENTES__).Include(s => s.SALA__).Include(s => s.USUARIO__);
            return View(await sALA_USUARIO__.ToListAsync());
        }

        // GET: SALA_USUARIO__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA_USUARIO__ sALA_USUARIO__ = await db.SALA_USUARIO__.FindAsync(id);
            if (sALA_USUARIO__ == null)
            {
                return HttpNotFound();
            }
            return View(sALA_USUARIO__);
        }

        // GET: SALA_USUARIO__/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            ViewBag.salaId = new SelectList(db.SALA__, "salaId", "salaId");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: SALA_USUARIO__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "salaUsuarioId,salaId,usuarioId,ClienteId")] SALA_USUARIO__ sALA_USUARIO__)
        {
            if (ModelState.IsValid)
            {
                db.SALA_USUARIO__.Add(sALA_USUARIO__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", sALA_USUARIO__.ClienteId);
            ViewBag.salaId = new SelectList(db.SALA__, "salaId", "salaId", sALA_USUARIO__.salaId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", sALA_USUARIO__.usuarioId);
            return View(sALA_USUARIO__);
        }

        // GET: SALA_USUARIO__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA_USUARIO__ sALA_USUARIO__ = await db.SALA_USUARIO__.FindAsync(id);
            if (sALA_USUARIO__ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", sALA_USUARIO__.ClienteId);
            ViewBag.salaId = new SelectList(db.SALA__, "salaId", "salaId", sALA_USUARIO__.salaId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", sALA_USUARIO__.usuarioId);
            return View(sALA_USUARIO__);
        }

        // POST: SALA_USUARIO__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "salaUsuarioId,salaId,usuarioId,ClienteId")] SALA_USUARIO__ sALA_USUARIO__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALA_USUARIO__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", sALA_USUARIO__.ClienteId);
            ViewBag.salaId = new SelectList(db.SALA__, "salaId", "salaId", sALA_USUARIO__.salaId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", sALA_USUARIO__.usuarioId);
            return View(sALA_USUARIO__);
        }

        // GET: SALA_USUARIO__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA_USUARIO__ sALA_USUARIO__ = await db.SALA_USUARIO__.FindAsync(id);
            if (sALA_USUARIO__ == null)
            {
                return HttpNotFound();
            }
            return View(sALA_USUARIO__);
        }

        // POST: SALA_USUARIO__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SALA_USUARIO__ sALA_USUARIO__ = await db.SALA_USUARIO__.FindAsync(id);
            db.SALA_USUARIO__.Remove(sALA_USUARIO__);
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
