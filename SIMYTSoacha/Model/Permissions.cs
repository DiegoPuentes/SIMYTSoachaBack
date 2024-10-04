using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Permissions")]
    public class Permissions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pid { get; set; }
        [MaxLength(50)]
        public required string Permission {  get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
