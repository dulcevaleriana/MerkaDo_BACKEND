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
    public class COMPROBANTE_FISCALController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: COMPROBANTE_FISCAL
        public async Task<ActionResult> Index()
        {
            var cOMPROBANTE_FISCAL = db.COMPROBANTE_FISCAL.Include(c => c.CLIENTES__);
            return View(await cOMPROBANTE_FISCAL.ToListAsync());
        }

        // GET: COMPROBANTE_FISCAL/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPROBANTE_FISCAL cOMPROBANTE_FISCAL = await db.COMPROBANTE_FISCAL.FindAsync(id);
            if (cOMPROBANTE_FISCAL == null)
            {
                return HttpNotFound();
            }
            return View(cOMPROBANTE_FISCAL);
        }

        // GET: COMPROBANTE_FISCAL/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente");
            return View();
        }

        // POST: COMPROBANTE_FISCAL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "comprobanteFiscalId,ClienteId,rnc")] COMPROBANTE_FISCAL cOMPROBANTE_FISCAL)
        {
            if (ModelState.IsValid)
            {
                db.COMPROBANTE_FISCAL.Add(cOMPROBANTE_FISCAL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", cOMPROBANTE_FISCAL.ClienteId);
            return View(cOMPROBANTE_FISCAL);
        }

        // GET: COMPROBANTE_FISCAL/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPROBANTE_FISCAL cOMPROBANTE_FISCAL = await db.COMPROBANTE_FISCAL.FindAsync(id);
            if (cOMPROBANTE_FISCAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", cOMPROBANTE_FISCAL.ClienteId);
            return View(cOMPROBANTE_FISCAL);
        }

        // POST: COMPROBANTE_FISCAL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "comprobanteFiscalId,ClienteId,rnc")] COMPROBANTE_FISCAL cOMPROBANTE_FISCAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPROBANTE_FISCAL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.CLIENTES__, "ClienteId", "nombreCliente", cOMPROBANTE_FISCAL.ClienteId);
            return View(cOMPROBANTE_FISCAL);
        }

        // GET: COMPROBANTE_FISCAL/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPROBANTE_FISCAL cOMPROBANTE_FISCAL = await db.COMPROBANTE_FISCAL.FindAsync(id);
            if (cOMPROBANTE_FISCAL == null)
            {
                return HttpNotFound();
            }
            return View(cOMPROBANTE_FISCAL);
        }

        // POST: COMPROBANTE_FISCAL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            COMPROBANTE_FISCAL cOMPROBANTE_FISCAL = await db.COMPROBANTE_FISCAL.FindAsync(id);
            db.COMPROBANTE_FISCAL.Remove(cOMPROBANTE_FISCAL);
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
