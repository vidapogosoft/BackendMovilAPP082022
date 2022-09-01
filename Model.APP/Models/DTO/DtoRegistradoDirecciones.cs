
using System.ComponentModel.DataAnnotations;

namespace Model.APP.Models.DTO
{
    public class DtoRegistradoDirecciones
    {

        [Key]
        public int IdDirecciones { get; set; }
        public int IdRegistrado { get; set; }
        public string Identificacion { get; set; }
        public string NombresCompletos { get; set; }
        public string Direccion { get; set; }

    }
}
