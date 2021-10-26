using Newtonsoft.Json;

namespace FriendsCheckerV2.Models
{
    public class Context
    {
        [JsonProperty("friends")]
        public DashUser[] Friends { get; set; }
    }
}
