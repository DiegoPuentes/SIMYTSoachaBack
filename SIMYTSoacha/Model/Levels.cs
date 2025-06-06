﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("Levels")]
    public class Levels
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }  
        public required bool IsDeleted { get; set; }
    }
}
