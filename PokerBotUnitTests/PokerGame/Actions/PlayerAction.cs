using System;
using Nicomputer.PokerBot.PokerGame;

namespace Nicomputer.PokerBot.UnitTests.PokerGame.Actions
{
    public class PlayerAction
    {

        [Flags]
        public enum ActionType
        {
            Check = 0x01,
            Call = 0x02,
            Raise = 0x04,
            AllIn = 0x08,
            Fold = 0x10
        }

        //public static GetAvailableActions(Seat seat)

    }
}
