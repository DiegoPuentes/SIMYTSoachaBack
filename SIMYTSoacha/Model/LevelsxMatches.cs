using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("LevelsxMatches")]
    public class LevelsxMatches
    {
        public int LevelId { get; set; }
        [ForeignKey("LevelId")]
        public virtual required Levels Levels { get; set; }
        public int MatchId { get; set; }
        [ForeignKey("MatchId")]
        public virtual required Matches Matchs { get; set; }
        public int Scored {  get; set; }
        public required bool IsDeleted { get; set; }
    }
}
