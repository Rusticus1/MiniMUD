using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD
{
    public class Item
    {
        public string Name { get; set; } 
        public int Value { get; set; }
       

        public Item(string name, int value)
        {
            this.Name = name;
            this.Value = value;
      
        }
    }
}
