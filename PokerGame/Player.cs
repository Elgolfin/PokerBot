namespace Nicomputer.PokerBot.PokerGame
{
    public class Player
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string DisplayName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
