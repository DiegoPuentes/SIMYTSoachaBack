using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Requests")]
    public class Requests
    {
        [Key]
        public int RequestId { get; set; }
        public int PeopleId { get; set; }
        public DateTime? Request {  get; set; }
        public int ManagerId { get; set; }
    }
}
