using Newtonsoft.Json;

namespace FriendsCheckerV2.Models
{
    public class DashUser
    {
        [JsonProperty("emblemUrl")]
        public string EmblemUrl { get; set; }
        [JsonProperty("presence")]
        public Presence Presence { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("info")]
        public Info Info { get; set; }
        [JsonProperty("personaId")]
        public string PersonaId { get; set; }
        [JsonProperty("isLightWeight")]
        public bool IsLightWeight { get; set; }
        [JsonProperty("isPartyMember")]
        public bool IsPartyMember { get; set; }
        [JsonProperty("isExternalUser")]
        public bool IsExternalUser { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
