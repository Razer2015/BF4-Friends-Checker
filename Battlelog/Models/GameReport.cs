using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battlelog.Models
{
    public class GameReport
    {
        public string persistedId { get; set; }
        public string map { get; set; }
        public int? winner { get; set; }
        public int? maxPlayerCount { get; set; }
        public Dictionary<int, string> teamToFaction { get; set; }
        public int? mapVariant { get; set; }
        public int? serverType { get; set; }
        public string gameMode { get; set; }
        public Dictionary<int, Team> teams { get; set; }
        public Dictionary<int, InitialMapValues> initialMapValues { get; set; }
        // TODO: players
        public Player player { get; set; }
        public bool? ranked { get; set; }
        public Dictionary<int, string[]> playerTeams { get; set; }
        public MapModeResult mapModeResult { get; set; }
        public int? duration { get; set; }
        public string reportType { get; set; }
        public string gameReportId { get; set; }
        public int? createdAt { get; set; }
        public string name { get; set; }
    }
}
