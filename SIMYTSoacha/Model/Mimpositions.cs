using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Mimpositions")]
    public class Mimpositions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MimpositionId { get; set; }
        [MaxLength(50)]
        public required string MimpositionName { get; set; }
    }
}
