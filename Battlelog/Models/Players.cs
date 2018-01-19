using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Battlelog.Models
{
    public class Players
    {
        public string name { get; set; }
        public string tag { get; set; }
        public int rank { get; set; }
        public int score { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int squad { get; set; }
        public int role { get; set; }

        public string guid { get; set; }
        public string kit { get; set; }
        public int? teamkills { get; set; }
        public int? sscore { get; set; }
        public int? skills { get; set; }
        public int? sdeaths { get; set; }
        public int? steamkills { get; set; }
        public int? ping { get; set; }
        public int? jointime { get; set; }
        public int? sessiontime { get; set; }
        public int? lastswitch { get; set; }
        public bool alive { get; set; }
        public int? alivetime { get; set; }

        [JsonIgnore]
        public Stopwatch aliveTimer { get; set; }
        [JsonIgnore]
        public Task aliveChecker { get; set; }

        public Players() {

        }

        public Players(bool init) {
            if (init) {
                guid = "";
                kit = "";
                teamkills = 0;
                sscore = 0;
                skills = 0;
                sdeaths = 0;
                steamkills = 0;
                ping = 0;
                jointime = Battlelog.BattlelogClient.GetEpochSeconds(DateTime.UtcNow);
                sessiontime = 0;
                alive = false;
                alivetime = 0;
                aliveTimer = new Stopwatch();
            }
        }
    }
}