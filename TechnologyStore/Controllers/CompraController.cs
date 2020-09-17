using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models;

namespace TechnologyStore.Controllers
{
    public class CompraController : Controller
    {

        TechnologyDataEntities bd = new TechnologyDataEntities();


        // GET: Compra
        public ActionResult ListaCompra()
        {
            TempData["cliente"] = bd.Cliente.ToList();
            TempData["producto"] = bd.Producto.ToList();
            TempData["prod"] = null;
            return View(bd.usp_adm_compra_lista());
        }
    }
}