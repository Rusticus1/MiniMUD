using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Life
{
    public class Mage : Hero
    {        
        public List<Item> Spellbook { get; set; }
        public int SpellBonusDamage { get; set; }
        public Mage(string name, int hitpoints, int mana, int baseDamage, List<Item> spellbook, List<Field> fieldlist, Field startfield) : base(name, hitpoints, baseDamage, fieldlist, startfield)
        {
            this.Spellbook = spellbook;
            this.SpellBonusDamage = 0;
        }        
        public bool UseSpell(int position) //auswahl aus dem spellbook als INT wird ausgeführt  //geändert in bool
        {                                   //initial prüfen ob der spell existiert in der Liste

            int i = position - 1;
            if(i < 0 || i >= this.Spellbook.Count)
            {
                return false;
            }
            if (this.Spellbook[i].Value <= this.Mana) //gefällt mir noch nicht. Muss verfeinert werden
            {
                int totalSpellDamage = this.Spellbook[i].Value + this.SpellBonusDamage;
                this.SpellDamage = totalSpellDamage;
                Console.WriteLine(this.Spellbook[i].Name + " cast for " + this.SpellDamage + " damage");
                this.Mana -= this.Spellbook[i].Value;  
                if(this.Spellbook[i].Name == "black hole (10)")
                {
                    this.Hitpoints -= 2;
                    Console.WriteLine("casting this spell cost you 2 hitpoints");
                }
            }

            else
            {
                Console.WriteLine("not enough mana!");
            }
            return true;
        }
        public void AddSpellbook(List<Item> spellbook)
        {
            this.Spellbook = spellbook;
        }
        public void PrintSpellbook()
        {
            if (this.Spellbook.Count > 0)
            {
                for (int i = 0; i < Spellbook.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Spellbook[i].Name);
                }
            }
            else
            {
                Console.WriteLine("your spellbook is empty...");
            }
        }
        
    }
}
