using Nicomputer.PokerBot.Cards.Hands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nicomputer.PokerBot.PokerGame
{
    public class HandPlayEngine
    {
        public Table Table;
        public Round CurrentRound;
        public Queue<Seat> ActiveSeats;
        public Dictionary<Player, PokerHand> LastHandResults;
        public Dictionary<Player, PokerHand> LastHandWinners;

        [Flags]
        public enum Round
        {
            PreFlop = 0x01,
            Flop = 0x02,
            Turn = 0x04,
            River = 0x08,
            Showdown = 0x10
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table">Must have been opened</param>
        public HandPlayEngine(Table table)
        {
            if (!table.IsOpened)
            {
                throw new InvalidOperationException("The table must have been properly opened.");
            }
            Table = table;
        }

        public void Run()
        {
            CurrentRound = Round.PreFlop;
            SetPositions();
            DealHands();
            ActiveSeats = Table.GetQueueOfSeatsOrderByPlayPreFlop();
            //TODO BettingRounds(Round.PreFlop)
            DealFlop();
            ActiveSeats = Table.GetQueueOfSeatsOrderByPlayPostFlop();
            //TODO BettingRounds(Round.Flop)
            DealTurn();
            //TODO BettingRounds(Round.Turn)
            DealRiver();
            //TODO BettingRounds(Round.River)
            Showdown();
            EndPlayAndCleanup();
        }

        public void SetPositions()
        {
            if (Table.Turn > 1)
            {
                Table.UpdatePositions();
            }
        }

        public void DealHands()
        {
            Table.Dealer.ShuffleDeck();
            Table.Dealer.DealHands();
        }

        // TODO do real implementation :)
        // Below is a very dummy implementation
        public void BettingRounds(Round rnd)
        {
            var i = 0;
            switch (rnd)
            {
                case Round.PreFlop:
                    break;
                case Round.Flop:
                    i = 2;
                    break;
                case Round.Turn:
                    i = 3;
                    break;
                case Round.River:
                    i = 4;
                    break;
            }
            if (i > 0)
            {
                throw new NotImplementedException();
            }

        }

        public void DealFlop()
        {
            Table.Dealer.DealFlop();

        }

        public void DealTurn()
        {
            Table.Dealer.DealTurn();
        }

        public void DealRiver()
        {
            Table.Dealer.DealRiver();
        }

        // TODO implement this
        public void Showdown()
        {
            //TODO implement this
            
        }

        private void SetHandResults()
        {
            var phh = new Hashtable();
            var phs = new List<PokerHand>();
            LastHandResults = new Dictionary<Player, PokerHand>(Table.NumberOfPlayers);
            LastHandWinners = new Dictionary<Player, PokerHand>();
            var pht = new PokerHandAnalyzer();
            foreach (var seat in Table.GetOccupiedSeats(Table.ButtonPosition))
            {
                var ph = new PokerHand(seat.Hand, Table.Board);
                pht.AddPokerHand(ph);
                phs.Add(ph);
                phh.Add(ph.ToLong(),seat.Player);
            }
            phs.Sort();
            foreach (var ph in phs)
            {
                LastHandResults.Add((Player)phh[ph.ToLong()], ph);
                if (LastHandWinners.Count <= 0)
                {
                    LastHandWinners.Add((Player) phh[ph.ToLong()], ph);
                }
                else
                {
                    if (LastHandWinners.Values.ToList()[0].Equals(ph))
                    {
                        LastHandWinners.Add((Player)phh[ph.ToLong()], ph);
                    }
                }
                
            }
        }

        public void EndPlayAndCleanup()
        {
            SetHandResults();
            Table.UpdateTurn();
        }
    }
}
