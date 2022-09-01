using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.APP.Models.Database;
using Model.APP.Models.DTO;
using Backend.App.Models.DTO;

namespace Backend.App.Interface
{
    public interface IGetRegistrados
    {
        IEnumerable<Registrado> GetregistradoAll { get; }
        IEnumerable<DTORegistrado> GetDTORegistradoAll { get; }
        IEnumerable<DtoRegistradoDirecciones> GetSPRegistradoDirecciones { get; }
        IEnumerable<DtoRegistradoDirecciones> GetSPRegistradoDireccion(string Identificacion);
        Registrado GetRegistradoObjectById(int idregistrado);
        Registrado GetRegistradoObjetcByIdentificacion(string identificacion);
    }
}
