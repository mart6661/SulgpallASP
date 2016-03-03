using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public DateTime BirthDateTime { get; set; }
        public string Email { get; set; }
        public string Commentar { get; set; }

        public int PlayerTypeId { get; set; }
        public PlayerType PlayerType { get; set; }

        public virtual List<Competition> Competitions { get; set; } 
        public virtual List<Leaderboard> Leaderboards { get; set; } 

        public virtual List<Commentar> Commentars { get; set; }

        public virtual List<Messageboard> Messageboards { get; set; }
        
        public virtual List<Match> Matches { get; set; } 
     
    }
    }

