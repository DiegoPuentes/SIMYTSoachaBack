using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("TrafficLicenses")]
    public class TrafficLicenses
    {
        [Key]
        public int TlicensesId { get; set; }
        [MaxLength(6)]
        public string? Plate {  get; set; }
        public int VstatusId { get; set; }
        public int TserviceId { get; set; }
        public int TvehicleId { get; set; }
        public int ProcedureId { get; set; }
    }
}
