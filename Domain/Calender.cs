using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Calender
    {
   
       public int CalenderId { get; set; }

        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }

        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
      
    }
}
