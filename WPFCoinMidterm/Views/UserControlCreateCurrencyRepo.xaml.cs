using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCoinMidterm.ViewModels;
using WPFCoinMidterm.Models;

namespace WPFCoinMidterm.Views
{
    /// <summary>
    /// Interaction logic for UserControlCreateCurrencyRepo.xaml
    /// </summary>
    public partial class UserControlCreateCurrencyRepo : UserControl
    {
        CurrencyRepo repo;
        ViewModelCreateCurrencyRepo ViewModelRepo;

        public UserControlCreateCurrencyRepo() : this(new ViewModelCreateCurrencyRepo(new CurrencyRepo()))
        {
            InitializeComponent();
        }
        public UserControlCreateCurrencyRepo(ViewModelCreateCurrencyRepo ViewModelRepo)
        {
            InitializeComponent();
            this.ViewModelRepo = ViewModelRepo;
            repo = ViewModelRepo.wallet;
            this.DataContext = ViewModelRepo;
        }

        private void ButtonAddCoin_Click(object sender, RoutedEventArgs e)
        {
            Coin tempC = new Penny();

            switch (CoinList.SelectionBoxItem)
            {
                case "Penny":
                    {
                        tempC = new Penny();
                        break;
                    }
                case "Nickel":
                    {
                        tempC = new Nickel();
                        break;
                    }
                case "Dime":
                    {
                        tempC = new Dime();
                        break;
                    }
                case "Quarter":
                    {
                        tempC = new Quarter();
                        break;
                    }
                case "Half Dollar":
                    {
                        tempC = new HalfDollar();
                        break;
                    }
                case "Dollar Coin":
                    {
                        tempC = new DollarCoin();
                        break;
                    }

            }

            repo.AddCoin(tempC);


            ViewModelRepo = new ViewModelCreateCurrencyRepo(repo);
            this.DataContext = ViewModelRepo;

            string value = Convert.ToString(repo.TotalValue());
            
            labelRepoValueDisplay.Content = "$" + value;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            repo.SaveRepo(repo);
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                repo = repo.LoadRepo();
                ViewModelRepo = new ViewModelCreateCurrencyRepo(repo.LoadRepo());
                this.DataContext = ViewModelRepo;
                string value = Convert.ToString(repo.TotalValue());
                labelRepoValueDisplay.Content = "$" + value;
            }
            catch(Exception w)
            {
                // Failed to load
            }
        }
    }
}