using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.APP.Models.Database;
using Backend.App.Models.DTO;

namespace Backend.App.Interface
{
    public interface IGetRegistrados
    {
        IEnumerable<Registrado> GetregistradoAll { get; }
        IEnumerable<DTORegistrado> GetDTORegistradoAll { get; }
        Registrado GetRegistradoObjectById(int idregistrado);
        Registrado GetRegistradoObjetcByIdentificacion(string identificacion);
    }
}
