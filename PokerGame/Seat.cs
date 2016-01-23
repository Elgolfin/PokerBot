using Nicomputer.PokerBot.Cards;

namespace Nicomputer.PokerBot.PokerGame
{
    public class Seat
    {
        public Player Player;
        public HoleCards Hand;
        public int Number;

        public Seat(int number, Player player)
        {
            Number = number;
            AssignPlayer(player);
        }

        public Seat(int number)
        {
            Number = number;
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
                return (Player == null);
            }
        }
    }
}
