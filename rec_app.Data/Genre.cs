using System;
using System.Collections.Generic;

#nullable disable

namespace rec_app.Data
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
            Movies = new HashSet<Movie>();
            TvShows = new HashSet<TvShow>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<TvShow> TvShows { get; set; }
    }
}
