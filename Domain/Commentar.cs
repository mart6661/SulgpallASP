using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Commentar
    {
       public int CommentarId { get; set; }
       public string BoardCommentar { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int MessageboardId { get; set; }
        public virtual Messageboard Messageboard { get; set; }

    }
}
