using System.ComponentModel.DataAnnotations;

namespace MVCInvTI.Models
{
    public class CadProd
    {
        [Key]
        public int idProd { get; set; }
        public string Maquina { get; set; }
        public string Detalhes { get; set; }
    }
}
