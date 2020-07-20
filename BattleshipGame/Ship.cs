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
        public List<int[]> shipPlayFieldXY;
        public bool isPlaced;
        public bool isBeingPlace;

        public Ship(string name, int length)
        {
            this.name = name;
            this.length = length;
            health = length;
            this.isPlaced = false;
            shipPlayFieldXY = new List<int[]>();
        }
        
        public void SuccessfulHit()
        {

        }
        public void SetShipLocation(int[] playfieldPosition, Game.PlacementDirection direction)
        {
            shipPlayFieldXY.Add(playfieldPosition);
            for (int i = 1; i < length; i++)
            {
                switch (direction)
                {
                    case Game.PlacementDirection.Right:
                        {
                            shipPlayFieldXY.Add(new int[] { playfieldPosition[0] + i, playfieldPosition[1] });
                            break;
                        }

                    case Game.PlacementDirection.Down:
                        {

                            shipPlayFieldXY.Add(new int[] { playfieldPosition[0], playfieldPosition[1] + 1 });
                            break;
                        }

                    case Game.PlacementDirection.Left:
                        {
                            shipPlayFieldXY.Add(new int[] { playfieldPosition[0] - i, playfieldPosition[1] });

                            break;
                        }

                    case Game.PlacementDirection.Up:
                        {
                            shipPlayFieldXY.Add(new int[] { playfieldPosition[0], playfieldPosition[1] - i });

                            break;
                        }
                }
            }
        }
        
    }
}
