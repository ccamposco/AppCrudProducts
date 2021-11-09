using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCrudProducts.Models
{
    public class Products
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
