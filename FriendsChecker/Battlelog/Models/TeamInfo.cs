using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battlelog.Models
{
    public class TeamInfo
    {
        public int faction { get; set; }
        public Dictionary<string, Players> players { get; set; }
        public TeamInfo()
        {
            players = new Dictionary<string, Players>();
        }
    }
}