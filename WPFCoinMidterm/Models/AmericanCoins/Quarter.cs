﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoinMidterm.Models
{
    [Serializable]
    public class Quarter : USCoin
    {
        public Quarter() : this(USCoinMintMark.D)
        {

        }

        public Quarter(USCoinMintMark mintLocation)
        {
            this.MintMark = mintLocation;
            this.MonetaryValue = 0.25;
            this.Name = "Quarter";
            this.Year = DateTime.Now.Year;
        }
    }
}
