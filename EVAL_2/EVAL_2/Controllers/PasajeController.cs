using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EVAL_2.Models;

namespace EVAL_2.Controllers
{
    public class PasajeController : Controller
    {
        // GET: Pasaje
        bd_vuelaEntities bd_VuelaEntities = new bd_vuelaEntities();

        public ActionResult Index()
        {
            var listapasaje = bd_VuelaEntities.pasajes;
            return View(listapasaje.ToList());
        }

        public ActionResult ListaMaestraPasajes()
        {
            var listapasaje = bd_VuelaEntities.pasajes;
            return View(listapasaje.ToList());
        }

 
        public ActionResult listarPasajeros(string vuelo)
        {
            var model = from p in bd_VuelaEntities.pasajes
                        select p;
            return View(model.ToList());
        }

        public ActionResult listarPasajerosPorVuelo()
        {
            var model = from p in bd_VuelaEntities.pasajero
                        join v in bd_VuelaEntities.vuelo
                        on p.vuelo equals v.id_vuelo

                        select new _Pasajero
                        {
                            id_pasajero = p.id_pasajero,
                            nombre      =  p.nombre,
                            apellido    = p.apellido,
                            pasaje      = p.pasaje,
                            vuelo       = v.id_vuelo
                        };
            return View(model.ToList());
        
        }

    }
}