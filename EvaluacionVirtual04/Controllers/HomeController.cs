using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EvaluacionVirtual04.Models;


namespace EvaluacionVirtual04.Controllers
{
    public class HomeController : Controller
    {
        ValuesController bd = new ValuesController();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ListarEmpleados()
        {
            return View(bd.Get());
        }

        public ActionResult DetalleEmpleado()
        {
            return View(bd.Get());
        }


        public ActionResult Create()
        {
            return View(new empleado());

        }
        [HttpPost]
        public ActionResult Create(empleado em)
        {
            if (!ModelState.IsValid)
            {
                return View(em);
            }
            bd.Post(em);
            return RedirectToAction("ListarEmpleados");
             
        }

        public ActionResult EditarEmpleado(int id)
        {
            empleado e = bd.Get(id);
            return View(e);

        }
        [HttpPost]
        public ActionResult EditarEmpleado(empleado em)
        {
            if (!ModelState.IsValid)
            {
                return View(em);
            }
            bd.Post(em);
            return RedirectToAction("ListarEmpleados");

        }

        public ActionResult EliminarEmpleado(int id)
        {
            bd.Delete(id);
            return RedirectToAction("ListarEmpleados");

        }




    }
}
