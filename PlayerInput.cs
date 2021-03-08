using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure
{
    //This will act as the storage for what keys the player wants to use. This will remove the need to constently type console.read()

    sealed class PlayerInput
    {
        static public bool KeyIsPressed(string keyCheck)
        {
            var cki = Console.ReadKey();

            switch (keyCheck)
            {
                case "A":
                    if (cki.Key == ConsoleKey.A)
                        return true;
                    break;
                case "S":
                    if (cki.Key == ConsoleKey.S)
                        return true;
                    break;
                case "D":
                    if (cki.Key == ConsoleKey.D)
                        return true;
                    break;
                case "Enter":
                    if (cki.Key == ConsoleKey.Enter)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }
    }
}
