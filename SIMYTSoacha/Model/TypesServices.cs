using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("TypesServices")]
    public class TypesServices
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TservicesId { get; set; }
        [MaxLength(50)]
        public required string TservicesName { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
