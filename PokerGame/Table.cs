﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.PokerGame
{
    public class Table
    {
        public List<Player> Players { get; private set; }
        public List<Seat> Seats;
        public int Turn { get; private set; }
        public bool IsOpened = false;
        public Dictionary<int, List<string>> Logs = new Dictionary<int, List<string>>(); // Will log all actions that will happen during the lifecycle of the table, player after player, turn after turn
        public int Capacity { get; private set; }
        public int ButtonPosition { get; private set; }
        public int SmallBlindPosition { get; private set; }
        public int BigBlindPosition { get; private set; }


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

        private void InitializePositions(int startingPosition = 0)
        {
            ButtonPosition = FindPosition(startingPosition);
            SmallBlindPosition = (NumberOfPlayers > 2) ? FindPosition(ButtonPosition + 1) : ButtonPosition;
            BigBlindPosition = FindPosition(SmallBlindPosition + 1);
        }

        public void UpdatePositions()
        {
            InitializePositions(ButtonPosition + 1);
        }

        private int FindPosition(int startingSeat)
        {
            var currentIdx = startingSeat;
            foreach(var seat in Seats)
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
            return (from seat in Seats where seat.IsEmpty == true select seat).FirstOrDefault();
        }

        public void UpdateTurn()
        {
            Turn++;
        }
    }
}
