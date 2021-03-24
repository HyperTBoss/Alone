using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace Text_Adventure
{
    //This class will act as the sender and modifier for UserData and ChapterTextStorage.
    class DataInterface
    {
        private class DataStorageTempObject
        {
            private int Int { get; set; }
            private string String { get; set; }
            private char Char { get; set; }
            private string Vector2D { get; set; }
            public DataStorageTempObject(int interger = 0, string sequenceOfChar = " ", char character = ' ', int Vector2DMatrixX = 0, int Vector2DMatrixY = 0) //Yes, it looks like a penis.
            {
                Int = interger;
                String = sequenceOfChar;
                Char = character;
                Vector2D = Vector2DMatrixX.ToString() + Vector2DMatrixY.ToString();
            }
            // Other properties, methods, events...
        }

        static public void ReadFile(string fileName, string optionToExtract, string TypeID)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            DataStorageTempObject storageObject = new DataStorageTempObject();

            switch (TypeID)
            {
                case "int":
                    break;
                case "string":
                    break;
                case "char":
                    break;
                case "Vector2D":
                    break;
                default:
                    break;
            }

            fs.Close();
        }
        static public void WriteFile(string fileName, string propertieToEnter, string TypeID)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            switch (TypeID)
            {
                case "int":
                    if (fs.CanWrite)
                    {
                        byte[] buffer = Encoding.ASCII.GetBytes(propertieToEnter);
                        fs.Write(buffer, 0, buffer.Length);
                    }
                    break;
                case "string":
                    break;
                case "char":
                    break;
                case "Vector2D":
                    break;
                default:
                    break;
            }

            fs.Flush();
            fs.Close();

        }


    }
}
