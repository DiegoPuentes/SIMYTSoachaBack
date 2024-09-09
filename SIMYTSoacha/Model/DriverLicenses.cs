using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("DriverLicenses")]
    public class DriverLicenses
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverLicenseId { get; set; }
        public int Nlicense {  get; set; }
        public int EcenterId { get; set; }
        public virtual required Ecenters Ecenters { get; set; }
        public DateTime DateIssue { get; set; }
        public int StateId { get; set; }
        public virtual required States States { get; set; }
        public int RestrictionId { get; set; }
        public virtual required Restrictions Restrictions { get; set; }
        public int ProcedureId { get; set; }
        public virtual required Procedures Procedures { get; set; }
    }
}
