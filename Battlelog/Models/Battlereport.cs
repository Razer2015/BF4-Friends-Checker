using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battlelog.Models
{
    /// <summary>
    /// Unfinished
    /// </summary>
    public class Battlereport
    {
        public PlayerReport playerReport { get; set; }
        public string id { get; set; }
        public string gameMode { get; set; }
        public Dictionary<int, Team> teams { get; set; }
        public Dictionary<string, Player> players { get; set; }
        public GameServer gameServer { get; set; }
        public long duration { get; set; }
        public long createdAt { get; set; }

        public int GetWinner() {
            if (teams.ContainsKey(1) && teams.ContainsKey(2)) {
                var attacker = false;
                var defender = false;

                if (teams[1].isAttacker.Equals(1)) {
                    if (teams[1].isWinner.Equals(true))
                        attacker = true;
                }
                if (teams[2].isAttacker.Equals(0)) {
                    if (teams[2].isWinner.Equals(true))
                        defender = true;
                }

                if (attacker && !defender)
                    return (1);
                else if (!attacker && defender)
                    return (2);
                else if (attacker && defender)
                    return (3);
                else
                    return (0);
            }
            return (-1);
        }
    }
}
