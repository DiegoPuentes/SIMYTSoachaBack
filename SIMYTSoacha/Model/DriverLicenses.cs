using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("DriverLicenses")]
    public class DriverLicenses
    {
        [Key]
        public int DriverLicenseId { get; set; }
        public int Nlicense {  get; set; }
        public int EcenterId { get; set; }
        public DateTime DateIssue { get; set; }
        public int StateId { get; set; }
        public int RestrictionId { get; set; }
        public int ProcedureId { get; set; }
    }
}
