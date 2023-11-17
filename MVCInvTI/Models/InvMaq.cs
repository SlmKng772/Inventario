using System.ComponentModel.DataAnnotations;

namespace MVCInvTI.Models
{
    public class InvMaq 
    {
        [Key]
        public int idMaq { get; set; }
        public int idProd { get; set; }
        public string CodMaq { get; set; }
        public string Observacoes { get; set; }
    }
}
