using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Fields
{
    public class Floor : Field  //nur hier kann es random items geben
    {     
        public Floor(string roomName, string description) : base(roomName, description)
        {
            
        }
        public override bool Enter() //enter/move methode zum Hero?
        {
            return true;
        }
    
        public Item RandomItem()
        {
            var random = new Random();
            var randomItem = random.Next(1, 10);
            if(randomItem == 1)
            {
                ItemConsumable bread = new ItemConsumable("bread");
                return bread;
            }
            return null;
        }

    }
}
