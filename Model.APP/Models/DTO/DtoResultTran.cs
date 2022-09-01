using System.ComponentModel.DataAnnotations;

namespace Model.APP.Models.DTO
{
    public class DtoResultTran
    {
        [Key]
        public int IdTran { get; set; }
        public string Mensaje { get; set; }
    }
}
