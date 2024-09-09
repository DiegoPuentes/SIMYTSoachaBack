using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Procedures")]
    public class Procedures
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcedureId { get; set; }
        public int Procedure {  get; set; }
        public int StateId { get; set; }
        public virtual required States States { get; set; } 
        public int RequestId { get; set; }
        public virtual required Requests Requests { get; set; }
    }
}
