using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Model
{
    [Table("LevelsxMatches")]
    public class LevelsxMatches
    {
        public int LevelId { get; set; }
        public virtual required Levels Levels { get; set; }
        public int MatchId { get; set; }
        public virtual required People Matchs { get; set; }
        public int Scored {  get; set; }
        public required bool IsDeleted { get; set; }
    }
}
