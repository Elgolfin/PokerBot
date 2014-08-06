using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicomputer.PokerBot.Cards.Suits
{
    public interface ISuit
    {
        string ToBinaryString();
        long ToLong();
    }
}
