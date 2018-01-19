namespace Battlelog.Models
{
    public class UserInfo
    {
        public string userId { get; set; }
        public string location { get; set; }
        public string presentation { get; set; }
        public int? loginCounter { get; set; }
        public long? lastLogin { get; set; }
    }
}