using Battlelog.Models.GameModes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Battlelog.Models
{
    public class Snapshot
    {
        public string status { get; set; }
        public long gameId { get; set; }
        public string gameMode { get; set; }
        public int mapVariant { get; set; }
        public string currentMap { get; set; }
        public string currentLevel { get; set; }
        public int maxPlayers { get; set; }
        public int waitingPlayers { get; set; }
        public int roundTime { get; set; }
        public int? roundTimeFull { get; set; }
        public int? roundStartTime { get; set; }
        public int defaultRoundTimeMultiplier { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CarrierAssault carrierAssault { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> gunmaster { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Deathmatch deathmatch { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CaptureTheFlag captureTheFlag { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Conquest conquest { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Rush rush { get; set; }

        public Dictionary<string, TeamInfo> teamInfo { get; set; }
        public Snapshot() {
            teamInfo = new Dictionary<string, TeamInfo>();
        }

        public Snapshot(Snapshot snap) {
            this.status = snap.status;
            this.gameId = snap.gameId;
            this.gameMode = snap.gameMode;
            this.mapVariant = snap.mapVariant;
            this.currentMap = snap.currentMap;
            this.currentLevel = snap.currentLevel;
            this.maxPlayers = snap.maxPlayers;
            this.waitingPlayers = snap.waitingPlayers;
            this.roundTime = snap.roundTime;
            this.defaultRoundTimeMultiplier = snap.defaultRoundTimeMultiplier;
            this.carrierAssault = (snap.carrierAssault == null) ? null : new CarrierAssault(snap.carrierAssault);
            this.gunmaster = (snap.gunmaster == null) ? null : new Dictionary<string, object>(snap.gunmaster);
            this.deathmatch = (snap.deathmatch == null) ? null : new Deathmatch(snap.deathmatch);
            this.captureTheFlag = (snap.captureTheFlag == null) ? null : new CaptureTheFlag(snap.captureTheFlag);
            this.conquest = (snap.conquest == null) ? null : new Conquest(snap.conquest);
            this.rush = (snap.rush == null) ? null : new Rush(snap.rush);
            this.teamInfo = snap.teamInfo;
        }

        public Dictionary<string, Players> CombineTeams() {
            if (this.teamInfo.ContainsKey("0") && this.teamInfo.ContainsKey("1") && this.teamInfo.ContainsKey("2")) {
                var d1 = this.teamInfo["0"].players;
                var d2 = this.teamInfo["1"].players;
                var d3 = this.teamInfo["2"].players;
                var result = d1.Concat(d2).Concat(d3).GroupBy(d => d.Key).ToDictionary(d => d.Key, d => d.First().Value);
                return (result);
            }
            return (null);
        }
    }
}