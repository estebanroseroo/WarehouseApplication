using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApplication
{
    internal class Product
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public Source Source { get; set; }
        public int Stock { get; set; }

        public Product (int id, string name, Source source, int stock)
        {
            Id = id;
            Name = name;
            Source = source;
            Stock = stock;
        }
    }
}
