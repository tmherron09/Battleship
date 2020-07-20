using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Ship
    {
        string name;
        int length;
        int health;
        public int shipBufferLocaltion;
        public int[] shipPlayFieldXY;

        public Ship(string name, int length)
        {
            this.name = name;
            this.length = length;
            health = length;
        }
        
        
        
    }
}
