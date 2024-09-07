using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("States")]
    public class States
    {
        [Key]
        public int StateId { get; set; }
        [MaxLength(50)]
        public string? StatesName { get; set; }
    }
}
