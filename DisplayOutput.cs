using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure
{
    //This class will act as an output for strings and number values.
    //There will be a value whitch will determin how many words it takes to wrap the string/paragrahp/sentence.
    //There will be other options to add certin effects tow ards the text.


    sealed class DisplayOutput
    {

        string words;
        char characters;
        char spaces;

        private int[] futurePos = new int[2] { 0, 0 };

        List<int[]> listOfpastPoints = new List<int[]>();

        public void displayText(string main)
        {

        }

        public void animateText(string main)
        {

        }
    }
}
