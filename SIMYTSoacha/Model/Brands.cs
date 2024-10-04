using System.ComponentModel.DataAnnotations;


namespace SIMYTSoacha.Model
{
    public class Brands
    {
        [Key]
        public int BrandsId { get; set; }
        public required string BrandsName { get; set; }
        public required string Line { get; set; }
}
}
