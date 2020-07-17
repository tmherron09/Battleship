using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Window Setup
            Console.WindowWidth = 137;
            Console.WindowHeight = 40;

            // Start Game
            //Game game = new Game();
            //game.RunGame();
            PlayField playField = new PlayField();
            //playField.PlaceXMarker(0, 5);
            //playField.PlaceXMarker(4, 0);
            //playField.PlaceXMarker(19, 19);
            //playField.PlaceXMarker(9, 9);
            playField.PlaceTestMarker(9, 9, 9);
            playField.DrawPlayFieldForEach();
            playField.GetValueAtTestMarker(9, 9);
            Console.ReadLine();

        }
    }
}
