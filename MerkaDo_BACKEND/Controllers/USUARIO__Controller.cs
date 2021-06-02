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
    [RoutePrefix("Api/Usuario")]
    public class USUARIO__Controller : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: USUARIO__
        public async Task<ActionResult> Index()
        {
            var uSUARIO__ = db.USUARIO__.Include(u => u.GENERO).Include(u => u.ROL_USUARIO).Include(u => u.SUCURSAL_1);
            return View(await uSUARIO__.ToListAsync());
        }

        // GET: USUARIO__/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO__ uSUARIO__ = await db.USUARIO__.FindAsync(id);
            if (uSUARIO__ == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO__);
        }

        // GET: USUARIO__/Create
        public ActionResult Create()
        {
            ViewBag.generoId = new SelectList(db.GENEROes, "generoId", "nombreGenero");
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol");
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal");
            return View();
        }

        // POST: USUARIO__/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "usuarioId,nombreUsuario,apellidoUsuario,imagenUsuario,cedulaUsuario,generoId,correoCorporativoUsuario,TtelefonoUsuario,sucursalId,rolId")] USUARIO__ uSUARIO__)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO__.Add(uSUARIO__);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.generoId = new SelectList(db.GENEROes, "generoId", "nombreGenero", uSUARIO__.generoId);
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", uSUARIO__.rolId);
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal", uSUARIO__.sucursalId);
            return View(uSUARIO__);
        }

        // GET: USUARIO__/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO__ uSUARIO__ = await db.USUARIO__.FindAsync(id);
            if (uSUARIO__ == null)
            {
                return HttpNotFound();
            }
            ViewBag.generoId = new SelectList(db.GENEROes, "generoId", "nombreGenero", uSUARIO__.generoId);
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", uSUARIO__.rolId);
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal", uSUARIO__.sucursalId);
            return View(uSUARIO__);
        }

        // POST: USUARIO__/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "usuarioId,nombreUsuario,apellidoUsuario,imagenUsuario,cedulaUsuario,generoId,correoCorporativoUsuario,TtelefonoUsuario,sucursalId,rolId")] USUARIO__ uSUARIO__)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO__).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.generoId = new SelectList(db.GENEROes, "generoId", "nombreGenero", uSUARIO__.generoId);
            ViewBag.rolId = new SelectList(db.ROL_USUARIO, "rolId", "nombreRol", uSUARIO__.rolId);
            ViewBag.sucursalId = new SelectList(db.SUCURSAL_, "sucursalId", "nombreSucursal", uSUARIO__.sucursalId);
            return View(uSUARIO__);
        }

        // GET: USUARIO__/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO__ uSUARIO__ = await db.USUARIO__.FindAsync(id);
            if (uSUARIO__ == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO__);
        }

        // POST: USUARIO__/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            USUARIO__ uSUARIO__ = await db.USUARIO__.FindAsync(id);
            db.USUARIO__.Remove(uSUARIO__);
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
