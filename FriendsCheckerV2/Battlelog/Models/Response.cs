﻿using Newtonsoft.Json;

namespace FriendsCheckerV2.Battlelog.Models
{
    public class Response<T>
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}