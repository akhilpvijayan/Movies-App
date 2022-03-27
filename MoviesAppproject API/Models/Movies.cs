using System;
using System.Collections.Generic;

namespace MoviesAppproject.Models
{
    public partial class Movies
    {
        public Movies()
        {
            Reviews = new HashSet<Reviews>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDesc { get; set; }
        public DateTime? MovieRelease { get; set; }
        public string TitleImage { get; set; }
        public string CoverImage { get; set; }
        public string MovieLang { get; set; }
        public string MovieGenre { get; set; }
        public bool Isactive { get; set; }

        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
