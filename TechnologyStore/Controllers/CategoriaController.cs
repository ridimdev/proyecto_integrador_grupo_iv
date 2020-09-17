using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models;

namespace TechnologyStore.Controllers
{
    public class CategoriaController : Controller
    {

        TechnologyDataEntities bd = new TechnologyDataEntities();


        // GET: Categoria
        public ActionResult ListaCategorias()
        {
            return View(bd.usp_adm_categoria_listar());
        }

        public ActionResult SaveCategoria()
        {
            return View(new Categoria());
        }

        [HttpPost]
        public ActionResult SaveCategoria(Categoria c)
        {
            if (ModelState.IsValid)
            {
                bd.usp_adm_categoria_registrar(c.nomCategoria);
                return RedirectToAction("ListaCategorias", "Categoria");
            }
            return View(c);
        }
    }
}