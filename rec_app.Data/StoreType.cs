using System;
using System.Collections.Generic;

#nullable disable

namespace rec_app.Data
{
    public partial class StoreType
    {
        public StoreType()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
