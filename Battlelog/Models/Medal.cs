namespace Battlelog.Models
{
    public class Medal
    {
        public double? timesTaken { get; set; }
        public double? actualValue { get; set; }
        public double? valueNeeded { get; set; }

        public int ActualCount { get; set; }

        public void Count() {
            if(timesTaken != null && actualValue != null && valueNeeded != null) {
                this.ActualCount = ((int)this.timesTaken * (int)this.valueNeeded) + (int)this.actualValue;
            }
            else if(actualValue != null && valueNeeded != null)
                this.ActualCount = (int)this.actualValue;
        }
    }
}