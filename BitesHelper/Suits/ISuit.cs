using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Suits
{
    public interface ISuit
    {
        string ToBinaryString();
        long ToLong();
    }
}
