using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCoinMidterm.Models
{
    public interface ICurrency
    {
        double MonetaryValue { get; set; }
        string Name { get; }

        string About();
    }
}
