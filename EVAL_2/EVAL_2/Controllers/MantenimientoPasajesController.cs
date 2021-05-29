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
    public class MantenimientoPasajesController : Controller
    {
        private bd_vuelaEntities db = new bd_vuelaEntities();

        // GET: MantenimientoPasajes
        public ActionResult Index()
        {
            var pasajes = db.pasajes.Include(p => p.vuelo1);
            return View(pasajes.ToList());
        }

        // GET: MantenimientoPasajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasajes pasajes = db.pasajes.Find(id);
            if (pasajes == null)
            {
                return HttpNotFound();
            }
            return View(pasajes);
        }

        // GET: MantenimientoPasajes/Create
        public ActionResult Create()
        {
            ViewBag.vuelo = new SelectList(db.vuelo, "id_vuelo", "id_vuelo");
            return View();
        }

        // POST: MantenimientoPasajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pasajes,lugar_despegue,lugar_arribo,vuelo,fecha_despegue,fecha_arribo")] pasajes pasajes)
        {
            if (ModelState.IsValid)
            {
                db.pasajes.Add(pasajes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vuelo = new SelectList(db.vuelo, "id_vuelo", "id_vuelo", pasajes.vuelo);
            return View(pasajes);
        }

        // GET: MantenimientoPasajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasajes pasajes = db.pasajes.Find(id);
            if (pasajes == null)
            {
                return HttpNotFound();
            }
            ViewBag.vuelo = new SelectList(db.vuelo, "id_vuelo", "id_vuelo", pasajes.vuelo);
            return View(pasajes);
        }

        // POST: MantenimientoPasajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pasajes,lugar_despegue,lugar_arribo,vuelo,fecha_despegue,fecha_arribo")] pasajes pasajes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasajes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vuelo = new SelectList(db.vuelo, "id_vuelo", "id_vuelo", pasajes.vuelo);
            return View(pasajes);
        }

        // GET: MantenimientoPasajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pasajes pasajes = db.pasajes.Find(id);
            if (pasajes == null)
            {
                return HttpNotFound();
            }
            return View(pasajes);
        }

        // POST: MantenimientoPasajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pasajes pasajes = db.pasajes.Find(id);
            db.pasajes.Remove(pasajes);
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
