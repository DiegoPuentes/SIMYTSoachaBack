using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Managers")]
    public class Managers
    {
        [Key]
        public int ManagersId { get; set; }
        public int PeopleId { get; set; }
        public int UserTypeXPermission { get; set; }

    }
}
