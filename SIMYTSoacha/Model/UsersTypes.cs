using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("UsersTypes")]
    public class UsersTypes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UtypesId { get; set; }
        [MaxLength(50)]
        public required string UtypesName { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
