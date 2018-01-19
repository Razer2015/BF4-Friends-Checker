using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battlelog.Models
{
    public class GeneralStats
    {
        public string personaId { get; set; }
        public int platformInt { get; set; }
        public Stats generalStats { get; set; }
        public string statsTemplate { get; set; }
        public bool mySoldier { get; set; }
    }
}