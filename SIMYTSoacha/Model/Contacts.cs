using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Contacts")]
    public class Contacts
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        public int TcontactId { get; set; }
        public virtual required TypesContacts TypesContacts { get; set; }
        public int PeopleId { get; set; }
        public virtual required People People { get; set; }
        [MaxLength(50)]
        public required string Contact {  get; set; }
    }
}
