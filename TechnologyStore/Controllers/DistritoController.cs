using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models;

namespace TechnologyStore.Controllers
{
    public class DistritoController : Controller
    {

        TechnologyDataEntities bd = new TechnologyDataEntities();

        // GET: Distrito
        public ActionResult ListaDistritos()
        {
            return View(bd.usp_adm_distrito_listar());
        }


        public ActionResult SaveDistrito()
        {
            return View(new Distrito());
        }

        [HttpPost]
        public ActionResult SaveDistrito(Distrito d)
        {
            if (ModelState.IsValid)
            {
                bd.usp_adm_distrito_registrar(d.nomDistrito);
                return RedirectToAction("ListaDistritos", "Distrito");
            }
            return View(d);
        }
    }
}