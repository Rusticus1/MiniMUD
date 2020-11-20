using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD.Life
{
    public class Mage : Hero
    {
        
        public List<Item> Spellbook { get; set; }
        public Mage(string name, int hitpoints, int mana, int baseDamage, List<Item> spellbook, List<Field> fieldlist, Field startfield) : base(name, hitpoints, baseDamage, fieldlist, startfield)
        {
            this.Spellbook = spellbook;           
        }
        
        public void UseSpell(int position) //auswahl aus dem spellbook als INT wird ausgeführt
        {
            int i = position - 1;
            if (this.Spellbook[i].Value <= this.Mana)
            {
                this.SpellDamage = this.Spellbook[i].Value;
                Console.WriteLine(this.Spellbook[i].Name + " cast for " + this.Spellbook[i].Value + " damage");
                this.Mana -= this.Spellbook[i].Value;
            }
            else
            {
                Console.WriteLine("not enough mana!");
            }
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
