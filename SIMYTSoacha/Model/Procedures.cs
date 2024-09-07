using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Procedures")]
    public class Procedures
    {
        [Key]
        public int ProcedureId { get; set; }
        public int Procedure {  get; set; }
        public int StateId { get; set; }
        public int RequestId { get; set; }
    }
}
