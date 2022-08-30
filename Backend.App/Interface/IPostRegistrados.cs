using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.APP.Models.Database;

namespace Backend.App.Interface
{
    public interface IPostRegistrados
    {
        void PostRegistrado(Registrado item);
        void DeleteRegistradoObject(Registrado item);
        void DeleteRegistradoParam(int IdRegistrado);
    }
}
