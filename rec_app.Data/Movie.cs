using System;
using System.Collections.Generic;

#nullable disable

namespace rec_app.Data
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? Watched { get; set; }
        public string RecommendedBy { get; set; }
        public int? Rating { get; set; }
        public int Genre { get; set; }
        public bool? WouldRecommend { get; set; }

        public virtual Genre GenreNavigation { get; set; }
        public virtual Rating RatingNavigation { get; set; }
    }
}
