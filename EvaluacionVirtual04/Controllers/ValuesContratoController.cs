using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using EvaluacionVirtual04.Models;


namespace EvaluacionVirtual04.Controllers
{
    public class ValuesContratoController : Controller
    {
        Evaluacion04Entities bd = new Evaluacion04Entities();
        // GET: ValuesContrato
        public IEnumerable<contrato> Get()
        {
            return bd.contrato.ToList();
        }

        public contrato Get(int codigo)
        {
            return bd.contrato.ToList().Where(c => c.cCodigo == codigo).FirstOrDefault();
        }
        public IEnumerable<area> GetArea()
        {
            return bd.area.ToList();
        }
        public IEnumerable<empleado> GetEmpleado()
        {
            return bd.empleado.ToList();
        }
        public void Post(contrato co)
        {
            try
            {
                contrato c = new contrato();
                c.cCodigo = co.cCodigo;
                c.cFecha = co.cFecha;
                c.cFechaFin = co.cFechaFin;
                c.cSueldo = co.cSueldo;
                c.aCodigo = co.aCodigo;
                c.cFechaInicio = co.cFechaInicio;
                c.eCodigo = co.eCodigo;
                bd.contrato.Add(c);
                bd.SaveChanges();


            }
            catch (Exception)
            {
                throw;
            }
        }


        // PUT api/values/5
        //Actualizar
        public void Put(contrato co)
        {
            bd.Entry(co).State = System.Data.EntityState.Modified;
            bd.SaveChanges();
        }

        // DELETE api/values/5
        //Eliminar
        public void Delete(int codigo)
        {
            contrato c = Get(codigo);
            bd.contrato.Remove(c);
            bd.SaveChanges();
        }
    }
}
