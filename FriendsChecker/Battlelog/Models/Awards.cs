using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battlelog.Models
{
    public class Awards : ICloneable
    {
        public string personaId { get; set; }
        public string soldierName { get; set; }
        public uint matchId { get; set; }

        public Dictionary<string, Ribbon> ribbonAwardByCode { get; set; }
        public Dictionary<string, Medal> medalAwardByCode { get; set; }

        public object Clone() {
            return new Awards {
                personaId = this.personaId,
                soldierName = this.soldierName,

                ribbonAwardByCode = this.ribbonAwardByCode,
                medalAwardByCode = this.medalAwardByCode,
            };
        }

        public void CountAwards() {
            if (this.ribbonAwardByCode != null && this.ribbonAwardByCode.Count > 0)
                foreach (var ribbon in this.ribbonAwardByCode) {
                    ribbon.Value.Count();
                }
            if (this.medalAwardByCode != null && this.medalAwardByCode.Count > 0)
                foreach (var medal in this.medalAwardByCode) {
                    medal.Value.Count();
                }
        }
    }
}