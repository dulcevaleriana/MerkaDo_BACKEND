﻿using System;
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
    [RoutePrefix("Api/Comentario")]
    public class COMENTARIOsController : Controller
    {
        private DBA_MERKAEntities db = new DBA_MERKAEntities();

        // GET: COMENTARIOs
        public async Task<ActionResult> Index()
        {
            var cOMENTARIOs = db.COMENTARIOs.Include(c => c.PRODUCTO__).Include(c => c.USUARIO__);
            return View(await cOMENTARIOs.ToListAsync());
        }

        // GET: COMENTARIOs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMENTARIO cOMENTARIO = await db.COMENTARIOs.FindAsync(id);
            if (cOMENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(cOMENTARIO);
        }

        // GET: COMENTARIOs/Create
        public ActionResult Create()
        {
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto");
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario");
            return View();
        }

        // POST: COMENTARIOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "comentarioId,usuarioId,productoId,estrellaComentario,mensajeComentario")] COMENTARIO cOMENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.COMENTARIOs.Add(cOMENTARIO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", cOMENTARIO.productoId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", cOMENTARIO.usuarioId);
            return View(cOMENTARIO);
        }

        // GET: COMENTARIOs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMENTARIO cOMENTARIO = await db.COMENTARIOs.FindAsync(id);
            if (cOMENTARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", cOMENTARIO.productoId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", cOMENTARIO.usuarioId);
            return View(cOMENTARIO);
        }

        // POST: COMENTARIOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "comentarioId,usuarioId,productoId,estrellaComentario,mensajeComentario")] COMENTARIO cOMENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMENTARIO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.productoId = new SelectList(db.PRODUCTO__, "productoId", "nombreProducto", cOMENTARIO.productoId);
            ViewBag.usuarioId = new SelectList(db.USUARIO__, "usuarioId", "nombreUsuario", cOMENTARIO.usuarioId);
            return View(cOMENTARIO);
        }

        // GET: COMENTARIOs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMENTARIO cOMENTARIO = await db.COMENTARIOs.FindAsync(id);
            if (cOMENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(cOMENTARIO);
        }

        // POST: COMENTARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            COMENTARIO cOMENTARIO = await db.COMENTARIOs.FindAsync(id);
            db.COMENTARIOs.Remove(cOMENTARIO);
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
