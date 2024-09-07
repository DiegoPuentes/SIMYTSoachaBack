using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("UsersTypes")]
    public class UsersTypes
    {
        [Key]
        public int UtypesId { get; set; }
        [MaxLength(50)]
        public string? UtypesName { get; set; }
    }
}
