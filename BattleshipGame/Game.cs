using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Game
    {

        public Game()
        {

        }

        public void RunGame()
        {
            Battlefield battlefield = new Battlefield(20, 7, 5);
            Battlefield opponentField = new Battlefield(10, 72, 5);

            battlefield.Create2DBattlefield(8, 13);
            string field = battlefield.ToString2DArray(true);
            battlefield.DrawBattlefieldColor(field);
            battlefield.OutlineBattlefieldWithNumbers(4, 3, 20, 2);

            opponentField.Create2DBattlefield(10, 9, 11);
            string oppField = opponentField.ToString2DArray(10);
            TypeWriter.WriteLiteralColorCode(oppField, 72, 5);
            battlefield.OutlineBattlefieldWithNumbers(69, 3, 10, 2);

            Console.ReadLine();
        }

    }
}
