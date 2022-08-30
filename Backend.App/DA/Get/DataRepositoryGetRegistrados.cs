using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.APP.Models.Database;
using Backend.App.Models.DTO;

namespace Backend.App.DA.Get
{
    public class DataRepositoryGetRegistrados
    {
        public List<Registrado> GetregistradoAll()
        {
            using (var ctx = new dbappContext())
            {
                return ctx.Registrados.ToList();
            }
        }
        
        public Registrado GetRegistradoObjectById (int idregistrado)
        {
            using (var ctx = new dbappContext())
            {
                return ctx.Registrados.Where(a => a.IdRegistrado == idregistrado).FirstOrDefault();
            }

        }

        public Registrado GetRegistradoObjetcByIdentificacion(string identificacion)
        {
            using (var ctx = new dbappContext())
            {
                return ctx.Registrados.Where(a => a.Identificacion == identificacion)
                    .OrderByDescending(a=> a.FechaRegistro)
                    .FirstOrDefault();
            }

        }

        public List<DTORegistrado> GetDTORegistradoAll()
        {
            using (var ctx = new dbappContext())
            {
                var x = (

                    from a in ctx.Registrados

                    select new DTORegistrado()
                    {
                        IdSecuencial = a.IdRegistrado,
                        DNI = a.Identificacion,
                        Registrado = a.NombresCompletos
                    }

                    ).ToList();

                return x;
            }

          }

    }
}
