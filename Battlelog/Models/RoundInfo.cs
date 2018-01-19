using Newtonsoft.Json;

namespace Battlelog.Models
{
    public class RoundInfo
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? team { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? bases { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? basesMax { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? attacker { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? tickets { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ticketsMax { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? flagsMax { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? roundTimeMax { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? flags { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? kills { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? killsMax { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? destroyedCrates { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? carrierHealth { get; set; }

        public RoundInfo() {

        }

        public RoundInfo(RoundInfo rInfo) {
            this.team = rInfo.team;
            this.bases = rInfo.bases;
            this.basesMax = rInfo.basesMax;
            this.attacker = rInfo.attacker;
            this.tickets = rInfo.tickets;
            this.ticketsMax = rInfo.ticketsMax;
            this.flagsMax = rInfo.flagsMax;
            this.roundTimeMax = rInfo.roundTimeMax;
            this.flags = rInfo.flags;
            this.kills = rInfo.kills;
            this.killsMax = rInfo.killsMax;
            this.destroyedCrates = rInfo.destroyedCrates;
            this.carrierHealth = rInfo.carrierHealth;
        }
    }
}