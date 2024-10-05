    using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SIMYTSoacha.Model
{
    [Table("Lines")]
    public class Lines
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Nline { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
