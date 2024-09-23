using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("ModelXLine")]
    public class ModelXLine
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LineNumberId { get; set; }
        [ForeignKey("LineNumberId")]
        public required virtual Line Line { get; set; }
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public required virtual Models Models { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
