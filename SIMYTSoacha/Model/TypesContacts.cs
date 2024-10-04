using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("TypesContacts")]
    public class TypesContacts
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TcontactId { get; set; }
        public required string Dtype { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
