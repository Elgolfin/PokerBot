using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot
{
    public static class ConsoleHelper
    {
        public static void DrawProgressBar(int progress, int total)
        {
            if (progress % (total / 25) == 0)
            {
                int perc = progress / (total / 25) * 4;
                //draw empty progress bar
                Console.CursorLeft = 0;
                Console.Write("["); //start
                Console.CursorLeft = 26;
                Console.Write("]"); //end
                Console.CursorLeft = 1;
                float onechunk = 25.0f / total;

                //draw filled part
                int position = 1;
                for (int i = 0; i < onechunk * progress; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.CursorLeft = position++;
                    Console.Write(" ");
                }

                //draw unfilled part
                for (int i = position; i <= 25; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorLeft = position++;
                    Console.Write(" ");
                }

                //draw totals
                Console.CursorLeft = 30;
                Console.BackgroundColor = ConsoleColor.Black;
                //Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
                Console.Write(perc.ToString() + "%");
            }
        }
    }
}
