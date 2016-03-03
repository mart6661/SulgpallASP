using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Result
    {
       public int ResultId { get; set; }
       public string MatchResults { get; set; }

        public virtual List<Match> Matches { get; set; } 
    }
}
