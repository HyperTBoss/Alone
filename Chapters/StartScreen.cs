using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure.Chapters
{
    class StartScreen
    {
        private static Vector2D PositionOne = new Vector2D();
        private static Vector2D PositionTwo = new Vector2D();
        private static Vector2D PositionThree = new Vector2D();
        private static Vector2D PositionFour = new Vector2D();

        private static readonly Vector2D PositionUpLeft = new Vector2D(0, 0);
        private static readonly Vector2D PositionDownRight = new Vector2D(Source.maxDrawWidth, Source.maxDrawHight);

        private static int OffsetX = 0;
        private static int OffsetY = 0;

        public static void Start()
        {
            AudioController.BusControl.PlayOGGAudioFiles(0, 0, 5);

            StartGraphics();

            StartMenu();

            ConsoleGraphics.ClearConsole();
        }

        private static void StartGraphics()
        {
            PositionCursor.Square(PositionUpLeft, PositionDownRight, "O", 2);
            PositionCursor.Square(new Vector2D(PositionUpLeft.X + 1, PositionUpLeft.Y + 1), new Vector2D(PositionDownRight.X - 1, PositionDownRight.Y - 1), "_", 2);
            PositionCursor.Line(new Vector2D(PositionUpLeft.X + 3, PositionDownRight.Y - 2), new Vector2D(PositionDownRight.X - 2, PositionDownRight.Y - 2), "-", 6);
        }

        private static void StartMenu()
        {

            PositionCursor.Textbox(new string[] {   
                    "Welcome, human. This adventure will be quite linear. I hope to remedy that in the future, but first; tell me your name...",
                    "In 3 months or so. Or less then that. I need time to develop this. As it is now, it's quite unfinshed. This just needs to be realesed before the End of March.",
                    "Now, I shall see you later."
                }, new Vector2D(PositionUpLeft.X + 5, PositionUpLeft.Y + 5), new Vector2D(PositionDownRight.X - 5, PositionDownRight.Y - 20), horizontalBuffer: 4, verticalBuffer: 4, userContinue: true, clearAfterParagrahp: false);

        }

        private static void SceneOne()
        {

        }
        
    }
}
