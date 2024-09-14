using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("TrafficLicenses")]
    public class TrafficLicenses
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TlicensesId { get; set; }
        [MaxLength(6)]
        public required string Plate {  get; set; }
        public int VstatesId { get; set; }
        //This property is for the relationship of vehicle state 
        [ForeignKey("VstatesId")]
        public required virtual States States { get; set; }
        public int TserviceId { get; set; }
        [ForeignKey("TserviceId")]
        public required virtual TypesServices Services { get; set; }
        public int TvehicleId { get; set; }
        [ForeignKey("TvehicleId")]
        public required virtual TypesVehicles Vehicles { get; set; }
        public int ProcedureId { get; set; }
        [ForeignKey("ProcedureId")]
        public required virtual Procedures Procedures { get; set; }
    }
}
