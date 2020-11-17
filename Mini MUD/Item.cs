using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD
{
    public class Item
    {
        public string Name { get; set; }       
        public int Weight { get; set; }

        public Item(string name)
        {
            this.Name = name;
            this.Weight = 1;
        }
    }
}
