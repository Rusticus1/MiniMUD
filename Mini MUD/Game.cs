using Mini_MUD.Fields;
using Mini_MUD.Life;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            //Items:
            ItemUseable keyGargoyle = new ItemUseable("gargoyle key", 0, ItemType.KEY);
            ItemUseable keyEagle = new ItemUseable("eagle key", 0, ItemType.KEY);
            ItemUseable silverSword = new ItemUseable("silver sword", 1, ItemType.WEAPON);
            ItemUseable bfSword = new ItemUseable("big fucking sword", 2, ItemType.WEAPON);
            ItemUseable sorcererStaff = new ItemUseable("sorcerer staff", 2, ItemType.MAGICWEAPON);
            ItemUseable gargoyleTrophy = new ItemUseable("gargoyle head trophy", 0, ItemType.VICTORY);
            ItemUseable scrollFireball = new ItemUseable("scroll of fireball", 10, ItemType.SCROLL);

            ItemUseable spellChargedbolt = new ItemUseable("chargedbolt (4)", 4, ItemType.SPELL);
            ItemUseable spellFirebolt = new ItemUseable("firebolt (6)", 6, ItemType.SPELL);
            ItemUseable spellBlackhole = new ItemUseable("black hole (10)", 10, ItemType.SPELL); 

            List<Item> spellbook = new List<Item>() { spellChargedbolt, spellFirebolt, spellBlackhole };

            ItemConsumable bread = new ItemConsumable("dry bread", 3, ItemType.FOOD); //essen wird bei feld zufällig generiert
            ItemConsumable meat = new ItemConsumable("meat jerky", 6, ItemType.FOOD);
            ItemConsumable healthPotion = new ItemConsumable("health potion", 15, ItemType.FOOD);
            ItemConsumable manaPotion = new ItemConsumable("mana potion", 10, ItemType.MANA);

            //Fields:
            #region Make Fields
            Wall wall = new Wall("wall", "Wall");

            //Dialog einbauen mit NPC's

            Floor a0 = new Floor("Crypt", "the room is dark and filled with coffins. Half are broken and the remains of their former inhabitants lie scattered on the floor. In the dark corners of this crypt you notice numerous pairs of red glowing eyes staring at you in hunger ...");
            Water a1 = new Water("Flooded room", "this room has been flooded. You cannot see how deep the water is");
            Floor a2 = new Floor("Kights Chambers", "this has a large dinnertable in the center and dozens of shields and weapons decorate the surrounding walls");
            Door a3 = new Door("Gargoyle door", "you step through an enormous door shaped like a gargoyle. Inside you see a large stone statue ... or is it? As you approach, the statues eyes open with a crack!");
            Floor a4 = new Floor("Battlefield", "a large battle must have been fought here. the room is filled with dead bodies of creatures and men alike... you must be getting close");
            Floor a5 = new Floor("Wizards tower", "you slowly walk up a spiral staircase to find a small room filled with old books and jars full of unidentifiable inlaid animals");

            Floor b0 = new Floor("Abandoned chapel", "rows upon rows of benches bofore an altar. This must have been used as a Chapel");
            Floor b1 = new Floor("Courtyard", "you step into a courtyard. The faint light of a full moon shines through a foggy and otherwise pitch black night");
            Floor b2 = new Floor("North hall", "you notice the skeletal remains of a warrior cowering in a corner firmly holding his rusted old sword. He must have died ages ago");
            Floor b3 = new Floor("Empty hall", "this hall might have been used for dust collection...");
            Floor b4 = new Floor("Torture chamber", "upon seein the devices in this room you know exactly what it was used for");
            Floor b5 = new Floor("Bedchambers", "there is no time for a nap ...");

            Floor c0 = new Floor("Storage", "the room is filled with old statues and broken furniture...");
            Floor c1 = new Floor("West hall", "a large but sparsly decorated hall");
            Floor c2 = new Floor("Hallway", "to the east you see a large wooden door with an eagle emblem. It looks like it has been hastily barricaded from the outside in an attempt to keep something locked inside..");
            Door c3 = new Door("Eagle door", "you see crushed bodies and limbs scattered all over the floor ... something big must have done this");
            Floor c4 = new Floor("Corridor", "a tight corridor with a crossing in the center");
            Water c5 = new Water("Winecellar", "the ground is covered with a strange liquid");

            Floor d0 = new Floor("Crumbling corner", "the walls to the outside world are cracked and moonlight illuminates the room");
            Floor d1 = new Floor("West corridor", "a tight corridor... you can see a small room ruptured by faint sunbeams at the far end");
            Floor d2 = new Floor("Entrance hall", "you see a heavy door through which you entered this dungeon and two smaller archways leading deeper into the darkness");
            Water d3 = new Water("Well", "the ground around this overflowing well is covered in water");
            Floor d4 = new Floor("Weapons chamber", "the room is filled racks containing all kinds of weapons and armor. Sadly, most are far beyond usable...");
            Floor d5 = new Floor("Treasure Room", "you step into a room filled with enough treasure to buy a castle... maybe you could come back here with a larger backpack.");
            #endregion

            //damit Door.cs den Schlüssel kennt
            c3.AddItemUseable(keyEagle);
            a3.AddItemUseable(keyGargoyle);
            a1.AddItemConsumableToField(manaPotion);
            c5.AddItemConsumableToField(healthPotion);
            d0.AddItemConsumableToField(healthPotion);

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
            
            #region Monsters
            Monster goblin = new Monster("Goblin", 10, 3, c0, silverSword);
            Monster ghoul = new Monster("Ghoul", 16, 3, a0, keyEagle);
            Monster golem = new Monster("Golem", 20, 3, d4, bfSword);
            Monster skeleton = new Monster("Skeleton", 13, 3, b4, sorcererStaff);
            Monster hoemunculus = new Monster("Hoemunculus", 8, 4, a5, scrollFireball);
            Monster leprechaun = new Monster("Leprechaun", 5, 5, d5, keyGargoyle);
            Monster gargoyle = new Monster("Gargoyle", 30, 4, a3, gargoyleTrophy);
            //Monster der liste hinzufügen damit Encounter() geprüft werden kann.

            List<Monster> monsters = new List<Monster>() { goblin, ghoul, golem, skeleton, hoemunculus, leprechaun, gargoyle };
            #endregion

            Warrior warrior = new Warrior("warrior", 20, 3, 1, fieldlist, d2);
            Mage mage = new Mage("mage", 20, 10, 2, 0, spellbook, fieldlist, d2);

            List<Hero> heroes = new List<Hero>() { warrior, mage };

            #region notizen
            //Hero hero = PickHero(heroes);

            //use() verwenden um im Door room door aufzusperren??  SOLVED
            //schlüssel verwenden und himmelsrichtung auswählen SOLVED
            //Schwert wird immer wie Itemtype.Food behandelt und gegessen!!  SOLVED  (itemType tippfehler! groß und kleinschreibung beachten!!!!!!!!)
            //vergleich  (items)  wenn item == 'class' itemConsumable   geht das???  SOLVED
            //wenn monster hero tötet ist nicht gleich fertig. muss immer noch zuerst einen move machen?? SOLVED
            //wie kann ich ganz aus Game()raus bzw. direkt gameover machen   SOLVED
            //use()backpack beste möglichkeit damit eingabe richtig sein muss??? SOLVED

            //wie kann ich die Tür mit einem hero verbinden? bzw von dort daten holen ohne Door(Hero) mitzugeben.

            //kann man spiel für andere zugänglich machen????

            //evtl minimap wo man war? jeder raum wird hinzugefügt zur map. (wie bei robot?)

            //Water=  if hero.field is Water .... 
            //bei Enter() Methode vielleicht DOCH hero mitgeben?? (mehr optionen)
            //Wasserfeld??

            //Kopieren in WPF?  //evtl am Nachmittag schauen was die anderen gemacht haben
            //Random damage = randomnumber 0-2. bei 0 = -1, bei 1 = 0, bei 2 = +1
            //kritische treffer chance 20 % ?

            //wie kann ich Game() sofort beenden?

            #endregion
            #region Hero selection and item changes
            Console.WriteLine("Mini Mud");
            Hero hero = PickHero(heroes);
                       
            mage.Backpack.Add(manaPotion);
            mage.Backpack.Add(healthPotion);
            #endregion

            Console.Clear();

            Console.WriteLine(hero.Name + ", you seek to slay the garoyle!");
            Console.WriteLine("... you enter the main hall through a large and heavy door");
            Console.WriteLine("As the door closes shut behind you it takes a moment for your eyes to adjust to the darkness");
            Console.WriteLine("continue...");
            Console.ReadLine();
            while (hero.Alive == true)
            {
                VictoryCondition(hero);
                Console.Clear();
                Headline(hero);
                Console.WriteLine(hero.Field.Description);  //muss bei encounter -> combat nochmal geprintet werden für die ausgabe, sonst ist es weg nach clear()
                Encounter(hero, monsters);
                //schleife muss beendet werden bei tod!!!
                //billige lösung: ...
                if (hero.Alive == false)
                {
                    break;
                }
                Console.WriteLine("");
                hero.Field.PrintFieldContents();

                Console.WriteLine();
                Console.WriteLine(hero.Hitpoints + " hitpoints left");
                if (hero is Mage)
                {
                    Console.WriteLine(hero.Mana + " mana left");
                }
                Console.WriteLine("What do you want to do...");
                Console.WriteLine();
                hero.Field.PrintFieldMoves(); //ich stehe auf dem Feld deshalb muss ich des nicht mitgeben               

                string input = Console.ReadLine().ToLower();

                //Richtungen sind einfacher mit enums
                if (input == "north" || input == "n")    //check if move possible Methode??  mit bool?  //wenn in neuen raum gemoved ist dann details
                {
                    hero.Moving(Direction.NORTH); // Enter() Methode in Moving integriert.             
                }
                else if (input == "east" || input == "e")
                {
                    hero.Moving(Direction.EAST);
                }
                else if (input == "south" || input == "s")
                {
                    hero.Moving(Direction.SOUTH);
                }
                else if (input == "west" || input == "w")
                {
                    hero.Moving(Direction.WEST);
                }
                else  //other ACTIONS
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
                        hero.SpellDamage = 0;
                    }
                    else if (input == "info")
                    {
                        GameInfo();
                    }
                    #region CHEATS
                    //CHEATS  !!!!!! 
                    else if (input == "cheateaglekey")
                    {
                        hero.Backpack.Add(keyEagle);
                    }
                    else if (input == "cheatscroll")
                    {
                        hero.Backpack.Add(scrollFireball);
                    }
                    else if (input == "cheatmeat")
                    {
                        hero.Backpack.Add(meat);
                    }
                    else if (input == "cheatgargoylekey")
                    {
                        hero.Backpack.Add(keyGargoyle);
                    }
                    else if (input == "cheattrophy")
                    {
                        hero.Backpack.Add(gargoyleTrophy);
                    }
                    #endregion
                    // CHEATS !!!!! 
                    else
                    {
                        Console.WriteLine("what?");
                    }
                    Console.WriteLine("continue ... ");
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine(". . .");
            Console.WriteLine("you collapse and fall on the ground ...");
            Console.WriteLine("your story will end as a lifless corpse among innumerable others whose names will never be remembered ...");
            Console.ReadLine();
            Console.WriteLine("\t G A M E  O V E R ");
            return;
        }
        //sobad man einen raum betritt muss geprüft werden ob ein Monster drinnen ist
        public void VictoryCondition(Hero hero)
        {
            foreach (Item item in hero.Backpack)
            {
                if (item.ItemType == ItemType.VICTORY)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("the mighty gargoyle lies dead at your feet ... you cut off its head as proof of your victory... ");
                        Console.WriteLine("congratulations!");
                        Thread.Sleep(2000);
                        Console.Write("but ...");
                        Thread.Sleep(2000);
                        Console.WriteLine("our princess is in another castle!");
                        Console.ReadLine();
                    }
                }
            }
        }
        public void Manareg(Hero hero)
        {
            if (hero.Mana < hero.ManaMax)
            {
                hero.Mana += 1;
            }
            if (hero.Mana > hero.ManaMax)
            {
                hero.Mana = hero.ManaMax;
            }
        }
        public void Use(Hero hero)
        {
            if (hero.Backpack.Count > 0)
            {
                hero.PrintBackpack();
                Console.WriteLine("which item do you want to use? or go 'back'");
                //geht das einfacher??
                string useS = ""; // damit frägt er so lange bis eingabe ein int ist
                int use = 0;
                do
                {
                    useS = Console.ReadLine();
                    if (useS == "back")
                    {
                        return;
                    }
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
        public void Combat(Hero hero, Monster monster) //'light' oder 'heavy' schreiben. oder wenn Mage 'cast' bei rechtschreibfehler = "missed"
        {
            while (hero.Alive) //solange der held lebt:
            {
                Console.WriteLine("you encountered a " + monster.Name + ". Prepare to fight!");
                Console.WriteLine();
                Console.WriteLine("you have " + hero.Hitpoints + " hitpoints left");
                if (hero is Mage)
                {
                    Console.WriteLine("you have " + hero.Mana + " mana left");
                }
                Console.Write("'light' for light attack, 'heavy' for heavy attack");
                if (hero is Mage)
                {
                    Console.WriteLine(", 'cast' to use spells");
                }
                else
                {
                    Console.WriteLine();
                }
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
                else if (attack == "cast")
                {
                    if (hero is Mage)
                    {
                        Cast(hero as Mage);
                        monster.Hitpoints -= hero.SpellDamage;
                        hero.SpellDamage = 0;
                    }
                }
                else if (attack == "use") //wie beim normalen use - Inventarauswahl
                {
                    Use(hero);
                    monster.Hitpoints -= hero.SpellDamage; //falls scroll verwendet wird, wird spelldamage applied und dann wieder auf 0 gesetzt.
                    hero.SpellDamage = 0;  
                }
                else
                {
                    Console.WriteLine("you missed ...");
                }
                if (monster.Hitpoints > 0) //solange das monster lebt
                {
                    int monsterDamage = monster.BaseDamage - hero.BaseArmor;
                    hero.Hitpoints -= monsterDamage;
                    Console.WriteLine(monster.Name + " hits you for " + monsterDamage + " damage");
                }
                else
                {
                    Console.Write(monster.Name + " has been slain!");
                    if (monster.Item != null)
                    {
                        Console.WriteLine(" You take " + monster.Item.Name + " from its corpse");
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
                    hero.Manareg();
                    Console.WriteLine(monster.Name + " has " + monster.Hitpoints + " hitpoints left");
                    Console.WriteLine("continue...");
                    Console.ReadLine();
                    VictoryCondition(hero);
                    Console.Clear();
                    Headline(hero);
                }
            }
            return;

        }
        public int DamageCalculator(int damage) //WIP  baseDamage kommt rein, random damage geht raus
        {
            return damage;
        }
        public void Cast(Mage hero) //cast für die auswahl aus dem sellbook
        {
            if (hero.Spellbook.Count > 0)
            {
                hero.PrintSpellbook();
                Console.WriteLine("which spell do you want to cast? or go 'back'");
                //geht das einfacher??
                // damit frägt er so lange bis eingabe ein int ist

                while (true)
                {
                    string useS = Console.ReadLine();
                    if (useS == "back")
                    {
                        return;
                    }
                    int use = 0;
                    if (int.TryParse(useS, out use))
                    {
                        if (hero.UseSpell(use)) //Usespell ist bool. wenn wahr ist dann fertig. wenn nein nochmal loop
                        {
                            return;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("you do not know any spells ...");
            }
        }
        public Hero PickHero(List<Hero> hero)
        {

            int i = 1;
            Console.WriteLine("pick a hero to enter the dungeon ...");

            foreach (Hero h in hero)
            {
                Console.WriteLine(i + " " + h.Name);
                i++;
            }
            string pick = ""; // damit frägt er so lange bis eingabe ein int ist
            int index = 0;
            do
            {
                pick = Console.ReadLine();
            } while (!int.TryParse(pick, out index));
            return hero[index - 1];
        }
        public void Headline(Hero hero)
        {
            Console.WriteLine("commands: take, use, backpack, info (game info)");
            Console.WriteLine("the dark energies of this place are slowly draining your life away ... .. .");
            Console.WriteLine("... ... ... ...");
            Console.WriteLine();
            Console.WriteLine(hero.Field.RoomName);
            Console.WriteLine();
            // Console.WriteLine(hero.Field.Description); Nein weil die Headline soll immer da sein auch beim kampf
        }
        public void GameInfo()
        {
            Console.Clear();
            Console.WriteLine("type direction to move your hero");
            Console.WriteLine("each movement costs 1 hitpoint");
            Console.WriteLine("each movement or turn in combat restores mana (mage only)");
            Console.WriteLine("movement into water areas will cost additional hitpoints based on your armor level");
            Console.WriteLine("find randomly generated food in rooms to restore hitpoints");
            Console.WriteLine("kill monsters to find weapons and equip them to increase damage");
            Console.WriteLine("type 'use' to use any item in your backpack");
            Console.WriteLine("type 'take' to pick up items you find in rooms");
            Console.WriteLine("KILL the gargoyle to win the game!");

            Console.ReadLine();
            
        }
    }
}
