using System.Collections.Generic;

namespace Battlelog.Models
{
    public class SERVER_INFO
    {
        public string map { get; set; }
        public string gameId { get; set; }
        public ulong[] gameExpansions { get; set; }
        public string mapMode { get; set; }
        public string ip { get; set; }
        public string matchId { get; set; }
        public string protocolVersionString { get; set; }
        public ExtendedInfo extendedInfo { get; set; }
        public int? game { get; set; }
        public int? ranked { get; set; }
        public int? online { get; set; }
        public int? platform { get; set; }
        public int? tickRateMax { get; set; }
        public int? updatedAt { get; set; }
        public Dictionary<uint, ServerPlayerSlots> slots { get; set; }
        public string guid { get; set; }
        public int? port { get; set; }
        public int? punkbuster { get; set; }
        public int? playlist { get; set; }
        public string gameExpansion { get; set; }
        public string name { get; set; }
        public Dictionary<string, int> settings { get; set; }
        public int? fairfight { get; set; }
        public int? region { get; set; }
        public int? mapVariant { get; set; }
        public int? ping { get; set; }
        public int? serverType { get; set; }
        public string experience { get; set; }
        public int? tickRate { get; set; }
        public int? hasPassword { get; set; }
        public Maps maps { get; set; }
        public string secret { get; set; }
        public int? preset { get; set; }
        public string pingSite { get; set; }
        public string country { get; set; }
    }

    public class ExtendedInfo
    {
        public string message { get; set; }
        public string bannerUrl { get; set; }
        public string desc { get; set; }
    }

    public class Maps
    {
        public Map[] maps { get; set; }
        public int? currentMapRound { get; set; }
        public int? nextMapIndex { get; set; }
        public int? currentMapIndex { get; set; }
        public int? numberMapRounds { get; set; }
    }

    public class Map
    {
        public string mapMode { get; set; }
        public string map { get; set; }
        public int? mapVariant { get; set; }
    }
}