using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models;

namespace TechnologyStore.Controllers
{
    public class LoginController : Controller
    {

        TechnologyDataEntities bd = new TechnologyDataEntities();

        // GET: Login
        public ActionResult LoginCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCliente(Cliente c)
        {
            try
            {

                if (Session["cliente"] == null)
                {
                    Cliente cli = new Cliente();
                    Session["cliente"] = cli;
                }
                Cliente a = bd.Cliente.Where(x => x.emailCliente == c.emailCliente && x.passCliente == c.passCliente).First();
                Session["cliente"] = a;

                if (TempData["prod"] == null)
                {
                    return RedirectToAction("ListadoProductos", "Producto");
                }

                return RedirectToAction("DetalleProducto", "Producto", new { codProd = TempData["prod"] });
            }
            catch
            {
                return View(c);
            }
            
        }



        /*
         Login de Administrador
         */


        public ActionResult LoginAdministrador()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdministrador(Empleado e)
        {
            try
            {
                if (Session["administrador"] == null)
                {
                    Empleado emp = new Empleado();
                    Session["administrador"] = emp;
                }
                Empleado a = bd.Empleado.Where(x => x.emailEmpleado == e.emailEmpleado && x.passEmpleado == e.passEmpleado).First();
                Session["administrador"] = a;
                
                if (TempData["prod"] == null)
                {
                    Session["adminName"] = a.nomEmpleado;
                    Session["adminApe"] = a.apeEmpleado;
                    return RedirectToAction("PageAdministrador", "Administrador");
                }

                return RedirectToAction("PageAdministrador", "Administrador", new { codProd = TempData["prod"] });
            }
            catch
            {
                return View(e);
            }
        }




        public ActionResult CerrarSesionAdmin()
        {
            if (Session["administrador"] != null)
            {
                Session["administrador"] = null;
                TempData["prod"] = null;
                return RedirectToAction("LoginAdministrador", "Login");
            }
            return RedirectToAction("LoginAdministrador", "Login");
        }
    }
}