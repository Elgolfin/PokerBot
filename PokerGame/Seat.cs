using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.PokerGame
{
    public class Seat
    {
        public Player Player;
        public Hand Hand;
        public int Number;

        public Seat(int number, Player player)
        {
            Number = number;
            AssignPlayer(player);
        }

        public void AssignPlayer(Player player)
        {
            Player = player;
        }

        public void RemovePlayer()
        {
            Player = null;
            Hand = null;
        }

        public bool IsEmpty
        {
            get
            {
                if (Player == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            private set { }
        }
    }
}
