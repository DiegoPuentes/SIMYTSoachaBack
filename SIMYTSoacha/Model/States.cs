using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("States")]
    public class States
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }
        [MaxLength(50)]
        public required string StatesName { get; set; }
    }
}
