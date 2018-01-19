namespace Battlelog.Models
{
    public class User
    {
        public string username { get; set; }
        public string gravatarMd5 { get; set; }
        public string userId { get; set; }
        public int? createdAt { get; set; }
        public Presence presence { get; set; }

        // Added by myself
        public ulong? personaId { get; set; }
        public string ClanTag { get; set; }
    }
}