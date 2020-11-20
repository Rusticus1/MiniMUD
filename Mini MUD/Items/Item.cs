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
        SCROLL,
        SPELL,
        VICTORY,
    }
    public abstract class Item
    {
        public string Name { get; set; } 
        public int Value { get; set; }
        public ItemType ItemType { get; set; }
        public Item(string name, int value, ItemType itemType)
        {
            this.Name = name;
            this.Value = value;
            this.ItemType = itemType;
        }

        //public abstract void consume();

    }
}
