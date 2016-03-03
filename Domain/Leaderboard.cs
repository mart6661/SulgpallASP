using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Leaderboard
    {
        public int LeaderboardId { get; set; }
        
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}
