using System;
using System.Collections.Generic;
using System.Text;

namespace MVCDemo.DataAccess
{
    public class CastMember
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieCastMemberJunction> MovieJunctions { get; set; }
    }
}
