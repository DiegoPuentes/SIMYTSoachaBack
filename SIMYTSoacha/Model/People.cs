﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("People")]
    public class People
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeopleId { get; set; }
        public required string Names { get; set; }
        public required string Lnames { get; set; }
        public int DtypeId {  get; set; }
        [ForeignKey("DtypeId")]
        public virtual DocumentsTypes DocumentType { get; set; }
        public required string Ndocument { get; set; }
        public required string Sex {  get; set; }
        public DateTime DateBirth { get; set; }
        public int UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        public virtual UsersTypes UserType { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
