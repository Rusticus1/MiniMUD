using Mini_MUD.Fields;
using Mini_MUD.Life;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_MUD
{
    class Program
    {
        static void Main(string[] args)
        {          
            
            Game dungeon = new Game();

            dungeon.Start();


            //fragen: enter() bool??  und dann moving bei Hero wenn true
            //fragen: ordner?
            //fragen: interface oder abstrakt für move / field
            // !!!! er zeigt mir die issues nicht an deshalb startet er automatisch die letzte funktionierende version!! daswill ich aber nicht
        }
    }
}
