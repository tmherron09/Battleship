using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    abstract class Player
    {
        public int totalLifeRemaining;
        public List<Ship> ships;
        public List<int> misses; // List of buffer indexs of enemy misses on 'this'/ Player
        public List<int> hits; // List of buffer indexs of enemy hits on 'this'/ Player
        public List<int> sunkShips; // List buffer indexs of this players sunken ships

        public Player()
        {

        }

        public void CheckHit()
        {

        }

        public void GetHit()
        {

        }

        public abstract void ChooseTarget();
        
        public void UpdateField()
        {

        }

        

    }
}
