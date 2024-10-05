using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("DriverLicenses")]
    public class DriverLicenses
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required int Nlicense {  get; set; }
        public required int EcenterId { get; set; }
        [ForeignKey("EcenterId")]
        public required virtual Ecenters Ecenters { get; set; }
        public required DateTime DateIssue { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public required virtual States States { get; set; }
        public int RestrictionId { get; set; }
        [ForeignKey("RestrictionId")]
        public required virtual Restrictions Restrictions { get; set; }
        public int ProcedureId { get; set; }
        [ForeignKey("ProcedureId")]
        public required virtual Procedures Procedures { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
