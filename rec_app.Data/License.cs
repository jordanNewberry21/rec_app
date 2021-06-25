using System;
using System.Collections.Generic;

#nullable disable

namespace rec_app.Data
{
    public partial class License
    {
        public License()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        public int Id { get; set; }
        public string License1 { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
