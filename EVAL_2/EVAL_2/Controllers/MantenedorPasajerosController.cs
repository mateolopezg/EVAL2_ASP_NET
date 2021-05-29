using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EVAL_2.Models;

namespace EVAL_2.Controllers
{
    public class MantenedorPasajerosController : Controller
    {
        private bd_vuelaEntities db = new bd_vuelaEntities();

        // GET: MantenedorPasajeros
        public ActionResult Index()
        {
            var pasajero = db.pasajero.Include(p => p.pasajes).Include(p => p.vuelo1);
            return View(pasajero.ToList());
        }

        // GET: MantenedorPasajeros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasajero pasajero = db.pasajero.Find(id);
            if (pasajero == null)
            {
                return HttpNotFound();
            }
            return View(pasajero);
        }

        // GET: MantenedorPasajeros/Create
        public ActionResult Create()
        {
            ViewBag.pasaje = new SelectList(db.pasajes, "id_pasajes", "lugar_despegue");
            ViewBag.vuelo = new SelectList(db.vuelo, "id_vuelo", "id_vuelo");
            return View();
        }

        // POST: MantenedorPasajeros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pasajero,nombre,apellido,pasaje,vuelo")] pasajero pasajero)
        {
            if (ModelState.IsValid)
            {
                db.pasajero.Add(pasajero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pasaje = new SelectList(db.pasajes, "id_pasajes", "lugar_despegue", pasajero.pasaje);
            ViewBag.vuelo = new SelectList(db.vuelo, "id_vuelo", "id_vuelo", pasajero.vuelo);
            return View(pasajero);
        }

        // GET: MantenedorPasajeros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasajero pasajero = db.pasajero.Find(id);
            if (pasajero == null)
            {
                return HttpNotFound();
            }
            ViewBag.pasaje = new SelectList(db.pasajes, "id_pasajes", "lugar_despegue", pasajero.pasaje);
            ViewBag.vuelo = new SelectList(db.vuelo, "id_vuelo", "id_vuelo", pasajero.vuelo);
            return View(pasajero);
        }

        // POST: MantenedorPasajeros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pasajero,nombre,apellido,pasaje,vuelo")] pasajero pasajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasajero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pasaje = new SelectList(db.pasajes, "id_pasajes", "lugar_despegue", pasajero.pasaje);
            ViewBag.vuelo = new SelectList(db.vuelo, "id_vuelo", "id_vuelo", pasajero.vuelo);
            return View(pasajero);
        }

        // GET: MantenedorPasajeros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasajero pasajero = db.pasajero.Find(id);
            if (pasajero == null)
            {
                return HttpNotFound();
            }
            return View(pasajero);
        }

        // POST: MantenedorPasajeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pasajero pasajero = db.pasajero.Find(id);
            db.pasajero.Remove(pasajero);
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
