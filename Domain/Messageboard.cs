using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Messageboard
    {
        public int MessageboardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public int CompetetionId { get; set; }
        public virtual Competition Competition { get; set; }


        public virtual List<Commentar> Commentars { get; set; } 
    }
}
