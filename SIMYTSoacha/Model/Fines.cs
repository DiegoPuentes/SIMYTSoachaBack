using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Fines")]
    public class Fines
    {
        [Key]
        public int FinesId { get; set; }
        public int InfractionId { get; set; }
        public int MimpositionId { get; set; }
        public int ManagerId { get; set; }
        public int ProcedureId { get; set; }

    }
}
