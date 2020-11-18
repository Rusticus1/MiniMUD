using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Fields
{
    public class Floor : Field  //nur hier kann es random items geben
    {     
        public Floor(string roomName, string description) : base(roomName, description)
        {
            this.RandomItemConsumable();
        }
        public override bool Enter() //enter/move methode zum Hero?
        {
            return true;
        }
    
        public void RandomItemConsumable()
        {
            var randomNumber = new Random();
            var randomItem = randomNumber.Next(0, 6);
            if(randomItem == 1)
            {
                ItemConsumable bread = new ItemConsumable("dry bread", 2, ItemType.FOOD);
                this.ItemConsumable = bread;
                
            }
            else if(randomItem == 2)
            {
                ItemConsumable meat = new ItemConsumable("roasted meat (don't ask how it got here)", 5, ItemType.FOOD);
                this.ItemConsumable = meat;
            }
        
          
        }

    }
}
