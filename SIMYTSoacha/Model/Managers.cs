using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Managers")]
    public class Managers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManagersId { get; set; }
        public int PeopleId { get; set; }
        [ForeignKey("PeopleId")]
        public virtual required People People { get; set; }
        public int UserTypeXPermissionId { get; set; }
        [ForeignKey("UserTypeXPermissionId")]
        public virtual required UsersXPermissions UsersXPermissions { get; set; }
    }
}
