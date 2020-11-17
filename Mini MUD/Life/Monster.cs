using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Life
{
    public class Monster : ICreature
    {
        public string Name { get; set; }
        public int Hitpoints { get; set; }
        public int BaseDamage { get; set; }
        public Field Field { get; set; }
        public Monster(string name, int hitpoints)
        {
            this.Name = name;
            this.Hitpoints = hitpoints;
            this.BaseDamage = 3;
        }
        public void Attacking()
        {

        }
    }
}
