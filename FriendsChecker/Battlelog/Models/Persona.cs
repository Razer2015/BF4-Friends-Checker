using System.Collections.Generic;

namespace Battlelog.Models
{
    public class Persona
    {
        public string picture { get; set; }
        public string userId { get; set; }
        public User user { get; set; }
        public int updatedAt { get; set; }
        public string firstPartyId { get; set; }
        public string personaId { get; set; }
        public string personaName { get; set; }
        public string gamesLegacy { get; set; }
        public string @namespace { get; set; }
        public string gamesJson { get; set; }
        public Dictionary<int, string> games { get; set; }
        public string clanTag { get; set; }
    }
}