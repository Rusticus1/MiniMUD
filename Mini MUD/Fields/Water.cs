using System;
using System.Collections.Generic;
using System.Text;
using Mini_MUD.Life;

namespace Mini_MUD.Fields
{
    class Water : Field
    {
     
        public Water(string roomName, string description) : base(roomName, description)
        {
            
        }
        public override bool Enter(Hero hero = null)  //
        {
            hero.Hitpoints -= 1;
            return true;
        }
    }
}
