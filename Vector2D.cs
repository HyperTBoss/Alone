using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure
{
    class Vector2D
    {
        private int[] vector2D = new int[2];

        public int Y { set { vector2D[0] = value; } get { return vector2D[0]; } }
        public int X { set { vector2D[1] = value; } get { return vector2D[1]; } }

        public int Length
        {
            get
            {
                return GetLength();
            }
        }

        private readonly int x = 0;

        private readonly int y = 0;

        public int[] vector()
        {
            return vector2D;
        }
        //Deep and Shallow Copy
        public Vector2D ShallowCopy()
        {
            return (Vector2D)MemberwiseClone();
        }

        //Constructors

        public Vector2D()
        {
            X = 0;
            Y = 0;
        }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        //-- Gets another Vector's Values and stores it.
        public Vector2D(Vector2D other)
        {
            X = other.X;
            Y = other.Y;
        }

        //Method
        private int GetLength()
        {
            int sql = X * X + Y * Y;
            int len = (int)Math.Sqrt(sql);
            return len;
        }

        public void Reverse()
        {
            X = -X;
            Y = -Y;
        }

        public void Add(Vector2D otherVector)
        {
            X += otherVector.X;
            Y += otherVector.Y;
        }
        public void IntOverride(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Subtract(Vector2D otherVector)
        {
            X -= otherVector.X;
            Y -= otherVector.Y;
        }

        //Static Methods
        public static Vector2D Addition(Vector2D a, Vector2D b)
        {
            int totalX = a.X + b.X;
            int totalY = a.Y + b.Y;

            Vector2D totalVector = new Vector2D(totalX, totalY);

            return totalVector;
        }


        public bool Unitize()
        {
            int len = GetLength();
            if (len <= 0)
            {
                return false;
            }

            X /= len;
            Y /= len;

            return true;
        }

        public void Scale(int factor)
        {
            X *= factor;
            Y *= factor;
        }


        // Overrides
        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}
