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
        [ForeignKey("StateId")]
        public required virtual States States { get; set; } 
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public required virtual Requests Requests { get; set; }
    }
}
