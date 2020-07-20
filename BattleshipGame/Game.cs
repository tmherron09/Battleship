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
        int leftPad;
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
            topPad = 0;
            //leftPad = 25;
            //rightPad = 25;
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

                        //Console.WriteLine($"{readKey.KeyChar}");
                        //Thread.Sleep(200);
                        
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
            int displayX = 0;
            int displayY = 0;
            int playfieldX = 0;
            int playfieldY = 0;
            if (readKey == ConsoleKey.RightArrow)
            {
                if (selectionIndex % 20 == 19)
                {
                    selectionIndex -= 19;
                }
                else
                {
                    selectionIndex++;
                }
            }
            else if (readKey == ConsoleKey.LeftArrow)
            {
                if (selectionIndex % 20 == 0)
                {
                    selectionIndex += 19;
                }
                else
                {
                    selectionIndex--;
                }
            }
            else if (readKey == ConsoleKey.UpArrow)
            {
                if (selectionIndex <= 19)
                {
                    selectionIndex = bufField.Length - 20 + selectionIndex;
                }
                else
                {
                    selectionIndex -= 20;
                }
            }
            else if (readKey == ConsoleKey.DownArrow)
            {
                if (selectionIndex >= bufField.Length - 20)
                {
                    selectionIndex = selectionIndex - bufField.Length + 20;
                }
                else
                {
                    selectionIndex += 20;
                }
            }
            else if (readKey == ConsoleKey.Enter)
            {

            }
        }

        private void InitializeGame()
        {
            InitializeBlankBuffer();
            leftPad = 0;
            rightPad = 44;
            selectionIndex = ((0 + topPad) * (playfieldWidth + leftPad) + (0 + leftPad));
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
            int index = 0;
            int indexTopRight = 0;
            int indexBottomLeft = 0;
            int indexBottomRight = 0;
            for (int i = 0; i < bufField.Length; i++)
            {
                for (int y = 0; y < 20; y++) // 20 = playfield height
                {
                    for (int x = 0; x < 20; x++) // 20 = playfield width
                    {
                        if (y != 0)
                        {
                            index = ((2*y + topPad) * (width ) + (2*x + leftPad));
                        }
                        else
                        {
                            index = ((2 * y + topPad) * (width + leftPad) + (2 * x + leftPad));
                        }
                        indexTopRight = ((2 * y + topPad) * (width) + (2 * x + leftPad + 1));
                        indexBottomLeft = ((2 * y + topPad + 1) * (width) + (2 * x + leftPad));
                        indexBottomRight = ((2 * y + topPad + 1) * (width) + (2 * x + leftPad + 1));

                        if (index == selectionIndex)
                        {
                            bufField[index].Attributes = 0x0002;
                            bufField[indexTopRight].Attributes = 0x0002;
                            bufField[indexBottomLeft].Attributes = 0x0002;
                            bufField[indexBottomRight].Attributes = 0x0002;
                        }
                        else
                        {
                            bufField[index].Attributes = 0x0001;
                            bufField[indexTopRight].Attributes = 0x0001;
                            bufField[indexBottomLeft].Attributes = 0x0001;
                            bufField[indexBottomRight].Attributes = 0x0001;
                        }
                    }
                }

            }
        }

    }
}
