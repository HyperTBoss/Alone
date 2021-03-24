using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Text_Adventure
{
    sealed class PositionCursor
    {
        //Options
        public static int typeSpeed { get; set; } = 10;
        public static int typeRandomSpeed { get; set; } = 2;
        public static int endWaitingTime { get; set; } = 100;
        public static int CharSpacing { get; set; } = 1;

        private static int screenMaxWidth = Source.maxDrawWidth + 1;
        private static int screenMaxHight = Source.maxDrawHight;

        //private Thread Start = new Thread(StartBefore);
        //private Thread End = new Thread(FinishAfter);

        private static Vector2D OptionalAugOne = new Vector2D();
        private static Vector2D OptionalAugTwo = new Vector2D();
        static private Vector2D GetCursoirPosition()
        {
            return new Vector2D(Console.CursorLeft, Console.CursorTop);
        }

        //Drawing Lines, Circals and Triangles.
        static public void PlaceCursorPosition(Vector2D vectorPos)
        {
            int x = vectorPos.X;
            int y = vectorPos.Y;

            Console.SetCursorPosition(x, y);
        }

        //Tests current cursour position.
        private static bool TestUserCursorPosition()
        {
            Vector2D cursourPointTest = GetCursoirPosition();

            if (cursourPointTest.X > screenMaxWidth || cursourPointTest.X == -1)
            {
                return true;
            }

            if (cursourPointTest.Y > screenMaxHight || cursourPointTest.Y == -1)
            {
                return true;
            }

            return false;
        }

        //Waits for user input.
        public static void UserWait(int colour = 15)
        {
            Vector2D cursourPointTest = GetCursoirPosition();

            ConsoleKeyInfo cki;

            cursourPointTest = GetCursoirPosition();
            bool wait = true;
            while (wait)
            {
                while (Console.KeyAvailable == false)
                {
                    PlaceCursorPosition(new Vector2D(cursourPointTest.X + 1, cursourPointTest.Y));
                    ConsoleGraphics.DrawText("|>", colour);

                    Thread.Sleep(400);

                    PlaceCursorPosition(new Vector2D(cursourPointTest.X + 1, cursourPointTest.Y));
                    ConsoleGraphics.DrawText("  ", colour);

                    Thread.Sleep(400);
                }

                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Enter)
                {
                    wait = false;
                }
            }
        }
        /**
         * This will produce a line from point a/CurrentPosition to point b/EndPosition.
         * This method will be used with all other methods below, however: 
         * I think that I will need to remove the line drawing algorithm to it's own seperate method.
         * This'll make it more segmented and clean.
        **/

        static private void LineDrawing(Vector2D CurrentPosition, Vector2D EndPosition, string wantedChar, int colour = 15)
        {

            int w = EndPosition.X - CurrentPosition.X;
            int h = EndPosition.Y - CurrentPosition.Y;

            Vector2D currentPosition = CurrentPosition.ShallowCopy();

            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;

            for (int i = 0; i <= longest; i++)
            {
                if (TestUserCursorPosition() == true)
                {
                    PlaceCursorPosition(new Vector2D (0,0));
                    break;
                }

                PlaceCursorPosition(currentPosition);

                Console.ForegroundColor = ConsoleColor.White;
                
                ConsoleGraphics.DrawText(wantedChar, colour);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    currentPosition.X += dx1;
                    currentPosition.Y += dy1;
                }
                else
                {
                    currentPosition.X += dx2;
                    currentPosition.Y += dy2;
                }
            }

        }
        static public void Point(Vector2D CurrentPosition,string wantedChar, int colour = 15)
        {
            PlaceCursorPosition(CurrentPosition);
            ConsoleGraphics.DrawText(wantedChar, colour);
        }

        static public void Line(Vector2D CurrentPosition, Vector2D EndPosition, string wantedChar, int colour = 15)
        {
            LineDrawing(CurrentPosition, EndPosition, wantedChar, colour);
        }

        static public void Square(Vector2D CurrentPosition, Vector2D EndPosition, string wantedChar, int colour = 15)
        {
            Vector2D pointOne = new Vector2D(CurrentPosition.X, CurrentPosition.Y);
            Vector2D pointTwo = new Vector2D(EndPosition.X, CurrentPosition.Y);
            Vector2D pointThree = new Vector2D(EndPosition.X, EndPosition.Y);
            Vector2D pointFour = new Vector2D(CurrentPosition.X, EndPosition.Y);

            LineDrawing(pointOne, pointTwo, wantedChar, colour);
            LineDrawing(pointTwo, pointThree, wantedChar, colour);
            LineDrawing(pointThree, pointFour, wantedChar, colour);

            //The reason why I've reasigned the variable is that there's something giving pointOne a new X value.
            pointOne = new Vector2D(CurrentPosition.X, CurrentPosition.Y);

            LineDrawing(pointFour, pointOne, wantedChar, colour);
        }

        static public void Triangle(Vector2D CurrentPosition, Vector2D MiddlePosition, Vector2D EndPosition, string wantedChar, int colour = 15)
        {
            Vector2D pointOne = new Vector2D(CurrentPosition.X, CurrentPosition.Y);
            Vector2D pointTwo = new Vector2D(MiddlePosition.X, MiddlePosition.Y);
            Vector2D pointThree = new Vector2D(EndPosition.X, EndPosition.Y);

            LineDrawing(pointOne, pointTwo, wantedChar, colour);
            LineDrawing(pointTwo, pointThree, wantedChar, colour);

            //The reason why I've reasigned the variable is that there's something giving pointOne a new X value.
            pointOne = new Vector2D(CurrentPosition.X, CurrentPosition.Y);

            LineDrawing(pointThree, pointOne, wantedChar, colour);
        }
        static public void Circal(Vector2D CurrentPosition, Vector2D Radius, Vector2D vectorPos)
        {

        }

        //Text based input
        static public void Textbox(string[] Paragrahp, Vector2D BoundboxUpLeft, Vector2D BoundboxDownRight, string wantedCharBoundBox = null, int horizontalBuffer = 0, int verticalBuffer = 1, int paragrahpSpaceingbool = 0, bool userContinue = false, bool clearAfterParagrahp = false, int colour = 15)
        {

            //Store a broken down Paragrahps with a List
            string[][] stringParagraphStorage = storeStrings(Paragrahp);

            Vector2D testForOutsideValues = new Vector2D(BoundboxDownRight.X - BoundboxUpLeft.X, BoundboxDownRight.Y - BoundboxUpLeft.Y);

            if (testForOutsideValues.X < 0 && testForOutsideValues.Y < 0)
            {
                throw new InvalidOperationException("The Vector2D BoundboxUpLeft argument cannot be smaller then the Vector2D BoundboxDownRight argument.");
            }

            Vector2D cursourStartingPoint = new Vector2D(BoundboxUpLeft.X + 1, BoundboxUpLeft.Y + 1); //This will be used to position the cursor to it's starting position.

            cursourStartingPoint.Add(new Vector2D(horizontalBuffer, verticalBuffer)); //Adds buffer value.

            Square(BoundboxUpLeft, BoundboxDownRight, wantedCharBoundBox);

            PlaceCursorPosition(cursourStartingPoint);

            Vector2D cursourRepositionPoint = new Vector2D(cursourStartingPoint);

            for (int paragrahpLooper = 0; paragrahpLooper < stringParagraphStorage.Length; paragrahpLooper++)
            {
                Vector2D cursourPointTest = GetCursoirPosition();

                if (clearAfterParagrahp == true)
                {
                    ConsoleGraphics.ClearSquareArea(cursourStartingPoint, new Vector2D(BoundboxDownRight.X - horizontalBuffer - horizontalBuffer, BoundboxDownRight.Y - verticalBuffer - verticalBuffer));

                    cursourRepositionPoint = new Vector2D(cursourStartingPoint);
                }

                for (int wordLooper = 0; wordLooper < stringParagraphStorage[paragrahpLooper].Length; wordLooper++)
                {
                    Console.CursorVisible = true;
                    cursourPointTest = GetCursoirPosition();

                    //Checks to see if the cursor hit the boundry to the max Y
                    if (cursourPointTest.Y > BoundboxDownRight.Y - verticalBuffer - 2)
                    {
                        if (userContinue == true)
                        {
                            Console.CursorVisible = false;
                            UserWait();

                            ConsoleGraphics.ClearSquareArea(cursourStartingPoint, new Vector2D(BoundboxDownRight.X - 2, BoundboxDownRight.Y - verticalBuffer - 2));

                            cursourRepositionPoint = new Vector2D(cursourStartingPoint);

                        }

                    }

                    int lengthString = stringParagraphStorage[paragrahpLooper][wordLooper].Length;
                    //Checks to see if the cursor hit the boundry to the max X
                    if (cursourPointTest.X > BoundboxDownRight.X - horizontalBuffer - lengthString)
                    {
                        cursourRepositionPoint.Y += 1;
                        PlaceCursorPosition(cursourRepositionPoint);
                    }
                    ConsoleGraphics.DrawText(stringParagraphStorage[paragrahpLooper][wordLooper], colour);
                    Thread.Sleep(typeSpeed);
                }

                if (userContinue == true)
                {
                    Console.CursorVisible = false;
                    UserWait();
                }

                cursourRepositionPoint.Y += horizontalBuffer + paragrahpSpaceingbool;
                PlaceCursorPosition(cursourRepositionPoint);
            }

        }

        private static string[][] storeStrings(string[] Paragrahp)
        {
            string[][] brokenParagrahpStorage = new string[Paragrahp.Length][];

            for (int i = 0; i < Paragrahp.Length; i++)
            {
                //Breaks down paragrahps

                //string[] stringParagraphTemp = Paragrahp[i].Split(" ");
                string[] stringParagraphTemp = Regex.Split(Paragrahp[i], "( )");

                brokenParagrahpStorage[i] = stringParagraphTemp;
            }
            return brokenParagrahpStorage;
        }

    }
}
