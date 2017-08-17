﻿using Models.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Tables
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}