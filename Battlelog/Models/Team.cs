namespace Battlelog.Models
{
    /// <summary>
    /// Lots of unsolved types
    /// </summary>
    public class Team
    {
        public int? tickets { get; set; }
        public int? bags { get; set; }
        public int? titanHealth { get; set; }
        public string name { get; set; }
        public object achievedObjects { get; set; } // TODO: correct the type
        public string[] commanders { get; set; }
        public bool? isWinner { get; set; }
        public int? cash { get; set; }
        public int? cashNeeded { get; set; }
        public string[] players { get; set; }
        public int? score { get; set; }
        public int? scoreMax { get; set; }
        //public Squad squads { get; set; }
        public int? isAttacker { get; set; }
        public int? bagsNeeded { get; set; }
        public int? id { get; set; }
    }
}