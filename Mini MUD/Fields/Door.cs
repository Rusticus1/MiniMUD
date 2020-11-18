using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD
{
    class Door : Field
    {      
        public Item Key { get; set; }
        public Door(string roomName, string description, Item key) : base(roomName, description)
        {
            this.Key = key;
        }//hero cant enter and will be returned to previous room
        public override bool Enter()
        {
            //if hero hat schlüssel true sonst false, aber dann brauch ich den hero

            return false;
        }
    }
}
