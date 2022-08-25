using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model.APP.Models.Database;

namespace Backend.App.Interface
{
    public interface IGetRegistrados
    {
        IEnumerable<Registrado> GetregistradoAll { get; }
    }
}
