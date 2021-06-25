using System;
using System.Collections.Generic;

#nullable disable

namespace rec_app.Data
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Visited { get; set; }
        public string RecommendedBy { get; set; }
        public int StoreType { get; set; }
        public int? Rating { get; set; }
        public bool? WouldRecommend { get; set; }

        public virtual Rating RatingNavigation { get; set; }
        public virtual StoreType StoreTypeNavigation { get; set; }
    }
}
