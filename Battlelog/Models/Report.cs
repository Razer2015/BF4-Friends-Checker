using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Battlelog.Models
{
    public class Report
    {
        public int Round { get; set; }
        public ulong reportId { get; set; }
        public bool reportIdVerified { get; set; }
        public double version { get; set; }

        [XmlIgnore]
        public DateTime createdAt { get; set; }
        [XmlElement("createdAt")]
        public string createdAtString
        {
            get { return this.createdAt.ToString("yyyy-MM-dd HH:mm:ss"); }
            set
            {
                DateTime date;
                if (DateTime.TryParse(value, out date))
                    this.createdAt = date;
            }
        }

        public List<Stats> Stats { get; set; }

        public Report()
        {
            Stats = new List<Stats>();
        }
    }
}