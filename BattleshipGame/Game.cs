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

        public Game(Stream stdOut, SafeFileHandle h, int width, int height)
        {
            this.stdOut = stdOut;
            this.h = h;
            this.width = width;
            this.height = height;
            buf = new byte[width * height];
            bufField = new CharInfo[width * height];
        }

        public void RunGame()
        {
            if (!h.IsInvalid)
            {
                do
                {
                    // Loop through buf

                    if(Console.KeyAvailable)
                    {
                        
                        ConsoleKeyInfo readKey = Console.ReadKey(true);
                        
                        Console.WriteLine($"{readKey.KeyChar}");
                        //Thread.Sleep(200);
                    }


                } while (true); // While no winner.
                



                Console.ReadLine();
            }
        }
         public void DrawToScreen()
        {
            SmallRect rectField = new SmallRect() { Left = 0, Top = 0, Right = (short)width, Bottom = (short)height };


            bool b = Program.WriteConsoleOutput(h, bufField,
                      new Coord() { X = 20, Y = 20 },
                      new Coord() { X = 0, Y = 0 },
                      ref rectField);
        }

    }
}
