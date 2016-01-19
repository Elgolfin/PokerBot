using System;

namespace Nicomputer.PokerBot.PokerGame
{
    public class HandPlayEngine
    {
        public Table Table;
        public Round CurrentRound;

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
            //TODO BettingRounds(Round.PreFlop)
            DealFlop();
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
                    i = 1;
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

        public void EndPlayAndCleanup()
        {
            Table.UpdateTurn();
        }
    }
}
