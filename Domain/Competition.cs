using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Competition
    {
        public int CompetitionId { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Info { get; set; }

        [MaxLength(128)]
        public string Organizer { get; set; }
        public DateTime DateTime { get; set; }
        public int Spots { get; set; }

        [MaxLength(128)]
        public string Referee { get; set; }


       public virtual List<Calender> Calenders { get; set; } 

        public int PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
