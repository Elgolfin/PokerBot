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
        public int Capacity;

        public Dealer Dealer { get; set; }
        public List<Card> Board { get; set; }
        public int NumberOfPlayers {
            get { return Players.Count; }
        }
        public int OccupiedSeats
        {
            get { return (from seat in Seats where seat.IsEmpty == false select seat).Count(); }
        }

        public Table(int capacity)
        {
            this.Capacity = capacity;
            Players = new List<Player>(capacity);
            Seats = new List<Seat>(capacity);
            Board = new List<Card>(5);
        }

        public void Open(Dealer dealer)
        {
            
            dealer.Table = this;
            Dealer = dealer;
            turn = 0;
            ShufflePlayers();
            for (int i = 0; i < Capacity; i++)
            {
                if (i < Players.Count)
                {
                    Seats.Add(new Seat(i + 1, Players[i]));
                }
                else
                {
                    Seats.Add(new Seat(i));
                }
            }
            IsOpened = true;
        }

        public void Close()
        {
            Dealer.Table = null;
            Dealer.Deck = null;
            Dealer = null;
            foreach (var seat in Seats)
            {
                seat.RemovePlayer();
            }
            Players = new List<Player>(Capacity);
            Board = new List<Card>(5);
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
