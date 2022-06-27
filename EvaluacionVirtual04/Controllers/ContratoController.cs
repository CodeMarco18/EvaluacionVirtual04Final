using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EvaluacionVirtual04.Models;

namespace EvaluacionVirtual04.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        ValuesContratoController bd = new ValuesContratoController();


        public ActionResult ListarContrato()
        {
            return View(bd.Get());
        }


        public ActionResult CrearContrato()
        {
            ViewBag.empleado = new SelectList(bd.GetArea(), "aCodigo","aDescripcion");
            ViewBag.empleado = new SelectList(bd.GetEmpleado(), "eCodigo","eNombre");
            return View(new contrato());

        }
        [HttpPost]
        public ActionResult CrearContrato(contrato co)
        {
            if (!ModelState.IsValid)
            {
                return View(co);
            }
            bd.Post(co);
            return RedirectToAction("ListarContrato");

        }

        public ActionResult EditarContrato(int id)
        {
            contrato c = bd.Get(id);
            ViewBag.empleado = new SelectList(bd.GetArea(), "aCodigo", "aDescripcion");
            ViewBag.empleado = new SelectList(bd.GetEmpleado(), "eCodigo", "eNombre");
            return View(c);

        }
        [HttpPost]
        public ActionResult EditarContrato(contrato co)
        {
            if (!ModelState.IsValid)
            {
                return View(co);
            }
            bd.Post(co);
            return RedirectToAction("ListarContrato");

        }

        public ActionResult EliminarContrato(int id)
        {
            bd.Delete(id);
            return RedirectToAction("ListarContrato");

        }




    }
}