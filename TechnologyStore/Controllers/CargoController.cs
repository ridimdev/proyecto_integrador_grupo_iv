using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models;

namespace TechnologyStore.Controllers
{
    public class CargoController : Controller
    {

        TechnologyDataEntities bd = new TechnologyDataEntities();

        // GET: Cargo
        public ActionResult ListaCargos()
        {
            TempData["prod"] = null;
            return View(bd.usp_adm_cargo_listar());
        }

        public ActionResult SaveCargo()
        {
            return View(new Cargo());
        }

        [HttpPost]
        public ActionResult SaveCargo(Cargo c)
        {
            if (ModelState.IsValid)
            {
                bd.usp_adm_cargo_registrar(c.nomCargo);
                return RedirectToAction("ListaCargos", "Cargo");
            }
            return View(c);
        }



        public ActionResult UpdateCargo(int id)
        {
            Cargo c = bd.Cargo.Where(x => x.idCargo == id).ToList().First();
            TempData["prod"] = null;
            return View(c);
        }

        [HttpPost]
        public ActionResult UpdateCargo(Cargo c)
        {

            if (!ModelState.IsValid)
            {
                return View(c);
            }
            Cargo cargo = (Cargo)Session["cargo"];
            cargo.nomCargo = c.nomCargo;

            bd.usp_adm_cargo_actualizar(cargo.idCargo, cargo.nomCargo);

            Session["cargo"] = cargo;

            return RedirectToAction("ListaCargos", "Cargo");
        }
    }
}