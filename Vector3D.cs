using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure
{
    public sealed class Vector3D
    {
        private int[] vector3D = new int[3];

        public int Y { set { vector3D[0] = value; } get { return vector3D[0]; } }
        public int X { set { vector3D[1] = value; } get { return vector3D[1]; } }
        public int Z { set { vector3D[2] = value; } get { return vector3D[2]; } }

        public int Length
        {
            get
            {
                return GetLength();
            }
        }

        private readonly int x = 0;

        private readonly int y = 0;

        private readonly int z = 0;

        public int[] vector()
        {
            return vector3D;
        }
        //Deep and Shallow Copy
        public Vector3D ShallowCopy()
        {
            return (Vector3D)MemberwiseClone();
        }

        //Constructors

        public Vector3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //-- Gets another Vector's Values and stores it.
        public Vector3D(Vector3D other)
        {
            X = other.X;
            Y = other.Y;
            Z = other.Z;
        }

        //Method
        private int GetLength()
        {
            int sql = X * X + Y * Y + Z * Z;
            int len = (int)Math.Sqrt(sql);
            return len;
        }

        public void Reverse()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

        public void Add(Vector3D otherVector)
        {
            X += otherVector.X;
            Y += otherVector.Y;
            Z += otherVector.Z;
        }
        public void IntOverride(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public void Subtract(Vector3D otherVector)
        {
            X -= otherVector.X;
            Y -= otherVector.Y;
            Z -= otherVector.Z;
        }

        //Static Methods
        public static Vector3D Addition(Vector3D a, Vector3D b)
        {
            int totalX = a.X + b.X;
            int totalY = a.Y + b.Y;
            int totalZ = a.Z + b.Z;

            Vector3D totalVector = new Vector3D(totalX, totalY, totalZ);

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
            Z /= len;

            return true;
        }

        public void Scale(int factor)
        {
            X *= factor;
            Y *= factor;
            Z *= factor;
        }


        // Overrides
        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}]";
        }
    }
}
