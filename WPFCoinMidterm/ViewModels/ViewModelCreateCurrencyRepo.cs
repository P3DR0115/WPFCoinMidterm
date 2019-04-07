using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCoinMidterm.Models;

namespace WPFCoinMidterm.ViewModels
{
    public class ViewModelCreateCurrencyRepo : ViewModelBase
    {
        public CurrencyRepo wallet;

        public ViewModelCreateCurrencyRepo(CurrencyRepo wallet)
        {
            this.wallet = wallet;
        }

        // This is a wrapper that will take the MODEL's properties and VIEW MODEL is the remote the user uses to alter data
        public string[] CoinOptions
        {
            get { return this.wallet.CoinOptions(); }
            set
            {
                RaisePropertyChanged();
                //this.wallet.GetCoinCount = value;
            }
        }

        public string[] CoinNames
        {
            get { return this.wallet.CoinNames(); }
            set
            {
                RaisePropertyChanged();
                //this.dog.Name = value;
            }
        }

        public double TotalValue
        {
            get { return this.wallet.TotalValue(); }
            set
            {
                RaisePropertyChanged();
                //this.dog.Age = value;
            }
        }
    }
}
