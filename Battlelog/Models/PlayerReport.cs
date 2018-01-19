namespace Battlelog.Models
{
    /// <summary>
    /// Unfinished
    /// </summary>
    public class PlayerReport
    {
        public string personaId { get; set; }
        public Persona persona { get; set; }
        //public Stats stats { get; set; }
        //public Unlocks unlocks { get; set; }
        //public RankInfo rankInfo { get; set; }
        public User user { get; set; }
        // TODO: scores
        //public Best best { get; set; }
    }
}