using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    class Battlefield
    {
        public int[,] battlefield;
        public int gridSize;
        public int leftStartOfBattlefield;
        public int topStartOfBattlefield;
        public string literalBattlefield;

        
        public Battlefield(int gridSize, int leftStartOfBattlefield, int topStartOfBattlefield)
        {
            this.gridSize = gridSize;
            this.leftStartOfBattlefield = leftStartOfBattlefield;
            this.topStartOfBattlefield = topStartOfBattlefield;
            battlefield = new int[400, 3];
        }
        /// <summary>
        /// Create generic 2D array of 400, for a 20 x 20 grid.
        /// </summary>
        public void Create2DBattlefieldGeneric()
        {
            int y = -1;
            int x = 0;
            for (int a = 0; a < 400; a++)
            {
                if (a % 20 == 0)
                {
                    y++;
                    x = 0;
                }
                for (int b = 0; b < 3; b++)
                {
                    battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 0);
                    if (b == 0)
                    {
                        x++;
                    }
                }
            }
        }
        /// <summary>
        /// Create generic 2D array of 400, for a 20 x 20 grid.
        /// Add X and M markers based on modulo input.
        /// </summary>
        /// <param name="makeX">Place an 'X' every # spaces.</param>
        /// <param name="makeM">Place an 'M' every # spaces.</param>
        public void Create2DBattlefield(int makeX, int makeM)
        {
            int y = -1;
            int x = 0;
            for (int a = 0; a < 400; a++)
            {
                if ((a + 1) % 20 == 0)
                {
                    y++;
                    x = 0;
                }
                if ((a + 1) % makeX == 0)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 1);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }
                else if ((a + 1) % makeM == 0)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 2);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }
                else
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 0);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }

            }
        }
        /// <summary>
        /// Creates and returns an generic battlefield array with X and M based on input and modulos math.
        /// </summary>
        /// <param name="makeX">Insert '1' at modulos marker for X</param>
        /// <param name="makeM">Insert '2' at modulos marker for M</param>
        /// <returns></returns>
        public static int[,] ReturnGeneric2DBattlefieldArray(int makeX, int makeM)
        {
            int[,] battlefieldGeneric = new int[400, 3];
            int y = -1;
            int x = 0;
            for (int a = 0; a < 400; a++)
            {
                if ((a + 1) % 20 == 0)
                {
                    y++;
                    x = 0;
                }
                if ((a + 1) % makeX == 0)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefieldGeneric[a, b] = b == 0 ? x : (b == 1 ? y : 1);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }
                else if ((a + 1) % makeM == 0)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefieldGeneric[a, b] = b == 0 ? x : (b == 1 ? y : 2);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }
                else
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefieldGeneric[a, b] = b == 0 ? x : (b == 1 ? y : 0);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }
            }
            return battlefieldGeneric;
        }
        /// <summary>
        /// Create a 2D array based on a grid size input. (gridSize x gridSize)
        /// Add X and M markers based on modulo input.
        /// </summary>
        /// <param name="gridSize">Create an x*x size Battlefield.</param>
        /// <param name="makeX">Place an 'X' every # spaces.</param>
        /// <param name="makeM">Place an 'M' every # spaces.</param>
        public void Create2DBattlefield(int gridSize, int makeX, int makeM)
        {
            int y = -1;
            int x = 0;
            for (int a = 0; a < (gridSize * gridSize); a++)
            {
                if ((a + 1) % gridSize == 0)
                {
                    y++;
                    x = 0;
                }
                if ((a + 1) % makeX == 0)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 1);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }
                else if ((a + 1) % makeM == 0)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 2);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }
                else
                {
                    for (int b = 0; b < 3; b++)
                    {
                        battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 0);
                        if (b == 0)
                        {
                            x++;
                        }
                    }
                }

            }
        }
        /// <summary>
        /// Create a 2D array based on constructor grid size input. (gridSize x gridSize)
        /// </summary>
        /// <param name="gridSize">Create an x*x size Battlefield.</param>
        public void Create2DBattlefield()
        {
            int y = -1;
            int x = 0;
            for (int a = 0; a < (gridSize * gridSize); a++)
            {
                if ((a + 1) % gridSize == 0)
                {
                    y++;
                    x = 0;
                }
                for (int b = 0; b < 3; b++)
                {
                    battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 0);
                    if (b == 0)
                    {
                        x++;
                    }
                }
            }
        }
        /// <summary>
        /// Create a 2D array based on grid size input. (gridSize x gridSize)
        /// </summary>
        /// <param name="gridSize">Create an x*x size Battlefield.</param>
        public void Create2DBattlefield(int gridSize)
        {
            int y = -1;
            int x = 0;
            for (int a = 0; a < (gridSize * gridSize); a++)
            {
                if ((a + 1) % gridSize == 0)
                {
                    y++;
                    x = 0;
                }
                for (int b = 0; b < 3; b++)
                {
                    battlefield[a, b] = b == 0 ? x : (b == 1 ? y : 0);
                    if (b == 0)
                    {
                        x++;
                    }
                }
            }
        }
        /// <summary>
        /// Writes out the Array for Debugging.
        /// </summary>
        public void DebugWrite2DArray()
        {
            int count = 0;
            foreach (int number in battlefield)
            {
                if (count % 3 == 0)
                {
                    Console.Write($"{{ {number}, ");
                }
                else if (count % 3 == 1)
                {
                    Console.Write($"{number}, ");
                }
                else
                {
                    Console.Write($"{number} }}\n");
                }
                count++;
            }
        }
        /// <summary>
        /// Creates a generic string literal for a 20x20 grid.
        /// Instantiates and uses its local battlefield.
        /// </summary>
        /// <returns>String literal of a 20x20 grid with double spaces and '\n' line breaks.</returns>
        public string ReturnGenericBattlefieldStringLiteral()
        {
            int[,] battlefieldGeneric = new int[400, 3];
            int index = 0;
            string field = "";
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (battlefieldGeneric[index, 2] == 0)
                    {
                        field += "0";
                    }
                    if (x < 20)
                    {
                        field += "  ";
                    }
                }
                field += "\n";
            }
            return field;
        }
        /// <summary>
        /// Creates and returns a string literal with partial random X and M inserted into generic battlefield.
        /// </summary>
        /// <returns>string literal</returns>
        public static string ReturnGenericBattlefieldStringLiteralWithXM()
        {
            Random rng = new Random();
            int makeX = rng.Next(3, 18);
            int makeM = rng.Next(3, 18);
            int[,] battlefieldGeneric = ReturnGeneric2DBattlefieldArray(makeX, makeM);
            int index = 0;
            string field = "";
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (battlefieldGeneric[index, 2] == 0)
                    {
                        field += "0";
                    }
                    else if (battlefieldGeneric[index, 2] == 1)
                    {
                        field += "X";
                    }
                    else if (battlefieldGeneric[index, 2] == 2)
                    {
                        field += "M";
                    }
                    if (x < 19)
                    {
                        field += "  ";
                    }
                    index++;
                }
                field += "\n";
            }
            return field;
        }
        public string Battlefield2DArrayConvertToLiteral()
        {
            int index = 0;
            string field = "";
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    if (battlefield[index, 2] == 0)
                    {
                        field += "0";
                    }
                    else if (battlefield[index, 2] == 1)
                    {
                        field += "X";
                    }
                    else if (battlefield[index, 2] == 2)
                    {
                        field += "M";
                    }
                    if (x < gridSize - 1)
                    {
                        field += "  ";
                    }
                    index++;
                }
                field += "\n";
            }
            return field;
        }
        public void Battlefield2DArrayToLiteral()
        {
            int index = 0;
            string field = "";
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    if (battlefield[index, 2] == 0)
                    {
                        field += "0";
                    }
                    else if (battlefield[index, 2] == 1)
                    {
                        field += "X";
                    }
                    else if (battlefield[index, 2] == 2)
                    {
                        field += "M";
                    }
                    if (x < gridSize - 1)
                    {
                        field += "  ";
                    }
                    index++;
                }
                field += "\n";
            }
            this.literalBattlefield = field;
        }
        public void DrawBattlefieldColor()
        {
            int pos = 0;
            string drawLiteralBattlefield = literalBattlefield.Replace("\n", "¶");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(leftStartOfBattlefield, topStartOfBattlefield);
            foreach (char letter in drawLiteralBattlefield)
            {
                if (letter == '¶')
                {
                    topStartOfBattlefield += 1;
                    Console.SetCursorPosition(leftStartOfBattlefield, topStartOfBattlefield);
                }
                else if (letter == 'X')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(drawLiteralBattlefield[pos]);
                }
                else if (letter == 'M')
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write(drawLiteralBattlefield[pos]);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(drawLiteralBattlefield[pos]);
                }
                pos++;
            }
        }
        public void DrawBattlefieldColor(string battlefield2DArray)
        {
            int pos = 0;
            battlefield2DArray = battlefield2DArray.Replace("\n", "¶");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(leftStartOfBattlefield, topStartOfBattlefield);
            foreach (char letter in battlefield2DArray)
            {
                if (letter == '¶')
                {
                    topStartOfBattlefield += 1;
                    Console.SetCursorPosition(leftStartOfBattlefield, topStartOfBattlefield);
                }
                else if (letter == 'X')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(battlefield2DArray[pos]);
                }
                else if (letter == 'M')
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write(battlefield2DArray[pos]);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(battlefield2DArray[pos]);
                }
                pos++;
            }
        }
        public void DrawBattlefieldColor(string battlefield2DArray, int left, int top)
        {
            int pos = 0;
            battlefield2DArray = battlefield2DArray.Replace("\n", "¶");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);
            foreach (char letter in battlefield2DArray)
            {
                if (letter == '¶')
                {
                    top += 1;
                    Console.SetCursorPosition(left, top);
                }
                else if (letter == 'X')
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(battlefield2DArray[pos]);
                }
                else if (letter == 'M')
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Write(battlefield2DArray[pos]);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(battlefield2DArray[pos]);
                }
                pos++;
            }
        }

        public void OutlineBattlefield(int leftStart, int topStart)
        {
            Console.SetCursorPosition(leftStart, topStart);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("┌" + new string('─', 59) + "┐");
            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(leftStart, topStart + i);
                Console.WriteLine("|");
            }
            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(leftStart + 1, topStart + i);
                Console.WriteLine(" ");
            }
            Console.SetCursorPosition(leftStart, topStart + 21);
            Console.Write("└" + new string('─', 59) + "┘");
            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(leftStart + 60, topStart + i);
                Console.WriteLine("|");
            }
            for (int i = 1; i < 21; i++)
            {
                Console.SetCursorPosition(leftStart + 59, topStart + i);
                Console.WriteLine(" ");
            }

            //┌───────┐
            //│       │
            //└───────┘
        }
        public void OutlineBattlefieldWithNumbers(int leftStart, int topStart)
        {
            Console.SetCursorPosition(leftStart, topStart);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("┌" + new string('─', 61) + "┐");
            for (int i = 1; i < 22; i++)
            {
                Console.SetCursorPosition(leftStart, topStart + i);
                Console.WriteLine("|");
            }
            for (int i = 1; i < 22; i++)
            {
                Console.SetCursorPosition(leftStart + 2, topStart + i);
                Console.WriteLine(" ");
            }
            for (int i = 1; i < 21; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(leftStart + 1, topStart + i + 1);
                Console.WriteLine($"{i}");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.SetCursorPosition(leftStart, topStart + 22);
            Console.Write("└" + new string('─', 61) + "┘");

            for (int i = 1; i < 22; i++)
            {
                Console.SetCursorPosition(leftStart + 61, topStart + i);
                Console.WriteLine(" ");
            }
            Console.SetCursorPosition(leftStart + 1, topStart + 1);
            Console.Write("  ");
            for (int i = 1; i < 21; i++)
            {
                Console.Write($"{i,-3}");
            }
            for (int i = 1; i < 22; i++)
            {
                Console.SetCursorPosition(leftStart + 62, topStart + i);
                Console.WriteLine("|");
            }
        }
        // Grid is 20 x 20
        // 19 x 3 + 1 = 58
        // left start is -3 from field
        // top start is -2 from field
        // 61 = (grid-1) * (1 + number of spaces) + 4(spacing on either side)
        // 22 = (grid + 2)
        public void OutlineBattlefieldWithNumbers(int leftStart, int topStart, int gridSize, int spacing)
        {
            int widthValue = (gridSize - 1) * (1 + spacing) + 4;
            Console.SetCursorPosition(leftStart, topStart);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("┌" + new string('─', widthValue) + "┐");
            for (int i = 1; i < gridSize + 2; i++)
            {
                Console.SetCursorPosition(leftStart, topStart + i);
                Console.WriteLine("|");
            }
            for (int i = 1; i < gridSize + 2; i++)
            {
                Console.SetCursorPosition(leftStart + 2, topStart + i);
                Console.WriteLine(" ");
            }
            for (int i = 1; i < gridSize + 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(leftStart + 1, topStart + i + 1);
                Console.WriteLine($"{i}");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.SetCursorPosition(leftStart, topStart + gridSize + 2);
            Console.Write("└" + new string('─', widthValue) + "┘");

            for (int i = 1; i < gridSize + 2; i++)
            {
                Console.SetCursorPosition(leftStart + widthValue, topStart + i);
                Console.WriteLine(" ");
            }
            Console.SetCursorPosition(leftStart + 1, topStart + 1);
            Console.Write("  ");
            for (int i = 1; i < gridSize + 1; i++)
            {
                Console.Write($"{i,-3}");
            }
            for (int i = 1; i < gridSize + 2; i++)
            {
                Console.SetCursorPosition(leftStart + widthValue + 1, topStart + i);
                Console.WriteLine("|");
            }
        }

        //public void OutlineBattlefieldWithNumbers()
        //{
        //    int spaceing = 
        //    int widthValue = (gridSize - 1) * (1 + spacing) + 4;
        //    Console.SetCursorPosition(leftStart, topStart);
        //    Console.BackgroundColor = ConsoleColor.DarkGray;
        //    Console.ForegroundColor = ConsoleColor.Black;
        //    Console.Write("┌" + new string('─', widthValue) + "┐");
        //    for (int i = 1; i < gridSize + 2; i++)
        //    {
        //        Console.SetCursorPosition(leftStart, topStart + i);
        //        Console.WriteLine("|");
        //    }
        //    for (int i = 1; i < gridSize + 2; i++)
        //    {
        //        Console.SetCursorPosition(leftStart + 2, topStart + i);
        //        Console.WriteLine(" ");
        //    }
        //    for (int i = 1; i < gridSize + 1; i++)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Magenta;
        //        Console.SetCursorPosition(leftStart + 1, topStart + i + 1);
        //        Console.WriteLine($"{i}");
        //        Console.ForegroundColor = ConsoleColor.Black;
        //    }
        //    Console.SetCursorPosition(leftStart, topStart + gridSize + 2);
        //    Console.Write("└" + new string('─', widthValue) + "┘");

        //    for (int i = 1; i < gridSize + 2; i++)
        //    {
        //        Console.SetCursorPosition(leftStart + widthValue, topStart + i);
        //        Console.WriteLine(" ");
        //    }
        //    Console.SetCursorPosition(leftStart + 1, topStart + 1);
        //    Console.Write("  ");
        //    for (int i = 1; i < gridSize + 1; i++)
        //    {
        //        Console.Write($"{i,-3}");
        //    }
        //    for (int i = 1; i < gridSize + 2; i++)
        //    {
        //        Console.SetCursorPosition(leftStart + widthValue + 1, topStart + i);
        //        Console.WriteLine("|");
        //    }
        //}
    }
}
