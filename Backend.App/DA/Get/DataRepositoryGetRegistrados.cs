using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.APP.Models.Database;

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
        

    }
}
