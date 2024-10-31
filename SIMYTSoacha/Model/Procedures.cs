using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Procedures")]
    public class Procedures
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProcedureId { get; set; }
        public required string Description {  get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public required virtual States States { get; set; } 
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public required virtual Requests Requests { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
