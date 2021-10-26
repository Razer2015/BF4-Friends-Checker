using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battlelog.Models.GameModes
{
    public class Rush
    {
        public RoundInfo defenders { get; set; }
        public RoundInfo attackers { get; set; }

        public Rush() {

        }

        public Rush(Rush rush) {
            this.defenders = (rush.defenders == null) ? null : new RoundInfo(rush.defenders);
            this.attackers = (rush.attackers == null) ? null : new RoundInfo(rush.attackers);
        }
    }
}