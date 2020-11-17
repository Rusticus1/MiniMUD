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
        public int BaseDamage { get; set; }
        public List<Item> Backpack { get; set; }
        public int BackpackMax { get; set; }
        public Field Field { get; set; }
        public List<Field> Fieldlist { get; set; }

        public Hero(string name, int hitpoints, List<Field> fieldlist, Field startfield)
        {
            this.Name = name;
            this.Hitpoints = hitpoints;
            this.BaseDamage = 3;
            this.Fieldlist = fieldlist;
            this.Field = startfield;
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
                }
            }
            else if (direction == Direction.EAST)
            {
                if(this.Field.East != null && this.Field.East.Enter())
                {
                    this.Field = this.Field.East;
                }                
            }
            else if (direction == Direction.SOUTH)
            {
                if(this.Field.South != null && this.Field.South.Enter())
                {
                    this.Field = this.Field.South;
                }        
            }
            else if (direction == Direction.WEST)
            {
                if(this.Field.West != null && this.Field.West.Enter())
                {
                    this.Field = this.Field.West;
                }            
            }             
        }

        public void Attacking()
        {

        }
        public void PickUp()
        {

        }

        public void AddToBackpack(Item item)
        {
            if (this.Fieldlist.Count <= BackpackMax)
            {
                this.Backpack.Add(item);
            }
        }
        public void PrintBackpack()
        {
            foreach (Item i in this.Backpack)
            {
                Console.WriteLine(i.Name);
            }
        }
    }
}
