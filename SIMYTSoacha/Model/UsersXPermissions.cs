﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("UsersXPermissions")]
    public class UsersXPermissions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UpermissionId { get; set; }
        public int UtypeId { get; set; }
        [ForeignKey("UtypeId")]
        public virtual required UsersTypes UsersType { get; set; }
        public int PermissionId { get; set; }
        [ForeignKey("Permission")]
        public virtual required Permissions Permissions { get; set; }
    }
}
