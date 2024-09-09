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
        public virtual required Infractions Infractions { get; set; }
        public int MimpositionId { get; set; }
        public  virtual required Mimpositions Mimpositions { get; set; }
        public int ManagerId { get; set; }
        public virtual required Managers Managers { get; set; }
        public int ProcedureId { get; set; }
        public virtual required Procedures Procedures { get; set; }
    }
}
