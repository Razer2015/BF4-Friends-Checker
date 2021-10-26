using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Battlelog.Models
{
    
    public class WarsawStats
    {
        public class Context
        {
            public class Club
            {
                public string tag { get; set; }
            }

            public Club club { get; set; }
            public ulong personaId { get; set; }
            public string personaName { get; set; }
            public User user { get; set; }
        }

        public Context context { get; set; }
    }
}