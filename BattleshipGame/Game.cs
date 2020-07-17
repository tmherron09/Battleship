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

            //battlefield.Create2DBattlefield(8, 13);
            battlefield.Create2DBattlefield();
            battlefield.Battlefield2DArrayToLiteral();
            battlefield.DrawBattlefieldColor();
            battlefield.OutlineBattlefieldWithNumbers(4, 3, 20, 2);

            opponentField.Create2DBattlefield();
            opponentField.Battlefield2DArrayToLiteral();
            opponentField.DrawBattlefieldColor();
            battlefield.OutlineBattlefieldWithNumbers(69, 3, 10, 2);

            Console.ReadLine();
        }

    }
}
