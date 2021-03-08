using System;
using NAudio.Wave;
using NAudio.Vorbis;
using NVorbis;
using System.Threading;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Text_Adventure
{
    //To Do

    //Learn about the line algoeitm and place it in your program.
    //Make a Square
    //Make a Triangle
    //Learn about the circal drawing algoritm.
    //Implament the text box.
    //Add diffrent funtiions to Display output.
    //
    sealed class Source
    {
        //static int nScreenWidth = 120;
        //static int nScreenHeight = 60;

        //Cancles the options to Minimize, Maximize, Close and Resize the window.
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public readonly static int trueMaxWidth = 150;
        public readonly static int trueMaxHight = 40;

        public readonly static int maxBWidth = 150;
        public readonly static int maxBHight = 40;

        public readonly static int maxDrawWidth = 149;
        public readonly static int maxDrawHight = 39;

        static void Main(string[] args)
        {

            SetConsoleProperties(trueMaxWidth, trueMaxHight, maxBWidth, maxBHight);
            //All console related changes go here.

            InstalizeStoredInformation(); 
            //Gets information from ini files or settings files, then uses that information to modifie
            //the program or save data.
            
            ApplicationStart();
            //Where the Text Adventure game starts.
        }

        static void ApplicationStart()
        {
            try
            {
                Chapters.StartScreen.Start();


                Console.ForegroundColor = ConsoleColor.White;

                System.Threading.Thread.Sleep(1);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            //Application Start
            bool StartScreen = true;
            bool MainMenu = false;
            //Within Menu
                bool Options = false;
                bool StartGame = false;
                //Within Start game
                    //Chapter Initialization
                    bool ChapterStart = false;
                    bool ExitToMenu = false;
                    bool Pause = false;
                bool ExitGame = false;
                bool About = false;

        }
        static void InstalizeStoredInformation()
        {

        }
        static void SetConsoleProperties(int nScreenWidth, int nScreenHeight, int bScreenWidth, int bScreenHeight)
        {
            Console.Title = "The Legend of Heroes: Trails of the Ancient Civalization";
            Console.SetWindowSize(nScreenWidth, nScreenHeight);
            Console.SetBufferSize(bScreenWidth, bScreenHeight);

            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }

        }
    }
}
//To-Do

//