using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD
{
    class Door : Field
    {      
        public ItemUseable Key { get; set; }
        public bool Unlocked { get; set; }
        public Door(string roomName, string description) : base(roomName, description)
        {
            this.Unlocked = false;
        }//hero cant enter and will be returned to previous room
        public override bool Enter()
        {
            //if hero hat schlüssel true sonst false, aber dann brauch ich den hero

            return this.Unlocked;  // ! bedeutet gegenteil
        }
        public void AddItemUseable(ItemUseable item)
        {
            this.ItemUseable = item;
        }
    }
}
