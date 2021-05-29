using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EVAL_2.Models;

namespace EVAL_2.Controllers
{
    public class PasajeroController : Controller
    {
        // GET: Pasajero

        bd_vuelaEntities bd_VuelaEntities = new bd_vuelaEntities();

        public ActionResult Index()
        {
            var listapasaje = bd_VuelaEntities.pasajero;
            return View(listapasaje.ToList());
        }

        public ActionResult ListaMaestraPasajeros()
        {
            var listapasaje = bd_VuelaEntities.pasajero;
            return View(listapasaje.ToList());
        }
    }
}