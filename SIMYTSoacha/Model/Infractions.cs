using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Infractions")]
    public class Infractions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InfractionId { get; set; }
        [MaxLength(50)]
        public required string InfractionName { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
