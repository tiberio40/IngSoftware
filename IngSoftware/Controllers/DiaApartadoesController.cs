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
    public class DiaApartadoesController : Controller
    {
        private IngSoftwareContext db = new IngSoftwareContext();

        // GET: DiaApartadoes
        public ActionResult Index()
        {
            var diaApartadoes = db.DiaApartadoes.Include(d => d.Peticion);
            return View(diaApartadoes.ToList());
        }

        // GET: DiaApartadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaApartado diaApartado = db.DiaApartadoes.Find(id);
            if (diaApartado == null)
            {
                return HttpNotFound();
            }
            return View(diaApartado);
        }

        // GET: DiaApartadoes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Peticion = new SelectList(db.Peticions, "ID_Peticion", "Tema");
            return View();
        }

        // POST: DiaApartadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DiaApartado,Fecha_Apartado,Hora_Comienzo,Hora_Terminado,ID_Peticion")] DiaApartado diaApartado)
        {
            if (ModelState.IsValid)
            {
                db.DiaApartadoes.Add(diaApartado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Peticion = new SelectList(db.Peticions, "ID_Peticion", "Tema", diaApartado.ID_Peticion);
            return View(diaApartado);
        }

        // GET: DiaApartadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaApartado diaApartado = db.DiaApartadoes.Find(id);
            if (diaApartado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Peticion = new SelectList(db.Peticions, "ID_Peticion", "Tema", diaApartado.ID_Peticion);
            return View(diaApartado);
        }

        // POST: DiaApartadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DiaApartado,Fecha_Apartado,Hora_Comienzo,Hora_Terminado,ID_Peticion")] DiaApartado diaApartado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diaApartado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Peticion = new SelectList(db.Peticions, "ID_Peticion", "Tema", diaApartado.ID_Peticion);
            return View(diaApartado);
        }

        // GET: DiaApartadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaApartado diaApartado = db.DiaApartadoes.Find(id);
            if (diaApartado == null)
            {
                return HttpNotFound();
            }
            return View(diaApartado);
        }

        // POST: DiaApartadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiaApartado diaApartado = db.DiaApartadoes.Find(id);
            db.DiaApartadoes.Remove(diaApartado);
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
