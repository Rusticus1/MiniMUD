using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Fields
{
    class Wall : Field
    {
        
        public Wall(string roomName, string description) : base(roomName, description)
        {
         
        }
        public override bool Enter(Hero hero = null) //auch wenn ich irgendwo programmiert habe und noch nichts eingegeben habe funktionierts trotzdem
        {   
            //if player has key true  else false
            return false;
        }
    }
}
