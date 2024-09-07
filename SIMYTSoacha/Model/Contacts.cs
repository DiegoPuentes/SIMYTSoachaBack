using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Contacts")]
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }
        public int TcontactId { get; set; }
        public int PeopleId { get; set; }
        [MaxLength(50)]
        public string? Contact {  get; set; }
    }
}
