using System.ComponentModel.DataAnnotations;

namespace MVCInvTI.Models
{
    public class CadCliModel : InvMaq
    {
        [Key]
        public int idCli { get; set; }
        public int idMaq { get; set; }
        public int idSoft { get; set; }
        public string NomeCli { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public List<InvMaq> MaquinasList { get; set; }
        public List<InvSoft> SoftwareList { get; set; }
    }
}
