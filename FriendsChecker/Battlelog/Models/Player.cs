namespace Battlelog.Models
{
    /// <summary>
    /// Unsure about the types as well
    /// </summary>
    public class Player
    {
        public int? deaths { get; set; }
        public string userId { get; set; }
        public int? rank { get; set; }
        public int? killAssists { get; set; }
        public int? skill { get; set; }
        public int? heals { get; set; }
        public string personaId { get; set; }
        public bool? dnf { get; set; }
        public bool? firstCrapplingHook { get; set; }
        public int? revives { get; set; }
        public int? commanderScore { get; set; }
        public bool? firstZipline { get; set; }
        public double? accuracy { get; set; }
        public object persona { get; set; }
        public int? kills { get; set; }
        public int? team { get; set; }
        public object user { get; set; }
        public int? killStreak { get; set; }
        public int? combatScore { get; set; }
        public int? squadId { get; set; }
        public int? gunMasterLevel { get; set; }
        public bool? isCommander { get; set; }
        public bool? isSoldier { get; set; }
    }
}