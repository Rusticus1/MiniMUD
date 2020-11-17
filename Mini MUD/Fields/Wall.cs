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
        public override bool Enter()
        {   
            //if player has key true  else false
            return false;
        }
    }
}
