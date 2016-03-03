using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class PlayerType
    {
       public int PlayerTypeId { get; set; }
       public string Name { get; set; }
       public string Commentar { get; set; }

        public virtual List<Player> Players { get; set; } 

    }
}
