using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.App.Interface;
using Backend.App.DA.Post;
using Model.APP.Models.Database;

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

    }
}
