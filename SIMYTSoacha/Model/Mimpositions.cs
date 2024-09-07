using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Mimpositions")]
    public class Mimpositions
    {
        [Key]
        public int MimpositionId { get; set; }
        [MaxLength(50)]
        public string? MimpositionName { get; set; }
    }
}
