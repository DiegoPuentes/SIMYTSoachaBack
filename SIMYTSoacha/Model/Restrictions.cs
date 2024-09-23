using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Restrictions")]
    public class Restrictions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestrictionId { get; set; }
        [MaxLength(50)]
        public required string RestrictionName { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
