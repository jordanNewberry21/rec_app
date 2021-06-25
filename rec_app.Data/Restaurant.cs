using System;
using System.Collections.Generic;

#nullable disable

namespace rec_app.Data
{
    public partial class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Visited { get; set; }
        public string RecommendedBy { get; set; }
        public int CuisineType { get; set; }
        public int? Rating { get; set; }
        public int Drinks { get; set; }
        public bool? Delivery { get; set; }

        public virtual Cuisine CuisineTypeNavigation { get; set; }
        public virtual License DrinksNavigation { get; set; }
        public virtual Rating RatingNavigation { get; set; }
    }
}
