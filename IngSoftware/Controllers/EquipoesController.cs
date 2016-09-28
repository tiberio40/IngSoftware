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
    public class EquipoesController : Controller
    {
        private IngSoftwareContext db = new IngSoftwareContext();

        // GET: Equipoes
        public ActionResult Index()
        {
            var equipoes = db.Equipoes.Include(e => e.Salon);
            return View(equipoes.ToList());
        }

        // GET: Equipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipoes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre");
            return View();
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Equipo,Nombre,Cantidad,ID_Salon")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipoes.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", equipo.ID_Salon);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", equipo.ID_Salon);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Equipo,Nombre,Cantidad,ID_Salon")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", equipo.ID_Salon);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipoes.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipoes.Find(id);
            db.Equipoes.Remove(equipo);
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
