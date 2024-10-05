using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Vehicles")]
    public class Vehicles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public required virtual Brands Brand { get; set; }
        public int ColorId { get; set; }
        [ForeignKey("ColorId ")]
        public required virtual Colors Color { get; set; }
        public required string Nmotor { get; set; }
        public int PeopleId { get; set; }
        [ForeignKey("PeopleId ")]
        public required virtual People People { get; set; }
        public required string Echasis { get; set; }
        public int MlineId { get; set; }
        [ForeignKey("MlineId")]
        public required virtual Models Models { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
