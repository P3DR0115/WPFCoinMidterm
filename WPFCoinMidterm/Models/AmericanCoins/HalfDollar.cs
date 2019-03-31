using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoinMidterm.Models
{
    public class HalfDollar : USCoin
    {
        public HalfDollar() : this(USCoinMintMark.D)
        {

        }

        public HalfDollar(USCoinMintMark mintLocation)
        {
            this.MintMark = mintLocation;
            this.MonetaryValue = 0.50;
            this.Name = "Half Dollar";
            this.Year = DateTime.Now.Year;
        }
    }
}
