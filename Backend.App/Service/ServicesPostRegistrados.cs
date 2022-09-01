using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.App.Interface;
using Backend.App.DA.Post;
using Model.APP.Models.Database;
using Model.APP.Models.DTO;

namespace Backend.App.Service
{
    public class ServicesPostRegistrados : IPostRegistrados
    {
        public DataRepositoryPostRegistrados data = new DataRepositoryPostRegistrados();

        public void PostRegistrado(Registrado item)
        {
            item.NombresCompletos = item.Nombres + ' ' + item.Apellidos;
            item.FechaRegistro = DateTime.Now;

            data.PostRegistrado(item);
        }

        public IEnumerable<DtoResultTran> PostSPRegistrado(string Identificacion,
               string Nombres, string Apellidos)
        {
            return data.PostSPRegistrado(Identificacion, Nombres, Apellidos);
        }

        public void UpdateRegistradoObject(Registrado item)
        {
            data.UpdateRegistradoObject(item);
        }

        public void UpdateRegistradoParam(int IdRegistrado, string Identificacion,
               string Nombres, string Apellidos)
        {
            data.UpdateRegistradoParam(IdRegistrado, Identificacion,
                Nombres, Apellidos);
        }


        public void DeleteRegistradoObject(Registrado item)
        {
            data.DeleteRegistradoObject(item);
        }

        public void DeleteRegistradoParam(int IdRegistrado)
        {
            data.DeleteRegistradoParam(IdRegistrado);
        }

    }
}
