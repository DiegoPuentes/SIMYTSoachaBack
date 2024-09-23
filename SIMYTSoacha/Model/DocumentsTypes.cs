using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("DocumentsTypes")]
    public class DocumentsTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DtypesId { get; set; }
        [MaxLength(50)]
        public required string Dtype { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
