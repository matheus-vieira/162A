using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Registration
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}