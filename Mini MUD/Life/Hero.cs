using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST,
        STATIC,
    }
    public class Hero : ICreature
    {
        public string Name { get; set; }
        public int Hitpoints { get; set; }
        public int HitpointsMax { get; set; }
        //public int Energy { get; set; }
        public int BaseDamage { get; set; }
        public List<Item> Backpack { get; set; }
        public int BackpackMax { get; set; }
        public Field Field { get; set; }
        public List<Field> Fieldlist { get; set; }

        public Hero(string name, int hitpoints, List<Field> fieldlist, Field startfield)
        {
            this.Name = name;
            this.Hitpoints = hitpoints;
            this.HitpointsMax = hitpoints;
            //this.Energy = 10;
            this.BaseDamage = 3;
            this.Fieldlist = fieldlist;
            this.Field = startfield;
            this.Backpack = new List<Item>();
            this.BackpackMax = 6;

        }

        public void Moving(Direction direction) //hier ENTER() Methode!!!!!!!!
        {
            //wenn er den key hat dannn ja sonst nein           
            if (direction == Direction.NORTH)
            {
                if (this.Field.North != null && this.Field.North.Enter())
                {
                    this.Field = this.Field.North;
                    this.Hitpoints -= 1;
                }
            }
            else if (direction == Direction.EAST)
            {
                if (this.Field.East != null && this.Field.East.Enter())
                {
                    this.Field = this.Field.East;
                    this.Hitpoints -= 1;
                }
            }
            else if (direction == Direction.SOUTH)
            {
                if (this.Field.South != null && this.Field.South.Enter())
                {
                    this.Field = this.Field.South;
                    this.Hitpoints -= 1;
                }
            }
            else if (direction == Direction.WEST)
            {
                if (this.Field.West != null && this.Field.West.Enter())
                {
                    this.Field = this.Field.West;
                    this.Hitpoints -= 1;
                }
            }
        }

        public void Attacking()
        {

        }
        public void TakeItemConsumable()
        {
            if (this.Field.ItemConsumable != null)
            {
                this.Backpack.Add(this.Field.ItemConsumable);
                Console.WriteLine(this.Field.ItemConsumable.Name + " taken and stored in your backpack");
                this.Field.ItemConsumable = null;
            }
            else
            {
                Console.WriteLine("nothing here to take...");
            }

        }
        
        public void UseItem(int position)
        {
            int i = position - 1;
            if (this.Backpack[i].ItemType == ItemType.FOOD)   //kann man mit == schauen "ist objekt?"
            {
                this.Hitpoints += this.Backpack[i].Value;
                Console.WriteLine(this.Backpack[i].Name + " consumed and " + this.Backpack[position - 1].Value + " energy restored");
                if (this.Hitpoints > HitpointsMax)
                {
                    this.Hitpoints = HitpointsMax;
                }
                this.Backpack.Remove(this.Backpack[i]);
            }
            else if(this.Backpack[i].ItemType == ItemType.WEAPON)
            {
                this.BaseDamage = this.Backpack[i].Value;
                Console.WriteLine(this.Backpack[i].Name + " equipped. Base damage is now " + this.Backpack[i].Value);
                this.Backpack.Remove(Backpack[i]);
            }
        }

        public void PrintBackpack()
        {
            for (int i = 0; i < Backpack.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + Backpack[i].Name);
            }
        }
    }
}
