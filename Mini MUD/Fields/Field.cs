﻿using System;
using System.Collections.Generic;
using System.Text;
using Mini_MUD.Life;

namespace Mini_MUD
{


    public abstract class Field  //monster hier ins Feld 
    {
        //zusätzlicher Feldeffekt je nach feld. wird auf hero angewendet
        public string RoomName { get; set; }
        public string Description { get; set; }
        public ItemUseable ItemUseable { get; set; }
        public ItemConsumable ItemConsumable { get; set; }
        public Field North { get; set; }
        public Field East { get; set; }
        public Field South { get; set; }
        public Field West { get; set; }
        public Monster Monster { get; set; }
        public Field(string roomName, string description)
        {
            this.RoomName = roomName;
            this.Description = description;
        }

        protected Field(string roomName)
        {
            RoomName = roomName;
        }
         public abstract bool Enter(Hero hero = null); //auch wenn ich irgendwo programmiert habe und noch nichts eingegeben habe funktionierts trotzdem
                                                      //optional!!
        public void SetNeightbours(Field north, Field east, Field south, Field west)
        {
            this.North = north;
            if (north != null)
            {
                north.South = this;
            }
            this.East = east;
            if (east != null)
            {
                east.West = this;
            }
            this.South = south;
            if (south != null)
            {
                south.North = this;
            }
            this.West = west;
            if (west != null)
            {
                west.East = this;
            }
        }

        public void AddItemConsumableToField(ItemConsumable itemConsumable)
        {
            this.ItemConsumable = itemConsumable;
        }
        public void AddItemUseableToField(ItemUseable itemUseable)
        {
            this.ItemUseable = itemUseable;
        }
        public void PrintFieldContents()  //keine parameter, weil Methode ist IM Field, deshalb this
        {
            Console.Write("you found ");
            if (ItemConsumable != null)
            {
                Console.WriteLine(ItemConsumable.Name);
            }
            else
            {
                Console.WriteLine("nothing of interest");
            }

        }
        public void PrintFieldMoves() 
        {
            if (North != null)
            {
                Console.WriteLine("North: " + North.RoomName);
            }
            else
            {
                Console.WriteLine("North: Wall");
            }
            if (East != null)
            {
                Console.WriteLine("East: " + East.RoomName);
            }
            else
            {
                Console.WriteLine("East: Wall");
            }
            if (South != null)
            {
                Console.WriteLine("South: " + South.RoomName);
            }
            else
            {
                Console.WriteLine("South: Wall");
            }
            if (West != null)
            {
                Console.WriteLine("West: " + West.RoomName);
            }
            else
            {
                Console.WriteLine("West: Wall");
            }
        }


        /* public void PrintField(Hero hero)  /// robot.PrintField()
        {
            for (int i = 1; i <= hero.Fieldlist.Count; i++)
            {
                if (hero.Fieldlist[i - 1] == hero.Field)
                {
                    Console.Write("|&|");
                }
                else if (hero.Fieldlist[i - 1].Fieldtype == Field.FieldType.WALL)
                {
                    Console.Write("   ");
                }
                else
                {
                    Console.Write("| |");
                }
                if (i % 6 == 0)
                {
                    Console.WriteLine("");
                }
            }
        } */
    }
}


