using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCDemo.DataAccess
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<MovieCastMemberJunction> CastMemberJunctions { get; set; }
    }
}
