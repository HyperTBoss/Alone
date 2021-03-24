using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Text_Adventure {
    sealed class ConsoleGraphics
    {
        static public int screenMaxWidth = Source.maxDrawWidth;
        static public int screenMaxHight = Source.maxDrawHight;

        //Testing Console Wrting Speeds
        public static class FastConsole
        {
            static readonly BufferedStream str;

            static FastConsole()
            {
                Console.OutputEncoding = Encoding.Unicode;  // crucial

                // avoid special "ShadowBuffer" for hard-coded size 0x14000 in 'BufferedStream' 
                str = new BufferedStream(Console.OpenStandardOutput(), 0x15000);
            }

            public static void WriteLine(String s) => Write(s + "\r\n");

            public static void Write(String s)
            {
                // avoid endless 'GetByteCount' dithering in 'Encoding.Unicode.GetBytes(s)'
                var rgb = new byte[s.Length << 1];
                Encoding.Unicode.GetBytes(s, 0, s.Length, rgb, 0);

                lock (str)   // (optional, can omit if appropriate)
                    str.Write(rgb, 0, rgb.Length);
            }

            public static void Flush() { lock (str) str.Flush(); }
        };

        static public bool outoffBounds = false;
        static private ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        static private ConsoleColor currentBackground = Console.BackgroundColor;
        static private ConsoleColor currentForeground = Console.ForegroundColor;

        static public void DrawText(string main, int textColour)
        {
            int cursorPosLeft = Console.CursorLeft;
            int cursorPosTop = Console.CursorTop;

            if (cursorPosLeft > 150 || cursorPosLeft < 0)
            {
                if (cursorPosTop > 40 || cursorPosTop < 0)
                {
                    return;
                }
            }
            else
            {
                Console.ForegroundColor = colors[textColour];

                //FastConsole.Write(main);
                //FastConsole.Flush();

                Console.Write(main);
            }
        }
        static public void ClearCurrentLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static public void ClearLineVectorToVector(Vector2D cursourStartPosition, Vector2D cursourEndPosition)
        {
            Console.SetCursorPosition(cursourStartPosition.X, cursourStartPosition.Y);
            Console.Write(new string(' ', cursourEndPosition.X));
            Console.SetCursorPosition(cursourEndPosition.X, cursourEndPosition.Y);
        }
        static public void ClearSquareArea(Vector2D positionUpLeft, Vector2D positionDownRight)
        {
            for (int i = 0; i < positionDownRight.Y; i++)
            {
                Console.SetCursorPosition(positionUpLeft.X - 1, positionUpLeft.Y + i);
                Console.Write(new string(' ', positionDownRight.X));
            }

            Console.SetCursorPosition(positionUpLeft.X, positionUpLeft.Y);
        }


        static public void ClearConsole()
        {
            Console.Clear();
        }

        static public void RestoreColourForeBack(int whatToRestore)
        {
            if (whatToRestore < 1)
            {
                Console.WriteLine("Index Exception. Cannot restore cases above 1");
                return;
            }
            else
            {
                switch (whatToRestore)
                {
                    case 0:
                        Console.BackgroundColor = currentBackground;
                        break;
                    case 1:
                        Console.ForegroundColor = currentForeground;
                        break;
                    default:
                        break;
                }
            }
        }

        static public void ChangeBackgroundColour(int textColour)
        {
            Console.BackgroundColor = colors[textColour];
        }
        static public void RestartColour()
        {
            Console.ResetColor();
        }

        //These methods will simply be me storing specific Art. Like a Logo, Importent Words, Links and so on. 
        //Genral chapter art will be shoved inside a Graphics Class inside Chapters.
        //All specific are will be shoved along side each chapter, within there own folders.
    }
}
