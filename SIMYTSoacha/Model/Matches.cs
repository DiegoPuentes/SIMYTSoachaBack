using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Matches")]
    public class Matches
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PeopleId { get; set; }
        [ForeignKey("PeopleId")]
        public virtual required People People { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

    }
}
