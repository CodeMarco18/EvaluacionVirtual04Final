using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EvaluacionVirtual04.Models;

namespace EvaluacionVirtual04.Controllers
{
    public class ValuesController : ApiController
    {
        Evaluacion04Entities bd = new Evaluacion04Entities(); 

        // GET api/values

        public IEnumerable<empleado> Get()
        {
            return bd.empleado.ToList();
        }

        // GET api/values/5
        //Obtener por codigo
        public empleado Get(int codigo)
        {
            return bd.empleado.ToList().Where(e=>e.eCodigo==codigo).FirstOrDefault();
        }
 

        // POST api/values
        //Insertar
        public void Post(empleado em)
        {
            try 
            {
                empleado e = new empleado();
                e.eCodigo = em.eCodigo;
                e.eNombre = em.eNombre;
                e.eApellido = em.eApellido;
                e.eDNI = em.eDNI;
                e.eDireccion = em.eDireccion;
                e.eCelular = em.eCelular;
                e.eEmail = em.eEmail;
                e.eImagen = em.eImagen;
                bd.empleado.Add(e);
                bd.SaveChanges();

            
            } 
            catch (Exception ) 
            {
                throw;
            }
        }

        // PUT api/values/5
        //Actualizar
        public void Put(empleado em)
        {
            bd.Entry(em).State = System.Data.EntityState.Modified;
            bd.SaveChanges();
        }

        // DELETE api/values/5
        //Eliminar
        public void Delete(int codigo)
        {
            empleado e = Get(codigo);
            bd.empleado.Remove(e);
            bd.SaveChanges();
        }
    }
}
