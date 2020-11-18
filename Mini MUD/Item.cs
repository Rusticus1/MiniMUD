using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD
{
    public enum ItemType
    {
        FOOD,
        WEAPON,
        KEY,
    }
    public class Item
    {
        public string Name { get; set; } 
        public int Value { get; set; }
        public ItemType ItemType { get; internal set; }

        public Item(string name, int value, ItemType itemtype)
        {
            this.Name = name;
            this.Value = value;
            this.ItemType = ItemType;
        }
    }
}
