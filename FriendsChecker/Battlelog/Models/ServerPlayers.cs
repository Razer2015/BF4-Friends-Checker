using System.Collections.Generic;

namespace Battlelog.Models
{
    public class ServerPlayers
    {
        public ulong mapMode { get; set; }
        public uint players { get; set; }
        public Dictionary<uint, ServerPlayerSlots> slots { get; set; }
        public uint queued { get; set; }
        public string map { get; set; }
    }

    public class ServerPlayerSlots
    {
        public uint current { get; set; }
        public uint max { get; set; }
    }
}