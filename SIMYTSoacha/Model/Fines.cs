using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Fines")]
    public class Fines
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FinesId { get; set; }
        public int InfractionId { get; set; }
        [ForeignKey("InfractionId")]
        public required virtual Infractions Infractions { get; set; }
        public int MimpositionId { get; set; }
        [ForeignKey("MimpositionId")]
        public required virtual Mimpositions Mimpositions { get; set; }
        public int ProcedureId { get; set; }
        [ForeignKey("ProcedureId")]
        public required virtual Procedures Procedures { get; set; }
    }
}
