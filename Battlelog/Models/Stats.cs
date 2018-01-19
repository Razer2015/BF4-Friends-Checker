using System;

namespace Battlelog.Models
{
    public class Stats : ICloneable
    {
        public string personaID { get; set; }
        public string soldierName { get; set; }
        public bool? dnf { get; set; }
        public double? version { get; set; }
        public uint matchId { get; set; }

        #region Kit rankings
        public uint assault { get; set; }
        public uint engineer { get; set; }
        public uint support { get; set; }
        public uint recon { get; set; }
        public uint commander { get; set; }
        #endregion

        #region Kit item rankings
        public uint heals { get; set; }
        public uint revives { get; set; }
        public uint repairs { get; set; }
        public uint resupplies { get; set; }
        #endregion

        #region General Rankings
        #region Stats
        public uint score { get; set; }
        public uint totalScore { get; set; }
        public uint rankScore { get; set; }
        public uint combatScore { get; set; }
        public uint scorePerMinute { get; set; }
        public uint rush { get; set; }
        public uint timePlayed { get; set; }
        public uint numRounds { get; set; }
        public uint numLosses { get; set; }
        public uint numWins { get; set; }
        public uint dogtagsTaken { get; set; }
        #endregion

        #region Kills
        public uint avengerKills { get; set; }
        public uint kills { get; set; }
        public uint deaths { get; set; }
        public uint kills_assault { get; set; }
        public uint assaultRifleKills { get; set; }
        public uint kills_engineer { get; set; }
        public uint PDWKills { get; set; }
        public uint kills_recon { get; set; }
        public uint sniperRifleKills { get; set; }
        public uint kills_support { get; set; }
        public uint LMGKills { get; set; }
        public uint mcomDefendKills { get; set; }
        public uint saviorKills { get; set; }
        public uint nemesisKills { get; set; }
        public string kdRatio { get; set; }
        public string killsPerMinute { get; set; }
        #endregion

        #region Accuracy
        public uint headshots { get; set; }
        public uint assaultRifleHeadshots { get; set; }
        public uint sniperRifleHeadshots { get; set; }
        public uint LMGHeadshots { get; set; }
        public uint PDWHeadshots { get; set; }
        public uint shotsFired { get; set; }
        public uint shotsHit { get; set; }
        #endregion

        #region Assists
        public uint killAssists { get; set; }
        public uint suppressionAssists { get; set; }
        #endregion

        #region Vehicle
        public uint vehicleDamage { get; set; }
        public uint vehiclesDestroyed { get; set; }
        #endregion
        #endregion

        public string rank { get; set; }

        public object Clone() {
            return new Stats {
                personaID = this.personaID,
                soldierName = this.soldierName,

                #region Kit rankings
                assault = this.assault,
                engineer = this.engineer,
                support = this.support,
                recon = this.recon,
                commander = this.commander,
                #endregion

                #region Kit item rankings
                heals = this.heals,
                revives = this.revives,
                repairs = this.repairs,
                resupplies = this.resupplies,
                #endregion

                #region General Rankings
                #region Stats
                score = this.score,
                totalScore = this.totalScore,
                rankScore = this.rankScore,
                combatScore = this.combatScore,
                rush = this.rush,
                timePlayed = this.timePlayed,
                numRounds = this.numRounds,
                numLosses = this.numLosses,
                numWins = this.numWins,
                dogtagsTaken = this.dogtagsTaken,
                #endregion

                #region Kills
                avengerKills = this.avengerKills,
                kills = this.kills,
                deaths = this.deaths,
                kills_assault = this.kills_assault,
                assaultRifleKills = this.assaultRifleKills,
                kills_engineer = this.kills_engineer,
                PDWKills = this.PDWKills,
                kills_recon = this.kills_recon,
                sniperRifleKills = this.sniperRifleKills,
                kills_support = this.kills_support,
                LMGKills = this.LMGKills,
                mcomDefendKills = this.mcomDefendKills,
                saviorKills = this.saviorKills,
                nemesisKills = this.nemesisKills,
                #endregion

                #region Accuracy
                headshots = this.headshots,
                assaultRifleHeadshots = this.assaultRifleHeadshots,
                sniperRifleHeadshots = this.sniperRifleHeadshots,
                LMGHeadshots = this.LMGHeadshots,
                PDWHeadshots = this.PDWHeadshots,
                shotsFired = this.shotsFired,
                shotsHit = this.shotsHit,
                #endregion

                #region Assists
                killAssists = this.killAssists,
                suppressionAssists = this.suppressionAssists,
                #endregion

                #region Vehicle
                vehicleDamage = this.vehicleDamage,
                vehiclesDestroyed = this.vehiclesDestroyed
                #endregion
                #endregion
            };
        }
    }
}
