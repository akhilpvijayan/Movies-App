using System;
using System.Collections.Generic;

namespace MoviesAppproject.Models
{
    public partial class Reviews
    {
        public int Reviewid { get; set; }
        public int? Movieid { get; set; }
        public string Review { get; set; }

        public virtual Movies Movie { get; set; }
    }
}
