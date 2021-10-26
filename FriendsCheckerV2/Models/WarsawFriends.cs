using Newtonsoft.Json;

namespace FriendsCheckerV2.Models
{
    public class WarsawFriends
    {
        [JsonProperty("template")]
        public string Template { get; set; }
        [JsonProperty("context")]
        public Context Context { get; set; }
    }
}