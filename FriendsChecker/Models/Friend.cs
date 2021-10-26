using Battlelog.Models;

namespace BF4_Friends_Checker.Models
{
    public class Friend
    {
        public User user { get; set; }
        public int? friendCount { get; set; }
        public UserInfo userinfo { get; set; }
    }
}
