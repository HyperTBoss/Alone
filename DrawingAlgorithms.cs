using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure
{
    class DrawingAlgorithms
    {
        private static int screenMaxWidth = Source.maxDrawWidth + 1;
        private static int screenMaxHight = Source.maxDrawHight;

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

        public virtual void  Start()
        {

        }
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
                    PlaceCursorPosition(new Vector2D(0, 0));
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

        static private void CircialDrawing(Vector2D CurrentPosition, Vector2D EndPosition, string wantedChar, int colour = 15)
        {

        }

        static private void ThreeDLIneDrawing(Vector2D CurrentPosition, Vector2D EndPosition, string wantedChar, int colour = 15)
        {

        }

        static private void ThreeDCircialDrawing(Vector2D CurrentPosition, Vector2D EndPosition, string wantedChar, int colour = 15)
        {

        }
    }
}
