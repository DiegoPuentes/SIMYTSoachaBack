using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Infractions")]
    public class Infractions
    {
        [Key]
        public int InfractionId { get; set; }
        [MaxLength(50)]
        public string? InfractionName { get; set; }
    }
}
