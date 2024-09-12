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
        //This method is for the relationship of vehicle state 
        public virtual States States { get; set; }
        public int TserviceId { get; set; }
        public virtual TypesServices Services { get; set; }
        public int TvehicleId { get; set; }
        //Missing invoke the method of the class TypesVehicles
        public int ProcedureId { get; set; }
        public virtual Procedures Procedures { get; set; }
    }
}
