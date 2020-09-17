using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models;

namespace TechnologyStore.Controllers
{
    public class EmpleadoController : Controller
    {

        TechnologyDataEntities bd = new TechnologyDataEntities();

        // GET: Empleado
        public ActionResult ListadoEmpleados()
        {
            TempData["distrito"] = bd.Distrito.ToList();
            TempData["cargo"] = bd.Cargo.ToList();
            TempData["tipousu"] = bd.Tipo_Usuario.ToList();
            TempData["prod"] = null;
            return View(bd.usp_adm_listar_empleados());
        }


        public ActionResult SaveEmpleado()
        {
            ViewBag.distrito = new SelectList(bd.Distrito.ToList().OrderBy(x => x.nomDistrito), "idDistrito", "nomDistrito");
            ViewBag.cargo = new SelectList(bd.Cargo.ToList().OrderBy(x => x.nomCargo), "idCargo", "nomCargo");
            ViewBag.tipousuario = new SelectList(bd.Tipo_Usuario.ToList().OrderBy(x => x.nomTipoUsuario), "idTipoUsuario", "nomTipoUsuario");
            return View(new Empleado());
        }

        [HttpPost]
        public ActionResult SaveEmpleado(Empleado e)
        {
            if (ModelState.IsValid)
            {
                bd.usp_adm_registrar_empleado(e.nomEmpleado, e.apeEmpleado, e.dniEmpleado, e.tlfEmpleado, e.direcEmpleado, e.idDistrito, e.idCargo, e.emailEmpleado, e.passEmpleado, e.idTipoUsuario);
                return RedirectToAction("ListadoEmpleados", "Empleado");
            }
            ViewBag.distrito = new SelectList(bd.Distrito.ToList().OrderBy(x => x.nomDistrito), "idDistrito", "nomDistrito", e.idDistrito);
            ViewBag.cargo = new SelectList(bd.Cargo.ToList().OrderBy(x => x.nomCargo), "idCargo", "nomCargo", e.idCargo);
            ViewBag.tipousuario = new SelectList(bd.Tipo_Usuario.ToList().OrderBy(x => x.nomTipoUsuario), "idTipoUsuario", "nomTipoUsuario", e.idTipoUsuario);

            return View(e);
        }
    }
}