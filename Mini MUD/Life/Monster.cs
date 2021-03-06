﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Life
{
    public class Monster : ICreature
    {
        public string Name { get; set; }
        public int Hitpoints { get; set; }
        public int BaseDamage { get; set; }
        public Item Item { get; set; }
        public Field Field { get; set; }
        public Monster(string name, int hitpoints, int baseDamage, Field startfield, Item itemdrop)
        {
            this.Name = name;
            this.Hitpoints = hitpoints;
            this.BaseDamage = baseDamage;
            this.Field = startfield;
            this.Item = itemdrop;
            
        }    
        public void AddItemToInventory(Item item)
        {
            this.Item = item;
        }
    }
}
