﻿using System;
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
    public class SalonsController : Controller
    {
        private IngSoftwareContext db = new IngSoftwareContext();

        // GET: Salons
        public ActionResult Index()
        {
            var salons = db.Salons.Include(s => s.Edificio);
            return View(salons.ToList());
        }

        // GET: Salons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // GET: Salons/Create
        public ActionResult Create()
        {
            ViewBag.ID_Edificio = new SelectList(db.Edificios, "ID_Edificio", "Nombre");
            return View();
        }

        // POST: Salons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Salon,Nombre,Capacidad,ID_Edificio")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Salons.Add(salon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Edificio = new SelectList(db.Edificios, "ID_Edificio", "Nombre", salon.ID_Edificio);
            return View(salon);
        }

        // GET: Salons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Edificio = new SelectList(db.Edificios, "ID_Edificio", "Nombre", salon.ID_Edificio);
            return View(salon);
        }

        // POST: Salons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Salon,Nombre,Capacidad,ID_Edificio")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Edificio = new SelectList(db.Edificios, "ID_Edificio", "Nombre", salon.ID_Edificio);
            return View(salon);
        }

        // GET: Salons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // POST: Salons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salon salon = db.Salons.Find(id);
            db.Salons.Remove(salon);
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
