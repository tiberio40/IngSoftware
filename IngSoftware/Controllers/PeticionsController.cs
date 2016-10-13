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
    public class PeticionsController : Controller
    {
        private IngSoftwareContext db = new IngSoftwareContext();

        // GET: Peticions
        public ActionResult Index()
        {
            var peticions = db.Peticions.Include(p => p.Salon);
            return View(peticions.ToList());
        }

        // GET: Peticions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peticion peticion = db.Peticions.Find(id);
            if (peticion == null)
            {
                return HttpNotFound();
            }
            return View(peticion);
        }

        // GET: Peticions/Create
        public ActionResult Create()
        {
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre");
            return View();
        }

        // POST: Peticions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Peticion,Fecha_Solicitud,Tema,Cantidad_Inscritos,Estado,ID_Salon")] Peticion peticion)
        {
            if (ModelState.IsValid)
            {
                db.Peticions.Add(peticion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", peticion.ID_Salon);
            return View(peticion);
        }

        // GET: Peticions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peticion peticion = db.Peticions.Find(id);
            if (peticion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", peticion.ID_Salon);
            return View(peticion);
        }

        // POST: Peticions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Peticion,Fecha_Solicitud,Tema,Cantidad_Inscritos,Estado,ID_Salon")] Peticion peticion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peticion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", peticion.ID_Salon);
            return View(peticion);
        }

        // GET: Peticions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peticion peticion = db.Peticions.Find(id);
            if (peticion == null)
            {
                return HttpNotFound();
            }
            return View(peticion);
        }

        // POST: Peticions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peticion peticion = db.Peticions.Find(id);
            db.Peticions.Remove(peticion);
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
