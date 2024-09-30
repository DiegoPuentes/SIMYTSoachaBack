using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("People")]
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        public required string Names { get; set; }
        public required string Lnames { get; set; }
        public int DtypeId {  get; set; }
        public required string Ndocument { get; set; }
        public required string Sex {  get; set; }
        public DateTime DateBirth { get; set; }
        public int UserTypeXPermission { get; set; }
        public bool IsDeleted { get; set; } = false;
        
    }
}
