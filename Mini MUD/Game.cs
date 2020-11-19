using Mini_MUD.Fields;
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
            ItemUseable keyGargoyle = new ItemUseable("lion key", 0, ItemType.KEY);
            ItemUseable keyEagle = new ItemUseable("eagle key", 0, ItemType.KEY);
            ItemUseable silverSword = new ItemUseable("silver sword", 4, ItemType.WEAPON);
            ItemUseable bfSword = new ItemUseable("big fucking sword", 5, ItemType.WEAPON);

            ItemConsumable bread = new ItemConsumable("dry bread", 3, ItemType.FOOD);
            ItemConsumable meat = new ItemConsumable("meat jerky", 6, ItemType.FOOD);
            ItemConsumable healthPotion = new ItemConsumable("health potion", 15, ItemType.FOOD);

            #region Make Fields
            Wall wall = new Wall("wall", "Wall");

            Floor a0 = new Floor("Crypt", "the room is dark and filled with Coffins. Half are broken and the remains of their former inhabitants lie scattered on the floor. As your eyes adjust to the darkness you notice numerous pairs of red glowing eyes around you staring at you in hunger ...");
            Water a1 = new Water("Flooded room", "this room has been flooded. You cannot see how deep the water is");
            Floor a2 = new Floor("Kights Chambers", "this has a large dinnertable in the center and dozens of shields and weapons decorate the surrounding walls");
            Door a3 = new Door("Gargoyle door", "an enormous door shaped like a gargoyle");
            Floor a4 = new Floor("Battlefield", "a large battle must have been fought here. the room is filled with dead bodies of creatures and men alike... you must be getting close");
            Floor a5 = new Floor("Wizards tower", "you slowly walk up a spiral staircase to find a small room filled with books and jars full of unidentifiable inlaid animals");

            Floor b0 = new Floor("Abandoned chapel", "rows upon rows of benches bofore an altar. This must have been used as a Chapel");
            Floor b1 = new Floor("Courtyard", "you step into a courtyard. The faint light of a full moon shines through a foggy and otherwise pitch black night");
            Floor b2 = new Floor("North hall", "you notice the skeletal remains of a warrior cowering in a corner firmly holding his rusted old sword. He must have died ages ago");
            Floor b3 = new Floor("Empty hall", "this hall might have been used for dust collection...");
            Floor b4 = new Floor("Torture chamber", "upon seein the devices in this room you can clearly see what it was used for");
            Floor b5 = new Floor("b5", "notext");

            Floor c0 = new Floor("Storage", "the room is filled with old statues and broken furniture...");
            Floor c1 = new Floor("West hall", "a large but sparsly decorated hall");
            Floor c2 = new Floor("Hallway", "to the east you see a large wodden door with an eagle emblem. It looks like it has been hastily barricaded from the outside in an attempt to keep something locked inside..");
            Door c3 = new Door("Eagle door", "you see crushed bodies and limbs scattered all over the floor ... something big must have done this");
            Floor c4 = new Floor("Corridor", "a tight corridor with a crossing in the center");
            Floor c5 = new Floor("Winecellar", "a room filled with old barrels used to store whine");

            Floor d0 = new Floor("Crumbling corner", "the walls to the outside world are cracked and moonlight illuminates the room");
            Floor d1 = new Floor("West corridor", "a tight corridor... you can see a small room ruptured by faint sunbeams at the far end");
            Floor d2 = new Floor("Entrance hall", "you see a heavy door through which you entered this dungeon and two smaller archways leading deeper into the darkness");
            Wall d3 = new Wall("Wall", "wall");
            Floor d4 = new Floor("Wall", "notext");
            Floor d5 = new Floor("Treasure Room", "you step into a room filled with enough treasure to buy a castle... maybe you could come back here with a larger backpack.");
            #endregion

            c3.AddItemUseable(keyEagle);

            //Methode für zuweisung???
            #region setNeightbours
            a0.SetNeightbours(null, a1, b0, null);
            a1.SetNeightbours(null, a2, b1, a0);
            a2.SetNeightbours(null, null, b2, a1);
            a3.SetNeightbours(null, a4, b3, null);
            a4.SetNeightbours(null, a5, b4, a3);
            a5.SetNeightbours(null, null, b5, a4);

            b0.SetNeightbours(a0, b1, c0, null);
            b1.SetNeightbours(a1, b2, c1, b0);
            b2.SetNeightbours(a2, null, c2, b1);
            b3.SetNeightbours(null, b4, c3, null);
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
            d2.SetNeightbours(c2, null, null, d1);
            d3.SetNeightbours(c3, d4, null, null);
            d4.SetNeightbours(c4, d5, null, d3);
            d5.SetNeightbours(c5, null, null, d4);

            List<Field> fieldlist = new List<Field> { a0, a1, a2, a3, a4, a5, b0, b1, b2, b3, b4, b5, c0, c1, c2, c3, c4, c5, d0, d1, d2, d3, d4, d5 };
            #endregion                       

            //a0.AddItemToField(keyEagle);
            #region Monsters
            Monster goblin = new Monster("Goblin", 10, 3, c0, silverSword);
            Monster ghoul = new Monster("Ghoul", 16, 2, a0, keyEagle);
            Monster golem = new Monster("Golem", 20, 3, a3, keyGargoyle);
            Monster skeleton = new Monster("Skeleton", 13, 3, b4, healthPotion);
            Monster gargoyle = new Monster("Gargoyle", 30, 4, a3, null);

            List<Monster> monsters = new List<Monster>() { goblin, ghoul, golem, skeleton };
            #endregion


            Hero warrior = new Hero("warrior", 20, 3, fieldlist, d2);
            Hero mage = new Hero("mage", 16, 2, fieldlist, d2);

            List<Hero> heroes = new List<Hero>() { warrior, mage };

            //Hero hero = PickHero(heroes);
            Console.WriteLine("...you enter the main hall through a large, heavy wodden door");
            Console.WriteLine("As the heavy door closes shut behind you it takes a moment for your eyes to adjust to the darkness");
            Console.ReadLine();

            //schlüssel funktionieren wie??  bei türe das inventar durchgehen? aber wie held zur türe geben
            //use() verwenden um im Door room door aufzusperren??   nein mit Enter methode
            //schlüssel verwenden und himmelsrichtung auswählen

            // wenn hero.field.direction eine Door ist, dann mach true!

            //kann ich alle arten von items in den rucksack packen? SOLVED
            //Schwert wird immer wie Itemtype.Food behandelt und gegessen!!  SOLVED (itemType tippfehler! groß und kleinschreibung beachten!!!!!!!!)
            //vergleich  (items)  wenn item == 'class' itemConsumable   geht das???  
            Hero hero = warrior;
            while (hero.Alive == true)  // 
            {
                Console.Clear();
                Headline(hero);
                Console.WriteLine(hero.Field.Description);  //muss bei encounter -> combat nochmal geprintet werden für die ausgabe, sonst ist es weg nach clear()
                Encounter(hero, monsters);

                IsAlive(hero);  //schleife muss beendet werden bei tod!!!

                hero.Field.PrintFieldContents();
                Console.WriteLine();
                Console.WriteLine(hero.Hitpoints + " hitpoints left");

                Console.WriteLine("What do you want to do...");
                Console.WriteLine();
                hero.Field.PrintFieldMoves();  //ich stehe auf dem Feld deshalb muss ich des nicht mitgeben               

                string input = Console.ReadLine().ToLower();

                //Richtungen sind einfacher mit enums
                if (input == "north")    //check if move possible Methode??  mit bool?  //wenn in neuen raum gemoved ist dann details
                {
                    hero.Moving(Direction.NORTH); // Enter() Methode in Moving integriert.             
                }
                else if (input == "east")
                {
                    hero.Moving(Direction.EAST);
                }
                else if (input == "south")
                {
                    hero.Moving(Direction.SOUTH);
                }
                else if (input == "west")
                {
                    hero.Moving(Direction.WEST);
                }
                else
                {
                    if (input == "take")
                    {
                        hero.TakeItemConsumable();
                    }
                    else if (input == "backpack")
                    {
                        hero.PrintBackpack();
                    }
                    else if (input == "use")
                    {
                        Use(hero);

                    }
                    //CHEATS
                    else if (input == "eaglekey")
                    {
                        hero.Backpack.Add(keyEagle);
                    }
                    else
                    {
                        Console.WriteLine("what??");
                    }

                    Console.WriteLine("continue ... ");
                    Console.ReadLine();
                }

            }
            Console.Clear();
            Console.WriteLine("you collapse and fall on the ground ...");
            Console.WriteLine("your story will end as a lifless corpse among innumerable others whose names will never be remembered ...");
            Console.ReadLine();
            Console.WriteLine("\t G A M E  O V E R ");
            return;

        }
        //sobad man einen raum betritt muss geprüft werden ob ein Monster drinnen ist
        public void Use(Hero hero)
        {
            if (hero.Backpack.Count > 0)
            {
                hero.PrintBackpack();
                Console.WriteLine("which item do you want to use");
                //geht das einfaher??
                string useS = ""; // damit frägt er so lange bis eingabe ein int ist
                int use = 0;
                do
                {
                    useS = Console.ReadLine();
                } while (!int.TryParse(useS, out use));
                hero.UseItem(use);
            }
            /*else
            {
                Console.WriteLine("your backpack is empty...");
            } */
        }
        public void IsAlive(Hero hero) //einfache prüfung mit bool ob Hero lebt oder tot ist
        {
            if (hero.Hitpoints <= 0)
            {
                hero.Alive = false;
            }
        }
        public void Encounter(Hero hero, List<Monster> monsters)
        {
            foreach (Monster m in monsters)
            {
                if (hero.Field == m.Field)
                {
                    Combat(hero, m);
                }
            }
        }
        public void Combat(Hero hero, Monster monster) //light oder heavy schreiben. bei rechtschreibfehler = "missed"
        {
            while (hero.Alive) //solange der held lebt:
            {
                Console.WriteLine("you encountered a " + monster.Name + ". Prepare to fight!");
                Console.WriteLine();
                Console.WriteLine("you have " + hero.Hitpoints + " hitpoints left");
                Console.WriteLine("'light' for fast attack, 'heavy' for heavy attack");
                string attack = Console.ReadLine();

                if (attack == "light")
                {
                    int damage = hero.BaseDamage;
                    monster.Hitpoints -= damage;
                    Console.WriteLine("light attack on " + monster.Name + " for " + damage + " damage");
                }
                else if (attack == "heavy")
                {
                    int damage = hero.BaseDamage + 2;
                    monster.Hitpoints -= damage;
                    hero.Hitpoints -= 1;
                    Console.WriteLine("heavy attack on " + monster.Name + " for " + damage + " damage but at the cost of 1 hitpoint");
                }
                else if (attack == "use")
                {
                    Use(hero);
                }
                else
                {
                    Console.WriteLine("you missed ...");
                }
                if (monster.Hitpoints > 0) //solange das monster lebt
                {
                    hero.Hitpoints -= monster.BaseDamage;
                    Console.WriteLine(monster.Name + " hits you for " + monster.BaseDamage + " damage");
                }
                else
                {
                    Console.Write(monster.Name + " has been slain!.");
                    if (monster.Item != null)
                    {
                        Console.WriteLine(" You take " + monster.Item.Name + " from it's corpse");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    hero.Backpack.Add(monster.Item);
                    monster.Field = null;
                    Console.WriteLine("continue ...");
                    Console.ReadLine();
                    Console.Clear();
                    Headline(hero);
                    Console.WriteLine(hero.Field.Description);
                    return;
                }
                IsAlive(hero);
                if (hero.Alive == true)
                {
                    Console.WriteLine(monster.Name + " has " + monster.Hitpoints + " hitpoints left");
                    Console.WriteLine("continue...");
                    Console.ReadLine();
                    Console.Clear();
                    Headline(hero);
                }
            }
            return;

        }
        /* public Hero PickHero(List<Hero> hero)
        {

            int i = hero.Count;
            Console.WriteLine("pick a hero");
            foreach (Hero h in hero)
            {
                Console.WriteLine(" " + h.Name);
            }            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == hero[i].Name)
                {
                    return hero[i];
                }
            }       
        }*/
        public void Headline(Hero hero)
        {
            Console.WriteLine("commands: take, use, backpack");
            Console.WriteLine("the dark energies of this place are slowly draining your life away ... .. .");
            Console.WriteLine("... ... ... ...");
            Console.WriteLine();
            Console.WriteLine(hero.Field.RoomName);
            Console.WriteLine();
            // Console.WriteLine(hero.Field.Description); Nein weil die Headline soll immer da sein auch beim kampf
        }
    }
}
