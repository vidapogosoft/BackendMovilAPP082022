using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.App.Interface;
using Backend.App.DA.Get;
using Model.APP.Models.Database;
using Backend.App.Models.DTO;

namespace Backend.App.Service
{
    public class ServicesGetRegistrados : IGetRegistrados
    {
        public DataRepositoryGetRegistrados data = new DataRepositoryGetRegistrados();

        public IEnumerable<Registrado> GetregistradoAll
        {
            get { return data.GetregistradoAll(); }
        }

        public IEnumerable<DTORegistrado> GetDTORegistradoAll
        {
            get { return data.GetDTORegistradoAll(); }
        }

        public Registrado GetRegistradoObjectById(int idregistrado)
        {
            return data.GetRegistradoObjectById(idregistrado);
        }

        public Registrado GetRegistradoObjetcByIdentificacion(string identificacion)
        {
            return data.GetRegistradoObjetcByIdentificacion(identificacion);
        }
    }
}
