using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.PokerGame
{
    public class Table
    {
        public List<Player> Players;
        public List<Seat> Seats;
        private int turn = 0;
        public bool IsOpened = true;
        public Dictionary<int, List<string>> Logs = new Dictionary<int, List<string>>(); // Will log all actions that will happen during the lifecycle of the table, player after player, turn after turn

        public Dealer Dealer { get; set; }
        public List<Card> Board { get; set; }
        public int Size {
            get { return Seats.Count; }
            private set { }
        }

        public Table(int numberOfSeats, Dealer dealer, Deck52Cards deck)
        {
            OpenTable(numberOfSeats, dealer, deck);
        }

        public void OpenTable(int size, Dealer dealer, Deck52Cards deck)
        {
            Dealer = dealer;
            dealer.Table = this;
            turn = 0;
            ShufflePlayers();
            for (int i = 0 ; i < size ; i++)
            {
                Seats.Add(new Seat(i, Players[i]));
            }
            IsOpened = true;
        }

        public void CloseTable()
        {
            Dealer.Table = null;
            Dealer.Deck = null;
            Dealer = null;
            foreach (var seat in Seats)
            {
                seat.RemovePlayer();
            }
            IsOpened = false;
        }

        private static readonly Random R = new Random();
        public void ShufflePlayers()
        {
            for (var n = Players.Count - 1; n > 0; --n)
            {
                var k = R.Next(n + 1);
                var temp = Players[n];
                Players[n] = Players[k];
                Players[k] = temp;
            }
        }
    }
}
