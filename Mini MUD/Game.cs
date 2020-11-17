﻿using Mini_MUD.Fields;
using Mini_MUD.Life;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD
{
    public class Game
    {
        //move, if field == null || field == wall   cw("wall, cant move")
        public Game()
        {

        }

        public void Start()
        {
            Item KeyLion = new Item("Lion key");
            Item KeyEagle = new Item("Eagle key");
            Item drybread = new ItemConsumable("dry bread");
            Item grilledMeat = new ItemConsumable("grilled meat");

            #region Make Fields
            Wall wall = new Wall("wall", "Wall");

            Floor a0 = new Floor("Crypt", "the room is dark and filled with Coffins. Half are broken and the remains of their former inhabitants lie scattered on the floor. As you eyes adjust to the darkness you notice a pair or red glowing eyes staring at you in hunger ...");
            Water a1 = new Water("Flooded room", "this room has been flooded. You cannot see how deep the water is.");
            Wall a2 = new Wall("Wall", "you cannot go through here");
            Floor a3 = new Floor("a3", "notext");
            Floor a4 = new Floor("a4", "notext");
            Floor a5 = new Floor("a5", "notext");

            Floor b0 = new Floor("b0", "notext");
            Floor b1 = new Floor("b1", "notext");
            Floor b2 = new Floor("North hall", "notext");
            Wall b3 = new Wall("Wall", "wall");
            Floor b4 = new Floor("b4", "notext");
            Floor b5 = new Floor("b5", "notext");

            Floor c0 = new Floor("c0", "notext");
            Floor c1 = new Floor("c1", "notext");
            Floor c2 = new Floor("Hallway", "you walk through a hallway with a crossing");
            Door c3 = new Door("Eagle door", "you stand before a large wodden door with a Eagle emblem . It looks like it has been hastily barricaded from the outside in an attempt to keep something locked inside...", KeyEagle);
            Floor c4 = new Floor("c4", "notext");
            Floor c5 = new Floor("c5", "notext");

            Floor d0 = new Floor("Sun Room", "the walls to the outside world are cracked and sunlight is flodding in");
            Floor d1 = new Floor("West Corridor", "a tight corridor... you can see a small room ruptured by faint sunbeams at the far end");
            Floor d2 = new Floor("Entrance Hall", "you are back at the Entrance hall");
            Wall d3 = new Wall("d3", "wall");
            Floor d4 = new Floor("Wall", "notext");
            Floor d5 = new Floor("d5", "notext");
            #endregion
                       

            //Methode für zuweisung???
            #region setNeightbours
            a0.SetNeightbours(null, a1, b0, null);
            a1.SetNeightbours(null, a2, b1, a0);
            a2.SetNeightbours(null, a3, b2, a1);
            a3.SetNeightbours(null, a4, b3, wall);
            a4.SetNeightbours(null, a5, b4, a3);
            a5.SetNeightbours(null, null, b5, a4);

            b0.SetNeightbours(a0, b1, c0, null);
            b1.SetNeightbours(a1, b2, c1, b0);
            b2.SetNeightbours(a2, b3, c2, b1);
            b3.SetNeightbours(a3, b4, c3, b2);
            b4.SetNeightbours(a4, b5, c4, b3);
            b5.SetNeightbours(a5, null, c5, b4);

            c0.SetNeightbours(b0, c1, d0, null);
            c1.SetNeightbours(b1, c2, d1, c0);
            c2.SetNeightbours(b2, c3, d2, c1);
            c3.SetNeightbours(b3, c4, d3, c2);
            c4.SetNeightbours(b4, c5, d4, c3);
            c5.SetNeightbours(b5, null, d5, c4);

            d0.SetNeightbours(c0, d1, null, null);
            d1.SetNeightbours(c1, d2, null, d0);
            d2.SetNeightbours(c2, d3, null, d1);
            d3.SetNeightbours(c3, d4, null, d2);
            d4.SetNeightbours(c4, d5, null, d3);
            d5.SetNeightbours(c5, null, null, d4);

            List<Field> fieldlist = new List<Field> { a0, a1, a2, a3, a4, a5, b0, b1, b2, b3, b4, b5, c0, c1, c2, c3, c4, c5, d0, d1, d2, d3, d4, d5 };
            #endregion                       

            #region Monsters
            Monster goblin = new Monster("Goblin", 5);
            Monster ghoul = new Monster("Ghoul", 10);
            #endregion


            Hero hero = new Hero("Warrior", 10, fieldlist, d2);

            Console.WriteLine("...you enter the main hall through a large, half rotten, wodden door");
            Console.WriteLine("It takes a moment for your eyes to adjust to the darkness");
            while (hero.Hitpoints > 0)
            {
                //evtl in methode bei field?
                Console.WriteLine("");
                Console.WriteLine("You are standing in: " + hero.Field.RoomName);                
                Console.WriteLine("Where do you want to go...");
                Console.WriteLine("");
                hero.Field.PrintFieldMoves();  //ich stehe auf dem Feld deshalb muss ich des nicht mitgeben

                string input = Console.ReadLine().ToLower();
                if (input == "north")    //check if move possible Methode??  mit bool?  //wenn in neuen raum gemoved ist dann details
                {
                    hero.Moving(Direction.NORTH);     // Enter() Methode in Moving integriert.             
                }
                else if(input == "east")
                {
                    hero.Moving(Direction.EAST);
                }
                else if(input == "south")
                {
                    hero.Moving(Direction.SOUTH);
                }
                else if(input == "west")
                {
                    hero.Moving(Direction.WEST);
                }
                else
                {
                    Console.WriteLine("where??");
                }
                // hero.EnterRoom();

            }               
           
        }
        public void Combat()
        {

        }
    }
}
