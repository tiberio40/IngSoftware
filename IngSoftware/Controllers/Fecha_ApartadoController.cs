using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngSoftware.Models;

namespace IngSoftware.Controllers
{
    public class Fecha_ApartadoController : Controller
    {
        private IngSoftwareContext db = new IngSoftwareContext();

        // GET: Fecha_Apartado
        public ActionResult Index()
        {
            var fecha_Apartado = db.Fecha_Apartado.Include(f => f.Profesor).Include(f => f.Salon);
            return View(fecha_Apartado.ToList());
        }

        // GET: Fecha_Apartado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha_Apartado fecha_Apartado = db.Fecha_Apartado.Find(id);
            if (fecha_Apartado == null)
            {
                return HttpNotFound();
            }
            return View(fecha_Apartado);
        }

        // GET: Fecha_Apartado/Create
        public ActionResult Create()
        {
            ViewBag.ID_Profesor = new SelectList(db.Profesors, "ID_Profesor", "Nombre");
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre");
            return View();
        }

        // POST: Fecha_Apartado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Fecha_Apartado,Dia,Hora,ID_Salon,ID_Profesor")] Fecha_Apartado fecha_Apartado)
        {
            if (ModelState.IsValid)
            {
                db.Fecha_Apartado.Add(fecha_Apartado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Profesor = new SelectList(db.Profesors, "ID_Profesor", "Nombre", fecha_Apartado.ID_Profesor);
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", fecha_Apartado.ID_Salon);
            return View(fecha_Apartado);
        }

        // GET: Fecha_Apartado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha_Apartado fecha_Apartado = db.Fecha_Apartado.Find(id);
            if (fecha_Apartado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Profesor = new SelectList(db.Profesors, "ID_Profesor", "Nombre", fecha_Apartado.ID_Profesor);
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", fecha_Apartado.ID_Salon);
            return View(fecha_Apartado);
        }

        // POST: Fecha_Apartado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Fecha_Apartado,Dia,Hora,ID_Salon,ID_Profesor")] Fecha_Apartado fecha_Apartado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fecha_Apartado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Profesor = new SelectList(db.Profesors, "ID_Profesor", "Nombre", fecha_Apartado.ID_Profesor);
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", fecha_Apartado.ID_Salon);
            return View(fecha_Apartado);
        }

        // GET: Fecha_Apartado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fecha_Apartado fecha_Apartado = db.Fecha_Apartado.Find(id);
            if (fecha_Apartado == null)
            {
                return HttpNotFound();
            }
            return View(fecha_Apartado);
        }

        // POST: Fecha_Apartado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fecha_Apartado fecha_Apartado = db.Fecha_Apartado.Find(id);
            db.Fecha_Apartado.Remove(fecha_Apartado);
            db.SaveChanges();
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
