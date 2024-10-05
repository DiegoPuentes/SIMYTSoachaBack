using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("ExpeditionsCenters")]
    public class Ecenters
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EcenterId { get; set; }
        [MaxLength(100)]
        public required string Ecenter {  get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
