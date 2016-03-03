using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Match
    {
       public int MatchId { get; set; }
       public string Name { get; set; }
       public int Players { get; set; }
       public string Password { get; set; }
       public string Description { get; set; }
       public DateTime DateTime { get; set; }

        public virtual List<Calender> Calenders { get; set; } 
        public virtual List<Messageboard> Messageboards { get; set; }
        
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        
        public int ResultId { get; set; }
        public virtual Result Result { get; set; } 


    }
}
