using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Life
{
    class Mage : Hero
    {
        public List<Item> Spellbook { get; set; }
        public Mage(string name, int hitpoints, int mana, int baseDamage, List<Item> spellbook, List<Field> fieldlist, Field startfield) : base(name, hitpoints, mana, baseDamage, fieldlist, startfield)
        {
            this.Spellbook = spellbook;
        }
    }
}
