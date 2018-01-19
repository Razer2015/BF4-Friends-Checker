namespace Battlelog.Models
{
    public class Reservation
    {
        public string gameId { get; set; }
        public string userId { get; set; }
        public string invitePersona { get; set; }
        public int? game { get; set; }
        public string sourceGuid { get; set; }
        public string expirationTimeout { get; set; }
        public string personaId { get; set; }
        public bool? voipAllowed { get; set; }
        public int? platform { get; set; }
        public int? role { get; set; }
        public string gameServer { get; set; }
        public string joinState { get; set; }
    }
}
