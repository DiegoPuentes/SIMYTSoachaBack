using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Requests")]
    public class Requests
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public int PeopleId { get; set; }
        [ForeignKey("PeopleId")]
        public virtual required People People { get; set; }
        public required DateTime Request {  get; set; }
        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public virtual required Managers Managers { get; set; }
    }
}
