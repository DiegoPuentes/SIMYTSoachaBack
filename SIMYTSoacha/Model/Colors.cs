using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SIMYTSoacha.Model
{
    [Table("Colors")]
    public class Colors
    {
        [Key]

        public int ColorsId { get; set; }
        [MaxLength(50)]

        public string ColorsName { get; set; }
    }
}
