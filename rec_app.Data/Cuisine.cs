using System;
using System.Collections.Generic;

#nullable disable

namespace rec_app.Data
{
    public partial class Cuisine
    {
        public Cuisine()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
