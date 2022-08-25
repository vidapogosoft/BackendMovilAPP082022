using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.App.Interface;
using Backend.App.DA.Get;
using Model.APP.Models.Database;

namespace Backend.App.Service
{
    public class ServicesGetRegistrados : IGetRegistrados
    {
        public DataRepositoryGetRegistrados data = new DataRepositoryGetRegistrados();

        public IEnumerable<Registrado> GetregistradoAll
        {
            get { return data.GetregistradoAll(); }
        }
    }
}
