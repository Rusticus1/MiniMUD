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
        public int Mana { get; set; }
        public int ManaMax { get; set; }
        public int StartDamage { get; set; }
        public int BaseDamage { get; set; }        
        public int StartArmor { get; set; }
        public int BaseArmor { get; set; }
        public int SpellDamage { get; set; }
        public int SpellBonusDamage { get; set; }
        public List<Item> Backpack { get; set; }
        public int BackpackMax { get; set; }
        public Field Field { get; set; }
        public List<Field> Fieldlist { get; set; }
        public bool Alive { get; set; }

        public Hero(string name, int hitpoints, int baseDamage, int startArmor, List<Field> fieldlist, Field startfield)
        {
            // Start ist der startwert der nicht verändert werden kann
            // Base wird zur Berechnung verwendet und kann durch items verändert werden
            this.Name = name;
            this.Hitpoints = hitpoints;
            this.HitpointsMax = hitpoints;
            this.Mana = 10;
            this.ManaMax = 10;
            this.StartDamage = baseDamage;
            this.BaseDamage = baseDamage;
            this.StartArmor = startArmor;
            this.BaseArmor = startArmor;
            this.SpellBonusDamage = 0;
            this.Fieldlist = fieldlist;
            this.Field = startfield;
            this.Backpack = new List<Item>();
            this.BackpackMax = 10;
            this.Alive = true;
        }


        public void Moving(Direction direction) //hier ENTER() Methode!!!!!!!!
        {
            //wenn er den key hat dannn ja sonst nein - NEIN weil sonst geht nicht mit Enter () Methode          
            if (direction == Direction.NORTH)
            {
                if (this.Field.North != null && this.Field.North.Enter(this))
                {
                    this.Field = this.Field.North;
                    this.Hitpoints -= 1;
                    Manareg();
                }                
            }
            else if (direction == Direction.EAST)
            {
                if (this.Field.East != null && this.Field.East.Enter(this))
                {
                    this.Field = this.Field.East;
                    this.Hitpoints -= 1;
                    Manareg();
                }
            }
            else if (direction == Direction.SOUTH)
            {
                if (this.Field.South != null && this.Field.South.Enter(this))
                {
                    this.Field = this.Field.South;
                    this.Hitpoints -= 1;
                    Manareg();
                }
            }
            else if (direction == Direction.WEST)
            {
                if (this.Field.West != null && this.Field.West.Enter(this))
                {
                    this.Field = this.Field.West;
                    this.Hitpoints -= 1;
                    Manareg();
                }
            }        
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
        
        public bool UseItem(int position)
        {            
            //this.Backpack[i].consume();
            //consume bei allen itemarten verschieden (wie enter() methode)
            //so lassen wies ist weil einfacher :)
            int i = position - 1;
            if (i < 0 || i >= this.Backpack.Count)
            {
                return false;
            }
            if (this.Backpack[i].ItemType == ItemType.FOOD)   //kann man mit == schauen "ist objekt?"
            {
                this.Hitpoints += this.Backpack[i].Value;
                Console.WriteLine(this.Backpack[i].Name + " consumed and " + this.Backpack[i].Value + " hitpoints restored");
                if (this.Hitpoints > HitpointsMax)
                {
                    this.Hitpoints = HitpointsMax;
                }
                this.Backpack.Remove(this.Backpack[i]);
            }
            else if (this.Backpack[i].ItemType == ItemType.MANA)
            {
                if(this.Name == "Mage")                   //  !!!!!!!!!!!!!!!!!!!!!!!!!!!!  noch nicht schön
                {
                    this.Mana = this.ManaMax;
                    Console.WriteLine(this.Backpack[i].Name + " consumed. Mana restored");                    
                }
                else
                {
                    Console.WriteLine(this.Backpack[i].Name + " consumed. But alas ...nothing happened");
                }                
            }
            else if (this.Backpack[i].ItemType == ItemType.WEAPON)
            {
                this.BaseDamage = (this.StartDamage + this.Backpack[i].Value);
                Console.WriteLine(this.Backpack[i].Name + " equipped. Basedamage is now " + this.BaseDamage);
                this.Backpack.Remove(Backpack[i]);
            }
            else if (this.Backpack[i].ItemType == ItemType.MAGICWEAPON)
            {
                this.SpellBonusDamage = this.Backpack[i].Value;
                Console.WriteLine(this.Backpack[i].Name + " equipped. All spell damage increased by " + this.Backpack[i].Value);
                this.Backpack.Remove(Backpack[i]);
            }
            else if (this.Backpack[i].ItemType == ItemType.SCROLL)
            {
                this.SpellDamage = this.Backpack[i].Value;
                Console.WriteLine(this.Backpack[i].Name + " cast for " + this.Backpack[i].Value + " damage");
                this.Backpack.Remove(Backpack[i]);
            }
            else if (this.Backpack[i].ItemType == ItemType.KEY)  //Wenn schlüssel ist dann prüfe alle angrenzenden türen und sperre sie auf  Wie auf TRUE setzen??
            {
                if (this.Field.North != null)
                {
                    if (this.Backpack[i] == this.Field.North.ItemUseable) // if
                    {
                        if (this.Field.North is Door)
                        {
                            Door door = this.Field.North as Door;  //muss neue variable machen sonst kann ich nicht damit arbeiten
                            door.Unlocked = true;           //mit "as" behandeln wir dieses Feld (die neue variable die das Feld darstellt)als Tür
                            Console.WriteLine(this.Field.North.RoomName + " unlocked... ");
                            this.Backpack.Remove(this.Backpack[i]);
                            return true;
                        }
                    }
                }
                if (this.Field.East != null)
                {
                    if (this.Backpack[i] == this.Field.East.ItemUseable)
                    {
                        if (this.Field.East is Door)
                        {
                            Door door = this.Field.East as Door;  //muss neue variable machen sonst kann ich nicht damit arbeiten
                            door.Unlocked = true;           //mit "as" behandeln wir dieses Feld (die neue variable die das Feld darstellt)als Tür
                            Console.WriteLine(this.Field.East.RoomName + " unlocked... ");
                            this.Backpack.Remove(this.Backpack[i]);
                            return true;
                        }
                    }
                }
                if (this.Field.South != null)
                {
                    if (this.Backpack[i] == this.Field.South.ItemUseable)
                    {
                        if (this.Field.South is Door)
                        {
                            Door door = this.Field.South as Door;  //muss neue variable machen sonst kann ich nicht damit arbeiten
                            door.Unlocked = true;           //mit "as" behandeln wir dieses Feld (die neue variable die das Feld darstellt)als Tür
                            Console.WriteLine(this.Field.South.RoomName + " unlocked... ");
                            this.Backpack.Remove(this.Backpack[i]);
                            return true;
                        }
                    }
                }
                if (this.Field.West != null)
                {
                    if (this.Backpack[i] == this.Field.West.ItemUseable)
                    {
                        if (this.Field.West is Door)
                        {
                            Door door = this.Field.West as Door;  //muss neue variable machen sonst kann ich nicht damit arbeiten
                            door.Unlocked = true;           //mit "as" behandeln wir dieses Feld (die neue variable die das Feld darstellt)als Tür
                            Console.WriteLine(this.Field.West.RoomName + " unlocked... ");
                            this.Backpack.Remove(this.Backpack[i]);
                            return true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("nothing to unlock");
                }
            }
            return true;
        }
        public void PrintBackpack()
        {
            if (this.Backpack.Count > 0)
            {
                for (int i = 0; i < Backpack.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Backpack[i].Name);
                }
            }
            else
            {
                Console.WriteLine("your backpack is empty...");
            }
        }
        public void Manareg()
        {
            if (this.Mana < this.ManaMax)
            {
                this.Mana += 1;
                Console.WriteLine("1 mana regenerated");
            }
            if (this.Mana > this.ManaMax)
            {
                this.Mana = this.ManaMax;
            }


        }

    }
}
