using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Histories")]
    public class Histories
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistorieId { get; set; }
        public int PeopleId { get; set; }
        public required string Fnames { get; set; }
        public required string Lname { get; set; }
        public int DtypeId { get; set; }
        public required string Ndocument { get; set; }
        public int SexId { get; set; }
        public DateTime DateBirth { get; set; }
        public int UtypeId { get; set; }
        public required string UserName {  get; set; }
        public required string Passcode { get; set; }
        public DateTime ModifyDate {  get; set; }
        public required string ModifyBy {  get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
