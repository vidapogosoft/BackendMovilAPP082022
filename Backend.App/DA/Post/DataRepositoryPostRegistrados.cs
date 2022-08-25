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

    }
}
