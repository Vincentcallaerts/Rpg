using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg
{
    class Hero : Entity 
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Hero()
        {
            Teken = "♀";
            Naam = "Hero";           
        }

    }
}
