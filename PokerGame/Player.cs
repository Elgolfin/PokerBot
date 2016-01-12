using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nicomputer.PokerBot.PokerGame
{
    public class Player
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string DisplayName { get; set; }

        public Player(string name)
        {
            Name = name;
        }

    }
}
