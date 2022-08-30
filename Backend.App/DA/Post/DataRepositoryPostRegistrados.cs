using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.APP.Models.Database;

namespace Backend.App.DA.Post
{
    public class DataRepositoryPostRegistrados
    {

        public void PostRegistrado(Registrado item)
        {
            using (var ctx = new dbappContext())
            {
                ctx.Registrados.Add(item);
                ctx.SaveChanges();
            }
        }

        public void DeleteRegistradoObject(Registrado item)
        {
            using (var ctx = new dbappContext())
            {
                ctx.Registrados.Remove(item);
                ctx.SaveChanges();
            }
        }

        public void DeleteRegistradoParam(int IdRegistrado)
        {
            using (var ctx = new dbappContext())
            {
                var registrado = ctx.Registrados.Where(a => a.IdRegistrado == IdRegistrado).FirstOrDefault();

                if (registrado != null)
                {
                    ctx.Registrados.Remove(registrado);
                    ctx.SaveChanges();
                }
            }
        }


        public void UpdateRegistradoObject(Registrado item)
        {
            using (var ctx = new dbappContext())
            {
                var registrado = ctx.Registrados.
                    Where(a => a.IdRegistrado == item.IdRegistrado).FirstOrDefault();

                if (registrado != null)
                {
                    registrado.Identificacion = item.Identificacion;
                    registrado.Nombres = item.Nombres;
                    registrado.Apellidos = item.Apellidos;
                    registrado.NombresCompletos = item.Nombres + " " + item.Apellidos;
                    registrado.FechaRegistro = DateTime.Now;

                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateRegistradoParam(int IdRegistrado, string Identificacion,
               string Nombres, string Apellidos)
        { 
            using (var ctx = new dbappContext())
            {
                var registrado = ctx.Registrados.
                   Where(a => a.IdRegistrado == IdRegistrado).FirstOrDefault();

                if (registrado != null)
                {
                    registrado.Identificacion = Identificacion;
                    registrado.Nombres = Nombres;
                    registrado.Apellidos = Apellidos;
                    registrado.NombresCompletos = Nombres + " " + Apellidos;
                    registrado.FechaRegistro = DateTime.Now;

                    ctx.SaveChanges();

                }

            }
        }
    }
}
