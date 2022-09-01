using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.APP.Models.Database;
using Model.APP.Models.DTO;

namespace Backend.App.Interface
{
    public interface IPostRegistrados
    {
        void PostRegistrado(Registrado item);

        IEnumerable<DtoResultTran> PostSPRegistrado(string Identificacion,
               string Nombres, string Apellidos);

        void UpdateRegistradoObject(Registrado item);
        void UpdateRegistradoParam(int IdRegistrado, string Identificacion,
               string Nombres, string Apellidos);
        void DeleteRegistradoObject(Registrado item);
        void DeleteRegistradoParam(int IdRegistrado);
    }
}
