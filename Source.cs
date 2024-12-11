using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApplication
{
    internal class Source
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        public Source(int  id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
