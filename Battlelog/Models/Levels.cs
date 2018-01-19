using System.Collections.Generic;

namespace Battlelog.Models
{
    public class Levels
    {
        public Dictionary<string, LevelsMetaData> levels { get; set; }
    }

    public class LevelsMetaData
    {
        public ulong[] platforms { get; set; }
        public ulong[] gameModes { get; set; }
        public ulong gameExpansion { get; set; }
        public string id { get; set; }
        public string label { get; set; }
    }
}
