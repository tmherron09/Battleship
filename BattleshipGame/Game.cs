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
        int downCount;


        // Battlefield Display variables
        int topPad;
        int bottomPad;
        int leftPad;  // left and right padding must equal width - (playfield width * square size)
        int rightPad;
        int startLocation;
        string lowerMessage;
        bool showLowerMessage;

        // Selection Variables
        int selectionIndex;

        // Playfield Variables
        int playfieldWidth;
        int playfieldHeight;

        // Game variables
        bool isFirstRound;
        bool isChangePlayer;

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
            downCount = 0; // test variable
            lowerMessage = "";
            isFirstRound = true;
            
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
                    if (!showLowerMessage)
                    {
                        RemoveLowerMessage();
                    }
                    DisplayLowerMessage();
                    DrawToScreen();
                    
                    if(isChangePlayer)
                    {
                        isChangePlayer = false;
                    }
                    if(isFirstRound)
                    {
                        foreach

                        isFirstRound = false;
                    }
                } while (true); // While no winner.
                Console.ReadLine();
            }
        }

        private void RemoveLowerMessage()
        {
            for (int i = startLocation; i < startLocation + width; i++)
            {
                bufField[i].Char.UnicodeChar = ' ';
            }
            lowerMessage = "";
        }

        private void DisplayLowerMessage()
        {
            int leftStart = startLocation + (width - lowerMessage.Length) / 2;
            for(int i = 0; i < lowerMessage.Length; i++)
            {
                bufField[leftStart + i].Char.UnicodeChar = lowerMessage[i];
                bufField[leftStart + i].Attributes = 0x0008;
            }
        }

        private void ReadPlayerInput(ConsoleKey readKey)
        {
            downCount++;
            // Remove top padding and left padding to get index of 0,0 to calculate other x,y values.
            int selectionZeroed = ((topPad * width) + leftPad);
            int displayX = (selectionIndex % width) - leftPad;
            int displayY = ((selectionIndex - selectionZeroed) / (width)) % width;
            int playfieldX = displayX / 2;
            int playfieldY = displayY / 2;
            if (readKey == ConsoleKey.RightArrow)
            {
                if (playfieldX == 19)
                {
                    selectionIndex -= (playfieldWidth * 2) - 2;
                }
                else
                {
                    selectionIndex += 2; ;
                }
            }
            else if (readKey == ConsoleKey.LeftArrow)
            {
                if (playfieldX == 0)
                {
                    selectionIndex += (playfieldWidth * 2) - 2;
                }
                else
                {
                    selectionIndex -= 2;
                }
            }
            else if (readKey == ConsoleKey.DownArrow)
            {
                if (playfieldY == 19)
                {
                    selectionIndex = selectionZeroed + displayX;
                }
                else
                {
                    selectionIndex += 2 * width;
                }
            }
            else if (readKey == ConsoleKey.UpArrow)
            {
                if (playfieldY == 0)
                {
                    selectionIndex = selectionIndex + ((playfieldHeight * 2) - 2) * width;
                }
                else
                {
                    selectionIndex -= 2 * width; ;
                }
            }
            else if (readKey == ConsoleKey.Enter)
            {
                lowerMessage = "Enter key pressed...";
                showLowerMessage = true;
            }
            else if (readKey == ConsoleKey.Spacebar)
            {
                showLowerMessage = false ;
                isChangePlayer = true;
            }
        }

        private void InitializeGame()
        {
            InitializeBlankBuffer();
            topPad = bottomPad = (height - playfieldHeight * 2) / 2;
            leftPad = rightPad = (width - (playfieldWidth * 2)) / 2; // padding is the total width - playfield * square size, divided by two.
            selectionIndex = ((0 + topPad) * (width) + (0 + leftPad));
            //Get the starting index of the Lower Message Line.
            // Bottom line middle needs to be one less to start on the line and not the next. If even minus 1, if odd it will round down.
            int bottomMiddleLine = bottomPad % 2 == 0 ? (bottomPad / 2) - 1 : bottomPad / 2;
            startLocation = (topPad + bottomMiddleLine + (playfieldHeight * 2)) * width;
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


            for (int y = 0; y < playfieldHeight; y++) // 20 = playfield height
            {
                for (int x = 0; x < playfieldWidth; x++) // 20 = playfield width
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
