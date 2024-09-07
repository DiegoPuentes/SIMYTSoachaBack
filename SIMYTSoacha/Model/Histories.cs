using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Histories")]
    public class Histories
    {
        [Key]
        public int HistorieId { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Lname { get; set; }
        public int DtypeId { get; set; }
        [MaxLength(2)]
        public string Sex { get; set; }
        public DateTime DateBirth { get; set; }
        public int UtypeId { get; set; }
        public DateTime ModifyDate {  get; set; }
    }
}
