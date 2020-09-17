using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models;

namespace TechnologyStore.Controllers
{
    public class TipoUsuarioController : Controller
    {
        TechnologyDataEntities bd = new TechnologyDataEntities();


        // GET: TipoUsuario
        public ActionResult ListaTipoUsuario()
        {
            return View(bd.usp_adm_tipousuario_listar());
        }


        public ActionResult SaveTipoUsuario()
        {
            return View(new Tipo_Usuario());
        }

        [HttpPost]
        public ActionResult SaveTipoUsuario(Tipo_Usuario t)
        {
            if (ModelState.IsValid)
            {
                bd.usp_adm_tipousuario_registrar(t.nomTipoUsuario);
                return RedirectToAction("ListaTipoUsuario", "TipoUsuario");
            }
            return View(t);
        }
    }
}