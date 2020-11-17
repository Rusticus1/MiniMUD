using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Fields
{
    class Water : Field
    {
     
        public Water(string roomName, string description) : base(roomName, description)
        {
          
        }
        public override bool Enter() //enter methode bool?
        {
            return true;
        }
    }
}
