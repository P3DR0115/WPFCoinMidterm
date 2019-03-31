using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoinMidterm.Models
{
    public class DollarCoin : USCoin
    {
        public DollarCoin() : this(USCoinMintMark.D)
        {

        }

        public DollarCoin(USCoinMintMark mintLocation)
        {
            this.MintMark = mintLocation;
            this.MonetaryValue = 1.00;
            this.Name = "Dollar Coin";
            this.Year = DateTime.Now.Year;
        }
    }
}
