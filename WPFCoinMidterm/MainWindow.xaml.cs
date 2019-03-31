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
using WPFCoinMidterm.Views;
using WPFCoinMidterm.ViewModels;
using WPFCoinMidterm.Models;

namespace WPFCoinMidterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CurrencyRepo wallet;
        ViewModelCurrencyRepo vmWallet;

        public MainWindow()
        {
            wallet = new CurrencyRepo();
            vmWallet = new ViewModelCurrencyRepo(wallet);
            InitializeComponent();
            UserControlCurrencyRepo ucCR = new UserControlCurrencyRepo(vmWallet);
        }

        private void UserControlCurrencyRepo1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
