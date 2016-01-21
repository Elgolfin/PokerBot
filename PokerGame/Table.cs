using System;
using System.Collections.Generic;
using System.Linq;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.PokerGame
{
    public class Table
    {
        public List<Player> Players { get; private set; }
        public List<Seat> Seats;
        public int Turn { get; private set; }
        public bool IsOpened;
        public Dictionary<int, List<string>> Logs = new Dictionary<int, List<string>>(); // Will log all actions that will happen during the lifecycle of the table, player after player, turn after turn
        public int Capacity { get; }
        public int ButtonPosition { get; private set; }
        public int SmallBlindPosition { get; private set; }
        public int BigBlindPosition { get; private set; }
        public int FirstToPlayPreFlopPosition { get; private set; }
        public int FirstToPlayPostFlopPosition { get; private set; }


        public Dealer Dealer { get; set; }
        public List<Card> Board { get; set; }
        public int NumberOfPlayers {
            get { return Players.Count; }
        }
        public int NumberOfOccupiedSeats
        {
            get { return (from seat in Seats where !seat.IsEmpty select seat).Count(); }
        } 

        public Table(int capacity)
        {
            Capacity = capacity;
            Players = new List<Player>(capacity);
            Seats = new List<Seat>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Seats.Add(new Seat(i));
            }
            Board = new List<Card>(5);
            Turn = 0;
        }

        public void Open(Dealer dealer)
        {
            
            dealer.Table = this;
            Dealer = dealer;
            Turn = 1;
            InitializePositions();
            IsOpened = true;
        }

        /// <summary>
        /// TODO http://www.homepokertourney.com/button.htm
        /// </summary>
        /// <param name="startingPosition"></param>
        private void InitializePositions(int startingPosition = 0)
        {
            ButtonPosition = FindPosition(startingPosition);
            SmallBlindPosition = (NumberOfPlayers > 2) ? FindPosition(ButtonPosition + 1) : ButtonPosition;
            BigBlindPosition = FindPosition(SmallBlindPosition + 1);
            FirstToPlayPreFlopPosition = FindPosition(BigBlindPosition + 1);
            FirstToPlayPostFlopPosition = FindPosition(ButtonPosition + 1);
        }

        public void UpdatePositions()
        {
            InitializePositions(ButtonPosition + 1);
        }

        private int FindPosition(int startingSeat)
        {
            var currentIdx = startingSeat;
            for(var i = 0; i < Seats.Count; i++)
            {
                if (!Seats[currentIdx].IsEmpty)
                {
                    break;
                }
                currentIdx++;
                if (currentIdx >= Seats.Count)
                {
                    currentIdx = 0;
                }
            }
            return currentIdx;
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

        public void AddPlayer(Player player)
        {
            if (NumberOfPlayers < Capacity)
            {
                Players.Add(player);
                GetEmptySeat().Player = player;
            }
            else
            {
                throw new InvalidOperationException("The table is full. Cannot add a new player.");
            }

        }

        private Seat GetEmptySeat()
        {
            return (from seat in Seats where seat.IsEmpty select seat).FirstOrDefault();
        }


        /// <summary>
        /// Get the list of seats occupied by a player in the order of play (pre-flop)
        /// </summary>
        /// <returns></returns>
        public List<Seat> GetOccupiedSeatsOrderByPlayPreFlop()
        {
            return GetOccupiedSeats(FirstToPlayPreFlopPosition);
        }

        /// <summary>
        /// Get the list of seats occupied by a player in the order of play (pre-flop)
        /// </summary>
        /// <returns></returns>
        public List<Seat> GetOccupiedSeatsOrderByPlayPostFlop()
        {
            return GetOccupiedSeats(FirstToPlayPostFlopPosition);
        }

        /// <summary>
        /// Get the list of occupied seats (an occupied seat is a seat with a player)
        /// The first player to be dealt a card or to play (after pre-flop) is the small blind and so fhe first seat of the returned list of seats
        /// </summary>
        /// <returns></returns>
        public List<Seat> GetOccupiedSeatsOrderByToBeDealt()
        {
            return (NumberOfPlayers > 2) ? GetOccupiedSeats(SmallBlindPosition) : GetOccupiedSeats(BigBlindPosition);
        }

        public List<Seat> GetOccupiedSeats(int firstToRetrieve)
        {
            var currentIdx = firstToRetrieve;
            var occupiedSeats = new List<Seat>(NumberOfOccupiedSeats);
            for (var i = 0; i < Capacity; i++)
            {
                if (Seats[currentIdx] != null && !Seats[currentIdx].IsEmpty)
                {
                    occupiedSeats.Add(Seats[currentIdx]);
                }
                currentIdx = (++currentIdx) == Capacity ? 0 : currentIdx;
            }
            return occupiedSeats;
        }

        public void UpdateTurn()
        {
            Turn++;
        }
    }
}
