using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("UsersXPermissions")]
    public class UsersXPermissions
    {
        public int UtypeId { get; set; }
        [ForeignKey("UtypeId")]
        public virtual required UsersTypes UsersType { get; set; }
        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public virtual required Permissions Permissions { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
