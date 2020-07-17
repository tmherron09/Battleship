using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class PlayField
    {
        public int[,] playFieldArray;

        public PlayField()
        {
            playFieldArray = new int[20, 20];
        }


        public void DrawPlayField()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (playFieldArray[x, y] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(playFieldArray[x, y]);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(playFieldArray[x, y]);
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public void DrawPlayFieldForEach()
        {
            int count = 0;
            foreach(int value in playFieldArray)
            {
                if (value == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(value);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(value);
                }
                count++;
                if(count == 20)
                {
                    Console.WriteLine();
                    count = 0;
                }
            }
            Console.ResetColor();
        }
        public void PlaceXMarker(int x, int y)
        {
            playFieldArray[x, y] = 1;
        }
        public void PlaceTestMarker(int x, int y, int testMarker)
        {
            playFieldArray[x, y] = testMarker;
        }
        public void GetValueAtTestMarker(int[] position)
        {
            int value = (int)playFieldArray.GetValue(position);
            int value2 = Convert.ToInt32(playFieldArray.GetValue(position));
            Console.WriteLine($"{value}");
            Console.WriteLine($"{value2}");
        }
        public void GetValueAtTestMarker(int x, int y)
        {
            int value3 = playFieldArray[x, y];
            Console.WriteLine($"{value3}");
            // Unnecessary creation of another array?
            int[] position = new int[] { x, y };
            int value = (int)playFieldArray.GetValue(position);
            int value2 = Convert.ToInt32(playFieldArray.GetValue(position));
            Console.WriteLine($"{value}");
            Console.WriteLine($"{value2}");
            int[,][] arrayHolder;
        }

    }
}
