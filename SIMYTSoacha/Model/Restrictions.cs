using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Restrictions")]
    public class Restrictions
    {
        [Key]
        public int RestrictionId { get; set; }
        [MaxLength(50)]
        public string? RestrictionName { get; set; }
    }
}
