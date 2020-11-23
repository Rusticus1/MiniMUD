using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Life
{
    class Warrior : Hero
    {
        public Warrior(string name, int hitpoints, int baseDamage, int startArmor, List<Field> fieldlist, Field startfield) : base(name, hitpoints, baseDamage, startArmor, fieldlist, startfield)
        {

        }
    }
}
