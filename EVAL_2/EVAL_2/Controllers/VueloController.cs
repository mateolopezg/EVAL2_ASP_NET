using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EVAL_2.Models;


namespace EVAL_2.Controllers
{
    public class VueloController : Controller
    {
        bd_vuelaEntities bd_VuelaEntities = new bd_vuelaEntities();

        public ActionResult Index()
        {
            var listavuelo = bd_VuelaEntities.vuelo;
            return View(listavuelo.ToList());
        }

        public ActionResult ListaMaestraVuelo()
        {
            var listavuelo = bd_VuelaEntities.vuelo;
            return View(listavuelo.ToList());
        }
    }
}