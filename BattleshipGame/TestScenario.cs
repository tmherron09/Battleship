using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class TestScenario
    {
        public void RunTestScenario(int caseTestNumber)
        {
            switch (caseTestNumber)
            {
                case 0:
                    Battlefield battlefield = new Battlefield(20, 7, 5);
                    Battlefield opponentField = new Battlefield(10, 72, 5);


                    battlefield.Create2DBattlefield();
                    battlefield.Battlefield2DArrayToLiteral();
                    battlefield.DrawBattlefieldColor();
                    battlefield.OutlineBattlefieldWithNumbers(4, 3, 20, 2);

                    opponentField.Create2DBattlefield();
                    opponentField.Battlefield2DArrayToLiteral();
                    opponentField.DrawBattlefieldColor();
                    battlefield.OutlineBattlefieldWithNumbers(69, 3, 10, 2);
                    break;
                case 1:
                    PlayField playField = new PlayField();
                    //playField.PlaceXMarker(0, 5);
                    //playField.PlaceXMarker(4, 0);
                    //playField.PlaceXMarker(19, 19);
                    //playField.PlaceXMarker(9, 9);
                    playField.PlaceTestMarker(9, 9, 9);
                    playField.DrawPlayFieldForEach();
                    playField.GetValueAtTestMarker(9, 9);
                    Console.ReadLine();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                default:
                    Console.WriteLine("No test scenario defined.");
                    break;
            }
            Console.ReadLine();
        }
    }
}
