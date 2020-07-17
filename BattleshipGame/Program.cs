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
            Game game = new Game();
            game.RunGame();


            Console.ReadLine();

        }
    }
}
