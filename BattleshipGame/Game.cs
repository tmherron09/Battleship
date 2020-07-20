using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using static BattleshipGame.Program;

namespace BattleshipGame
{
    class Game
    {
        public Stream stdOut;
        public int width;
        public int height;
        public byte[] buf;
        CharInfo[] bufField;
        public SafeFileHandle h;


        // Battlefield Display variables
        int topPad;
        int leftPad;  // left and right padding must equal width - (playfield width * square size)
        int rightPad;  

        // Selection Variables
        int selectionIndex;

        // Playfield Variables
        int playfieldWidth;
        int playfieldHeight;

        public Game(Stream stdOut, SafeFileHandle h, int width, int height)
        {
            this.stdOut = stdOut;
            this.h = h;
            this.width = width;
            this.height = height;
            buf = new byte[width * height];
            bufField = new CharInfo[width * height];
            playfieldHeight = 20;
            playfieldWidth = 20;
        }

        public void RunGame()
        {
            InitializeGame();
            if (!h.IsInvalid)
            {

                do
                {
                    // Loop through buf

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo readKey = Console.ReadKey(true);
                        ReadPlayerInput(readKey.Key);                        
                        
                    }

                    // ReWrite to bufField
                    WriteToBuffer();

                    DrawToScreen();
                } while (true); // While no winner.




                Console.ReadLine();
            }
        }

        private void ReadPlayerInput(ConsoleKey readKey)
        {
            // Remove top padding and left padding to get index of 0,0 to calculate other x,y values.
            int selectionZeroed = selectionIndex - ((topPad * width) + leftPad);
            int displayX = selectionZeroed % (playfieldWidth * 2);
            int displayY = (selectionZeroed / (width - leftPad)) % (width - leftPad);
            int playfieldX = displayX / 2;
            int playfieldY = displayY / 2;
            if (readKey == ConsoleKey.RightArrow)
            {
                if (playfieldX % 20 == 19)
                {
                    selectionIndex -= (playfieldWidth * 2) -2;
                }
                else
                {
                    selectionIndex += 2; ;
                }
            }
            else if (readKey == ConsoleKey.LeftArrow)
            {
                if (playfieldX % 20 == 0)
                {
                    selectionIndex += (playfieldWidth * 2) - 2;
                }
                else
                {
                    selectionIndex -= 2;
                }
            }
            //else if (readKey == ConsoleKey.UpArrow)
            //{
            //    if (selectionIndex <= 19)
            //    {
            //        selectionIndex = bufField.Length - 20 + selectionIndex;
            //    }
            //    else
            //    {
            //        selectionIndex -= 20;
            //    }
            //}
            //else if (readKey == ConsoleKey.DownArrow)
            //{
            //    if (selectionIndex >= bufField.Length - 20)
            //    {
            //        selectionIndex = selectionIndex - bufField.Length + 20;
            //    }
            //    else
            //    {
            //        selectionIndex += 20;
            //    }
            //}
            //else if (readKey == ConsoleKey.Enter)
            //{

            //}
        }

        private void InitializeGame()
        {
            InitializeBlankBuffer();
            topPad = 3;
            //leftPad = 24; // if width 88
            //rightPad = 24; // if width 88
            leftPad = rightPad = (width - (playfieldWidth*2)) / 2; // padding is the total width - playfield * square size, divided by two.
            selectionIndex = ((0 + topPad) * (width) + (0 + leftPad));
            //selectionIndex = 326;
        }

        public void DrawToScreen()
        {
            SmallRect rectField = new SmallRect() { Left = 0, Top = 0, Right = (short)width, Bottom = (short)height };


            bool b = Program.WriteConsoleOutput(h, bufField,
                      new Coord() { X = (short)width, Y = (short)height },
                      new Coord() { X = 0, Y = 0 },
                      ref rectField);
        }

        public void InitializeBlankBuffer()
        {
            for (int i = 0; i < bufField.Length; i++)
            {
                bufField[i].Attributes = 0x0000;  // All Black
                bufField[i].Char.AsciiChar = 219;

            }


        }
        public void WriteToBuffer()
        {
            int[] index = new int[4];

            for (int i = 0; i < bufField.Length; i++)
            {
                for (int y = 0; y < 20; y++) // 20 = playfield height
                {
                    for (int x = 0; x < 20; x++) // 20 = playfield width
                    {
                        index = ReturnIndexSquare(x, y);
                        

                        if (index[0] == selectionIndex)
                        {
                            AssignColor(index, 0x0002);  // Make selection green.
                        }
                        else
                        {
                            AssignColor(index, 0x0001); // Make non-selected blue
                        }
                    }
                }

            }
        }

        public int[] ReturnIndexSquare(int x, int y)
        {
            int[] indexSquare = new int[4];
            indexSquare[0] = ((2 * y + topPad) * (width) + (2 * x + leftPad));
            indexSquare[1] = ((2 * y + topPad) * (width) + (2 * x + leftPad + 1));
            indexSquare[2] = ((2 * y + topPad + 1) * (width) + (2 * x + leftPad));
            indexSquare[3] = ((2 * y + topPad + 1) * (width) + (2 * x + leftPad + 1));
            return indexSquare;
        }
        public void AssignColor(int[] index, short color)
        {
            bufField[index[0]].Attributes = color;
            bufField[index[1]].Attributes = color;
            bufField[index[2]].Attributes = color;
            bufField[index[3]].Attributes = color;
        }

    }
}
