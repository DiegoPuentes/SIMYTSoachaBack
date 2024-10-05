using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Histories")]
    public class Histories
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistorieId { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public required string Lname { get; set; }
        public int DtypeId { get; set; }
        [MaxLength(2)]
        public required int SexId { get; set; }
        public DateTime DateBirth { get; set; }
        public int UtypeId { get; set; }
        public required string UserName {  get; set; }
        public required string Password { get; set; }
        public DateTime ModifyDate {  get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
