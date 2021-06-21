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
    [RoutePrefix("API/rolUsuario")]
    public class ROL_USUARIOController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: ROL_USUARIO
        public async Task<ActionResult> Index()
        {
            return View(await db.ROL_USUARIO.ToListAsync());
        }

        // GET: ROL_USUARIO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_USUARIO rOL_USUARIO = await db.ROL_USUARIO.FindAsync(id);
            if (rOL_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(rOL_USUARIO);
        }

        // GET: ROL_USUARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ROL_USUARIO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "rolId,nombreRol")] ROL_USUARIO rOL_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.ROL_USUARIO.Add(rOL_USUARIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rOL_USUARIO);
        }

        // GET: ROL_USUARIO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_USUARIO rOL_USUARIO = await db.ROL_USUARIO.FindAsync(id);
            if (rOL_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(rOL_USUARIO);
        }

        // POST: ROL_USUARIO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "rolId,nombreRol")] ROL_USUARIO rOL_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOL_USUARIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rOL_USUARIO);
        }

        // GET: ROL_USUARIO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_USUARIO rOL_USUARIO = await db.ROL_USUARIO.FindAsync(id);
            if (rOL_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(rOL_USUARIO);
        }

        // POST: ROL_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ROL_USUARIO rOL_USUARIO = await db.ROL_USUARIO.FindAsync(id);
            db.ROL_USUARIO.Remove(rOL_USUARIO);
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
