using System;
using System.Collections.Generic;

#nullable disable

namespace rec_app.Data
{
    public partial class Rating
    {
        public Rating()
        {
            Books = new HashSet<Book>();
            Movies = new HashSet<Movie>();
            Restaurants = new HashSet<Restaurant>();
            Stores = new HashSet<Store>();
            TvShows = new HashSet<TvShow>();
        }

        public int Id { get; set; }
        public int? RatingNumber { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<TvShow> TvShows { get; set; }
    }
}
