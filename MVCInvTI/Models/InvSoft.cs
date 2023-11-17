using System.ComponentModel.DataAnnotations;

namespace MVCInvTI.Models
{
    public class InvSoft 
    {
        [Key]
        public int idSoft { get; set; }
        public string Software { get; set; }
        public string CodSoft { get; set; }
    }
}
