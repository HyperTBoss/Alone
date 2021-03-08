using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Adventure.Chapters
{
    class StartScreen
    {
        public static void Start()
        {
            AudioController.BusControl.PlayOGGAudioFiles(0, 0, 8);

            PositionCursor.Textbox(new string[] {
                    "Welcome, human. This adventure will be quite linear. I hope to remedy that in the future, but first; tell me your name...",
                    "In 3 months or so. Or less then that. I need time to develop this reality. As it is now, it's quite unfinshed. This just needs to be realesed before Feburary 8th.",
                    "Now, I shall see you later."
                }, new Vector2D(0, 0), new Vector2D(149, 10), "x", 1, 2, true, true);
        }
    }
}
