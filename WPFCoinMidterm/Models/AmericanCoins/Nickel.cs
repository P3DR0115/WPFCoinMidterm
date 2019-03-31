using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoinMidterm.Models
{
    public class Nickel : USCoin
    {
        public Nickel() : this(USCoinMintMark.D)
        {

        }

        public Nickel(USCoinMintMark mintLocation)
        {
            this.MintMark = mintLocation;
            this.MonetaryValue = 0.05;
            this.Name = "Nickel";
            this.Year = DateTime.Now.Year;
        }
    }
}
