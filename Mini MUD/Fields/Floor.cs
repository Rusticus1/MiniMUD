using System;
using System.Collections.Generic;
using System.Text;
using Mini_MUD.Life;

namespace Mini_MUD.Fields
{
    public class Floor : Field  //nur hier kann es random items geben
    {     
        public Floor(string roomName, string description) : base(roomName, description)
        {
            this.RandomItemConsumable();
        }
        public override bool Enter(Hero hero = null) //auch wenn ich irgendwo programmiert habe und noch nichts eingegeben habe funktionierts trotzdem
        {
            return true;
        }
    
        public void RandomItemConsumable()
        {
            var randomNumber = new Random();
            var randomItem = randomNumber.Next(0, 5);
            if(randomItem == 1)
            {
                ItemConsumable bread = new ItemConsumable("dry bread", 4, ItemType.FOOD);
                this.ItemConsumable = bread;
                
            }
            else if(randomItem == 2)
            {
                ItemConsumable meat = new ItemConsumable("meat jerky", 8, ItemType.FOOD);
                this.ItemConsumable = meat;
            }
        
          
        }

    }
}
