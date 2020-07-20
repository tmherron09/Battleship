using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Ship
    {
        public string name;
        public int length;
        public int health;
        public int shipBufferLocaltion;
        public int[] shipPlayFieldXY;
        public bool isPlaced;
        public bool isBeingPlace;

        public Ship(string name, int length)
        {
            this.name = name;
            this.length = length;
            health = length;
            this.isPlaced = false;
        }
        
        public void SuccessfulHit()
        {

        }
        
    }
}
