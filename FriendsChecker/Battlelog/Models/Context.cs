namespace Battlelog.Models
{
    public class Context
    {
        public Persona[] profilePersonas { get; set; }
        public Friend[] friends { get; set; }
        public ProfileCommon profileCommon { get; set; }
    }
}